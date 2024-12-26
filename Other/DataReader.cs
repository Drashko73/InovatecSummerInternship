
using Rent_A_Car.Kartice;
using Rent_A_Car.Kupci;
using Rent_A_Car.Rezervacije;
using Rent_A_Car.Vozila;
using System;
using System.Collections.Generic;

namespace Rent_A_Car.Other {
    internal sealed class DataReader {

        private static KarticaCreator karticaCreator = new KarticaCreator();
        private static VoziloCreator voziloCreator = new VoziloCreator();

        /// <summary>
        /// Ucitava kupce iz fajla na zadatoj putanji. 
        /// Format linija u fajlu: Id,Ime,Prezime,Budzet,Clanarina.
        /// </summary>
        /// <param name="putanja"></param>
        /// <returns></returns>
        /// <exception cref="System.IO.FileNotFoundException"></exception>
        /// <exception cref="System.IO.IOException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Exception"></exception>
        public static Dictionary<int, Kupac> UcitajKupce(string putanja) {
            if (System.IO.File.Exists(putanja) == false) {
                throw new System.IO.FileNotFoundException("Fajl sa kupcima nije pronadjen na zadatoj putanji.");
            }

            Dictionary<int, Kupac> kupci = new Dictionary<int, Kupac>();
            string[] linije;

            try {
                linije = System.IO.File.ReadAllLines(putanja);
            }
            catch (System.IO.IOException e) {
                throw new System.IO.IOException("Greska prilikom citanja fajla sa kupcima.", e);
            }

            bool header = true;
            foreach (string linija in linije) {
                if (header) {
                    header = false;
                    continue;
                }

                string[] delovi = linija.Split(',');
                if (delovi.Length != 5) {
                    throw new FormatException("Neispravan format linije u fajlu sa kupcima.");
                }

                try {
                    int id = int.Parse(delovi[0].Trim());
                    string ime = delovi[1].Trim();
                    string prezime = delovi[2].Trim();
                    double budzet = double.Parse(delovi[3].Trim());
                    string nazivKartice = delovi[4].Trim();

                    Kupac kupac = new Kupac(id, ime, prezime, budzet, karticaCreator.NapraviKarticu(nazivKartice));
                    kupci.Add(id, kupac);
                }
                catch (FormatException e) {
                    throw new FormatException("Neispravan format linije u fajlu sa kupcima.", e);
                }
                catch (OverflowException e) {
                    throw new OverflowException("Prekoracenje vrednosti prilikom parsiranja linije u fajlu sa kupcima.", e);
                }
                catch (ArgumentNullException e) {
                    throw new ArgumentNullException("Nedostajuće vrednosti prilikom parsiranja linije u fajlu sa kupcima.", e);
                }
                catch (ArgumentException e) {
                    throw new ArgumentException("Neispravna vrednost prilikom parsiranja linije u fajlu sa kupcima.", e);
                }
                catch (Exception e) {
                    throw new Exception("Greska prilikom parsiranja linije u fajlu sa kupcima.", e);
                }
            }
            return kupci;
        }

