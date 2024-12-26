
using Rent_A_Car.Kupci;
using Rent_A_Car.Other;
using Rent_A_Car.Rezervacije;
using Rent_A_Car.Vozila;
using Rent_A_Car.Vozila.Automobili;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Rent_A_Car {
    /// <summary>
    /// Klasa koja se koristi za simulaciju rezervacije vozila.
    /// </summary>
    internal sealed class Simulator : IReservation {
        private Dictionary<int, Vozilo> vozila;         // vozila
        private Dictionary<int, Oprema> oprema;         // oprema
        private Dictionary<int, Kupac> kupci;           // kupci
        private List<Tuple<int, int>> vozilo_oprema;    // id vozila, id opreme
        private List<Rezervacija> rezervacije;          // rezervacije sortirane po datumu pocetka rezervacije rastuce
        private List<RezervacijaZahtev> zahtevi;        // zahtevi za rezervacijom sortirani po datumu dolaska rastuce
        private List<Rezervacija> nove_rezervacije;     // rezervacije koje ce biti upisane u fajl

        public Simulator() {
            vozila = DataReader.UcitajVozila(Constants.BASE_FILE_PATH + "vozila.csv");
            oprema = DataReader.UcitajOpremu(Constants.BASE_FILE_PATH + "oprema.csv");
            kupci = DataReader.UcitajKupce(Constants.BASE_FILE_PATH + "kupci.csv");
            rezervacije = DataReader.UcitajRezervacije(Constants.BASE_FILE_PATH + "rezervacije.csv");
            zahtevi = DataReader.UcitajZahteveZaRezervacijom(Constants.BASE_FILE_PATH + "zahtevi_za_rezervacije.csv");
            vozilo_oprema = DataReader.UcitajOpremuZaAutomobile(Constants.BASE_FILE_PATH + "vozilo_oprema.csv");

            nove_rezervacije = new List<Rezervacija>();

            var spojeno = SpojiVozilaIOpremu();
            DodajOpremuVozilima(spojeno);
            DodajVozilimaRezervacije(); // dodaj postojece rezervacije vozilima
        }

        /// <summary>
        /// Funkcija koja simulira rezervaciju vozila.
        /// Prolazi kroz sve zahteve za rezervacijom i proverava da li je moguce iznajmiti vozilo.
        /// Ukoliko je moguce iznajmiti vozilo, kupcu se skida odgovarajuci iznos sa budzeta i dodaje se nova rezervacija.
        /// Ukoliko kupac nema dovoljno novca ili je termin zauzet, ispisuje se odgovarajuca poruka.
        /// </summary>
        public void SimulirajRezervaciju() {

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Simulacija rezervacija...");

            foreach (var zahtev in zahtevi) {   // zahtevi su sortirani po datumu dolaska (rastuce) tako da ce se prolaskom prvo proveravati i rezerisati oni koji su dosli prvi
                var vozilo = vozila[zahtev.VoziloId];
                var kupac = kupci[zahtev.KupacId];
                int brojDana = (zahtev.KrajRezervacije - zahtev.PocetakRezervacije).Days;
                double cena = vozilo.CenaPoDanu() * brojDana;
                cena -= cena * (kupac.DajPopust() / 100);

                //Console.WriteLine(cena);

                if (cena > kupac.Budzet) {
                    Console.WriteLine($"{kupac.Id} {kupac.Ime} {kupac.Prezime}: NEDOVOLJAN BUDZET");
                    //Console.WriteLine("Potrban iznos: " + cena);
                    //Console.WriteLine("Trenutni budzet: " + kupac.Budzet);
                    continue;
                }

                if (kupac.DaLiImaRezervaciju(zahtev.PocetakRezervacije, zahtev.KrajRezervacije)) {
                    Console.WriteLine($"{kupac.Id} {kupac.Ime} {kupac.Prezime}: ZAUZET TERMIN");
                    continue;
                }

                if (vozilo.DaLiJeSlobodan(zahtev.PocetakRezervacije, zahtev.KrajRezervacije) == false) {
                    Console.WriteLine($"{kupac.Id} {kupac.Ime} {kupac.Prezime}: ZAUZET TERMIN");
                    continue;
                }

                // postoji kupac koji je dosao istog dana
                // kupac zeli da iznajmi isto vozilo
                // kupac ima dovoljno novca da iznajmi to vozilo (sa popustom)
                // kupac moze da iznajmi vozilo jer nema preklapanja sa svojim prethodnim rezervacijama
                // vozilo je slobodno u tom periodu
                // kupac ima clansku karticu (ukoliko nema onda ce trenutni kupac iznajmiti vozilo bez obzira na karticu)
                // clanska kartica drugog kupca je bolja

                var kupciUPrednosti = zahtevi.FindAll(
                        z => z.KupacId != zahtev.KupacId &&         // ne treba da se uporedjuje sa samim sobom
                        z.DatumDolaska == zahtev.DatumDolaska &&    // dosli su istog dana
                        z.VoziloId == zahtev.VoziloId &&            // zele isto vozilo
                        (vozila[z.VoziloId].CenaPoDanu() * (z.KrajRezervacije - z.PocetakRezervacije).Days) * (kupci[z.KupacId].DajPopust() / 100) <= kupci[z.KupacId].Budzet &&     // drugi kupac ima dovoljno novca
                        kupci[z.KupacId].DaLiImaRezervaciju(z.PocetakRezervacije, z.KrajRezervacije) == false &&    // drugi kupac nema preklapanja sa svojim prethodnim rezervacijama (jedan kupac moze imati jedno vozilo u jednom vremenskom periodu)
                        vozila[z.VoziloId].DaLiJeSlobodan(z.PocetakRezervacije, z.KrajRezervacije) &&   // vozilo je slobodno za iznajmljivanje
                        kupci[z.KupacId].Kartica != null &&         // drugi kupac ima clansku karticu
                        (kupac.Kartica == null || (kupac.Kartica != null && kupci[z.KupacId].Kartica > kupac.Kartica)) // clanska kartica drugog kupca je bolja
                );

                if (kupciUPrednosti.Count > 0) { // postoji kupac koji je u prednosti
                    Console.WriteLine($"{kupac.Id} {kupac.Ime} {kupac.Prezime}: ZAUZET TERMIN");
                    continue;
                }

                // Console.WriteLine($"Kupac {kupac.Id} je iznajmio vozilo {vozilo.Id} za {brojDana} dana po ceni {cena}");
                kupac.IzmeniBudzet(cena, false);
                // Console.WriteLine($"Novi budzet: {kupac.Budzet}");
                kupac.DodajRezervaciju(zahtev.PocetakRezervacije, zahtev.KrajRezervacije);
                vozilo.DodajRezervaciju(zahtev.PocetakRezervacije, zahtev.KrajRezervacije);
                nove_rezervacije.Add(new Rezervacija(zahtev.VoziloId, zahtev.KupacId, zahtev.PocetakRezervacije, zahtev.KrajRezervacije));
                //Console.WriteLine($"Kupac {kupac.Id} je iznajmio vozilo {vozilo.Id} za {brojDana} dana po ceni {cena}");
            }
            Console.ResetColor();

            // upis novih rezervacija u fajl
            Console.WriteLine();
            DataWriter.UpisiRezervacije(Constants.OUTPUT_FILE_BASE_PATH, Constants.NAZIV_OUTPUT_FAJLA, nove_rezervacije);
            
            rezervacije.AddRange(nove_rezervacije); // dodaj nove rezervacije u listu svih rezervacija
        }

        /// <summary>
        /// Ispisuje vozila na standardni izlaz zajedno sa cenom po danu.
        /// </summary>
        public void IspisiVozilaSaCenom() {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Vozila sa cenom:");
            foreach (var v in vozila) {
                Console.WriteLine(v.Value);
            }
            Console.ResetColor();
        }

        /// <summary>
        /// Ispisuje kupce na standardni izlaz.
        /// </summary>
        public void IspisiKupce() {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Kupci:");
            foreach (var k in kupci) {
                Console.WriteLine(k.Value);
                if (k.Value.Kartica != null) {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Popust ostvaren na prethodnim rezervacijama: {IzracunajPrethodniPopust(k.Key, k.Value.Kartica.DajPopust())}e");
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Popust ostvaren na prethodnim rezervacijama: 0e (Kupac nema karticu)");
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
            }
            Console.WriteLine(Constants.LINE);
            Console.ResetColor();
        }

        /// <summary>
        /// Isprisuje prethodne rezervacije na standardni izlaz.
        /// </summary>
        public void IspisiPrethodneRezervacije() {
            foreach (var r in rezervacije) {
                Console.WriteLine(r);
            }
        }

        /// <summary>
        /// Ispirse zahteve za rezervacijom na standardni izlaz.
        /// </summary>
        public void IspisiZahteveZaRezervacijom() {
            foreach (var z in zahtevi) {
                Console.WriteLine(z);
            }
        }

        /// <summary>
        /// Vozilima dodaje rezervacije koje su vec postojale pre pokretanja simulacije.
        /// </summary>
        private void DodajVozilimaRezervacije() {
            foreach (var r in rezervacije) {
                try {
                    vozila[r.VoziloId].DodajRezervaciju(r.PocetakRezervacije, r.KrajRezervacije);
                }
                catch (KeyNotFoundException) {
                    Console.WriteLine($"Vozilo sa id {r.VoziloId} ne postoji");
                }
            }
        }

        /// <summary>
        /// Izracunava popust koji je kupac ostvario na prethodnim rezervacijama.
        /// </summary>
        /// <param name="kupacId"></param>
        /// <param name="iznosPopusta"></param>
        /// <returns></returns>
        private double IzracunajPrethodniPopust(int kupacId, double iznosPopusta) {
            return rezervacije.FindAll(rezervacija => rezervacija.KupacId == kupacId)
                    .Select(rezervacija => {
                        var vozilo = vozila[rezervacija.VoziloId];
                        if (vozilo != null) {
                            var duration = (rezervacija.KrajRezervacije - rezervacija.PocetakRezervacije).TotalDays;
                            return vozilo.CenaPoDanu() * duration * (iznosPopusta / 100);
                        }
                        return 0;
                    })
                    .Sum();
        }

        /// <summary>
        /// Spaja vozila i opremu.
        /// </summary>
        /// <returns></returns>
        private IEnumerable<(Vozilo, Oprema)> SpojiVozilaIOpremu() {
            Debug.Assert(vozila != null, "Recnik sa vozilima ne sme biti null");
            Debug.Assert(oprema != null, "Recnik sa opremom ne sme biti null");
            Debug.Assert(vozilo_oprema != null, "Lista sa opremom za automobile ne sme biti null");

            var spojeno = from v in vozila.Keys
                          join vo in vozilo_oprema on v equals vo.Item1
                          join o in oprema.Keys on vo.Item2 equals o
                          select (vozila[v], oprema[vo.Item2]);

            return spojeno;
        }

        /// <summary>
        /// Dodaje opremu vozilima.
        /// </summary>
        /// <param name="spojeno"></param>
        private void DodajOpremuVozilima(IEnumerable<(Vozilo, Oprema)> spojeno) {
            foreach (var s in spojeno) {
                if (s.Item1 is Automobil a) {
                    a.DodajOpremu(s.Item2);
                }
            }
        }

    }
}