        /// <summary>
        /// Ucitaa opreme iz fajla na zadatoj putanji.
        /// Format linija u fajlu: Id,Naziv,Cena,PovecavaCenu.
        /// </summary>
        /// <param name="putanja"></param>
        /// <returns></returns>
        /// <exception cref="System.IO.FileNotFoundException"></exception>
        /// <exception cref="System.IO.IOException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Exception"></exception>
        public static Dictionary<int, Oprema> UcitajOpremu(string putanja) {
            if (System.IO.File.Exists(putanja) == false) {
                throw new System.IO.FileNotFoundException("Fajl sa opremom nije pronadjen na zadatoj putanji.");
            }

            Dictionary<int, Oprema> oprema = new Dictionary<int, Oprema>();
            string[] linije;

            try {
                linije = System.IO.File.ReadAllLines(putanja);
            }
            catch (System.IO.IOException e) {
                throw new System.IO.IOException("Greska prilikom citanja fajla sa opremom.", e);
            }

            bool header = true;
            foreach (string linija in linije) {
                if (header) {
                    header = false;
                    continue;
                }

                string[] delovi = linija.Split(',');
                if (delovi.Length != 4) {
                    throw new FormatException("Neispravan format linije u fajlu sa opremom.");
                }

                try {
                    int id = int.Parse(delovi[0].Trim());
                    string naziv = delovi[1].Trim();
                    double cena = double.Parse(delovi[2].Trim());
                    int povecavaCenu = int.Parse(delovi[3].Trim());

                    Oprema oprema1 = new Oprema(id, naziv, cena, povecavaCenu == 1 ? true : false);
                    oprema.Add(id, oprema1);
                }
                catch (FormatException e) {
                    throw new FormatException("Neispravan format linije u fajlu sa opremom.", e);
                }
                catch (OverflowException e) {
                    throw new OverflowException("Prekoracenje vrednosti prilikom parsiranja linije u fajlu sa opremom.", e);
                }
                catch (ArgumentNullException e) {
                    throw new ArgumentNullException("Nedostajuće vrednosti prilikom parsiranja linije u fajlu sa opremom.", e);
                }
                catch (ArgumentException e) {
                    throw new ArgumentException("Neispravna vrednost prilikom parsiranja linije u fajlu sa opremom.", e);
                }
                catch (Exception e) {
                    throw new Exception("Greska prilikom parsiranja linije u fajlu sa opremom.", e);
                }
            }

            return oprema;
        }

        /// <summary>
        /// Ucitava vozila iz fajla na zadatoj putanji.
        /// Format linija u fajlu: Id,TipVozila,Marka,Model,Potrosnja,Kubikaza,Kilometraza,Snaga,Tip.
        /// </summary>
        /// <param name="putanja"></param>
        /// <returns></returns>
        /// <exception cref="System.IO.FileNotFoundException"></exception>
        /// <exception cref="System.IO.IOException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Exception"></exception>
        public static Dictionary<int, Vozilo> UcitajVozila(string putanja) {
            if (System.IO.File.Exists(putanja) == false) {
                throw new System.IO.FileNotFoundException("Fajl sa vozilima nije pronadjen na zadatoj putanji.");
            }

            Dictionary<int, Vozilo> vozila = new Dictionary<int, Vozilo>();
            string[] linije;

            try {
                linije = System.IO.File.ReadAllLines(putanja);
            }
            catch (System.IO.IOException e) {
                throw new System.IO.IOException("Greska prilikom citanja fajla sa vozilima.", e);
            }

            bool header = true;
            foreach (string linija in linije) {
                if (header) {
                    header = false;
                    continue;
                }

                string[] delovi = linija.Split(',');
                if (delovi.Length != 9) {
                    throw new FormatException("Neispravan format linije u fajlu sa vozilima.");
                }

                try {
                    int id = int.Parse(delovi[0].Trim());
                    string tipVozila = delovi[1].Trim();
                    string marka = delovi[2].Trim();
                    string model = delovi[3].Trim();
                    string potrosnja = delovi[4].Trim();
                    string kubikaza = delovi[5].Trim();
                    string kilometraza = delovi[6].Trim();
                    string snaga = delovi[7].Trim();
                    // bitno da bude ToUpper jer su vrednosti u enumu zapisane velikim slovima, a Replace da bi se uklonili svi razmaci (npr. "Urban Mobility" -> "URBANMOBILITY")
                    string tip = delovi[8].ToUpper().Replace(" ", "");

                    Vozilo vozilo = voziloCreator.KreirajVozilo(id, tipVozila, marka, model, potrosnja, kubikaza, kilometraza, snaga, tip);
                    vozila.Add(id, vozilo);
                }
                catch (FormatException e) {
                    throw new FormatException("Neispravan format linije u fajlu sa vozilima.", e);
                }
                catch (OverflowException e) {
                    throw new OverflowException("Prekoracenje vrednosti prilikom parsiranja linije u fajlu sa vozilima.", e);
                }
                catch (ArgumentNullException e) {
                    throw new ArgumentNullException("Nedostajuće vrednosti prilikom parsiranja linije u fajlu sa vozilima.", e);
                }
                catch (ArgumentException e) {
                    throw new ArgumentException("Neispravna vrednost prilikom parsiranja linije u fajlu sa vozilima.", e);
                }
                catch (Exception e) {
                    throw new Exception("Greska prilikom parsiranja linije u fajlu sa vozilima.", e);
                }
            }

            return vozila;
        }

        /// <summary>
        /// Ucitava opremu za automobile iz fajla na zadatoj putanji.
        /// Format linija u fajlu: IdVozila,IdOpreme.
        /// </summary>
        /// <param name="putanja"></param>
        /// <returns></returns>
        /// <exception cref="System.IO.FileNotFoundException"></exception>
        /// <exception cref="System.IO.IOException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Exception"></exception>
        public static List<Tuple<int, int>> UcitajOpremuZaAutomobile(string putanja) {
            if (System.IO.File.Exists(putanja) == false) {
                throw new System.IO.FileNotFoundException("Fajl sa opremom za automobile nije pronadjen na zadatoj putanji.");
            }

            string[] linije;
            try {
                linije = System.IO.File.ReadAllLines(putanja);
            }
            catch (System.IO.IOException e) {
                throw new System.IO.IOException("Greska prilikom citanja fajla sa opremom za automobile.", e);
            }

            bool header = true;
            List<Tuple<int, int>> opremaZaAutomobile = new List<Tuple<int, int>>();
            foreach (string linija in linije) {
                if (header) {
                    header = false;
                    continue;
                }

                string[] delovi = linija.Split(',');
                if (delovi.Length != 2) {
                    throw new FormatException("Neispravan format linije u fajlu sa opremom za automobile.");
                }

                try {
                    int idVozila = int.Parse(delovi[0].Trim());
                    int idOpreme = int.Parse(delovi[1].Trim());
                    opremaZaAutomobile.Add(new Tuple<int, int>(idVozila, idOpreme));
                }
                catch (FormatException e) {
                    throw new FormatException("Neispravan format linije u fajlu sa opremom za automobile.", e);
                }
                catch (OverflowException e) {
                    throw new OverflowException("Prekoracenje vrednosti prilikom parsiranja linije u fajlu sa opremom za automobile.", e);
                }
                catch (ArgumentNullException e) {
                    throw new ArgumentNullException("Nedostajuće vrednosti prilikom parsiranja linije u fajlu sa opremom za automobile.", e);
                }
                catch (ArgumentException e) {
                    throw new ArgumentException("Neispravna vrednost prilikom parsiranja linije u fajlu sa opremom za automobile.", e);
                }
                catch (Exception e) {
                    throw new Exception("Greska prilikom parsiranja linije u fajlu sa opremom za automobile.", e);
                }
            }

            return opremaZaAutomobile;
        }

        /// <summary>
        /// Ucitava rezervacije iz fajla na zadatoj putanji.
        /// Format linija u fajlu: VoziloId,KupacId,PocetakRezervacije,KrajRezervacije.
        /// </summary>
        /// <param name="putanja"></param>
        /// <returns></returns>
        /// <exception cref="System.IO.FileNotFoundException"></exception>
        /// <exception cref="System.IO.IOException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Exception"></exception>
        public static List<Rezervacija> UcitajRezervacije(string putanja) {
            if (System.IO.File.Exists(putanja) == false) {
                throw new System.IO.FileNotFoundException("Fajl sa rezervacijama nije pronadjen na zadatoj putanji.");
            }

            string[] linije;
            try {
                linije = System.IO.File.ReadAllLines(putanja);
            }
            catch (System.IO.IOException e) {
                throw new System.IO.IOException("Greska prilikom citanja fajla sa rezervacijama.", e);
            }

            bool header = true;
            List<Rezervacija> rezervacije = new List<Rezervacija>();

            foreach (string linija in linije) {
                if (header) {
                    header = false;
                    continue;
                }

                string[] delovi = linija.Split(',');
                if (delovi.Length != 4) {
                    throw new FormatException("Neispravan format linije u fajlu sa rezervacijama.");
                }

                try {
                    int voziloId = int.Parse(delovi[0].Trim());
                    int kupacId = int.Parse(delovi[1].Trim());
                    DateTime pocetakRezervacije = DateTime.Parse(delovi[2].Trim());
                    DateTime krajRezervacije = DateTime.Parse(delovi[3].Trim());

                    Rezervacija rezervacija = new Rezervacija(voziloId, kupacId, pocetakRezervacije, krajRezervacije);
                    rezervacije.Add(rezervacija);
                }
                catch (FormatException e) {
                    throw new FormatException("Neispravan format linije u fajlu sa rezervacijama.", e);
                }
                catch (OverflowException e) {
                    throw new OverflowException("Prekoracenje vrednosti prilikom parsiranja linije u fajlu sa rezervacijama.", e);
                }
                catch (ArgumentNullException e) {
                    throw new ArgumentNullException("Nedostajuće vrednosti prilikom parsiranja linije u fajlu sa rezervacijama.", e);
                }
                catch (ArgumentException e) {
                    throw new ArgumentException("Neispravna vrednost prilikom parsiranja linije u fajlu sa rezervacijama.", e);
                }
                catch (Exception e) {
                    throw new Exception("Greska prilikom parsiranja linije u fajlu sa rezervacijama.", e);
                }
            }
            rezervacije.Sort((x, y) => DateTime.Compare(x.PocetakRezervacije, y.PocetakRezervacije));
            return rezervacije;
        }

        /// <summary>
        /// Ucitava zahteve za rezervacijom iz fajla na zadatoj putanji.
        /// Format linija u fajlu: VoziloId,KupacId,DatumDolaska,PocetakRezervacije,BrojDana.
        /// </summary>
        /// <param name="putanja"></param>
        /// <returns></returns>
        /// <exception cref="System.IO.FileNotFoundException"></exception>
        /// <exception cref="System.IO.IOException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="Exception"></exception>
        public static List<RezervacijaZahtev> UcitajZahteveZaRezervacijom(string putanja) {
            if (System.IO.File.Exists(putanja) == false) {
                throw new System.IO.FileNotFoundException("Fajl sa zahtevima za rezervacijom nije pronadjen na zadatoj putanji.");
            }

            string[] linije;
            try {
                linije = System.IO.File.ReadAllLines(putanja);
            }
            catch (System.IO.IOException e) {
                throw new System.IO.IOException("Greska prilikom citanja fajla sa zahtevima za rezervacijom.", e);
            }

            bool header = true;
            List<RezervacijaZahtev> zahtevi = new List<RezervacijaZahtev>();
            foreach (string linija in linije) {
                if (header) {
                    header = false;
                    continue;
                }

                string[] delovi = linija.Split(',');
                if (delovi.Length != 5) {
                    throw new FormatException("Neispravan format linije u fajlu sa zahtevima za rezervacijom.");
                }

                try {
                    int voziloId = int.Parse(delovi[0].Trim());
                    int kupacId = int.Parse(delovi[1].Trim());
                    DateTime datumDolaska = DateTime.Parse(delovi[2].Trim());
                    DateTime pocetakRezervacije = DateTime.Parse(delovi[3].Trim());
                    int brojDana = int.Parse(delovi[4].Trim());
                    DateTime krajRezervacije = pocetakRezervacije.AddDays(brojDana);

                    RezervacijaZahtev zahtev = new RezervacijaZahtev(voziloId, kupacId, pocetakRezervacije, krajRezervacije, datumDolaska);
                    zahtevi.Add(zahtev);
                }
                catch (FormatException e) {
                    throw new FormatException("Neispravan format linije u fajlu sa zahtevima za rezervacijom.", e);
                }
                catch (OverflowException e) {
                    throw new OverflowException("Prekoracenje vrednosti prilikom parsiranja linije u fajlu sa zahtevima za rezervacijom.", e);
                }
                catch (ArgumentNullException e) {
                    throw new ArgumentNullException("Nedostajuće vrednosti prilikom parsiranja linije u fajlu sa zahtevima za rezervacijom.", e);
                }
                catch (ArgumentException e) {
                    throw new ArgumentException("Neispravna vrednost prilikom parsiranja linije u fajlu sa zahtevima za rezervacijom.", e);
                }
                catch (Exception e) {
                    throw new Exception("Greska prilikom parsiranja linije u fajlu sa zahtevima za rezervacijom.", e);
                }
            }

            zahtevi.Sort((x, y) => DateTime.Compare(x.DatumDolaska, y.DatumDolaska));
            return zahtevi;
        }

    }
}
