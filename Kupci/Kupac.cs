
using Rent_A_Car.Kartice;
using System;
using System.Collections.Generic;

namespace Rent_A_Car.Kupci {
    internal sealed class Kupac {
        public int Id { get; private set; }
        public string Ime { get; private set; }
        public string Prezime { get; private set; }
        public double Budzet { get; private set; }
        public ClanskaKartica Kartica { get; private set; }
        public List<Tuple<DateTime, DateTime>> Rezervacije { get; private set; }

        public Kupac(int id, string ime, string prezime, double budzet, ClanskaKartica kartica) {
            Id = id;
            Ime = ime;
            Prezime = prezime;
            Budzet = budzet;
            Kartica = kartica;
            Rezervacije = new List<Tuple<DateTime, DateTime>>();
        }

        /// <summary>
        /// Dodaje rezervaciju u listu licnih rezervacija vozila.
        /// </summary>
        /// <param name="pocetak"></param>
        /// <param name="kraj"></param>
        public void DodajRezervaciju(DateTime pocetak, DateTime kraj) {
            Rezervacije.Add(new Tuple<DateTime, DateTime>(pocetak, kraj));
        }

        /// <summary>
        /// Uklanja rezervaciju iz liste licnih rezervacija vozila.
        /// </summary>
        /// <param name="pocetak"></param>
        /// <param name="kraj"></param>
        public void UkloniRezervaciju(DateTime pocetak, DateTime kraj) {
            try {
                Rezervacije.Remove(Rezervacije.Find(r => r.Item1 == pocetak && r.Item2 == kraj));
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Menja budzet kupca za odredjeni iznos u zavisnosti od toga da li se radi o uvecanju ili smanjenju.
        /// </summary>
        /// <param name="iznos"></param>
        /// <param name="uvecaj"></param>
        public void IzmeniBudzet(double iznos, bool uvecaj) {
            if (uvecaj) {
                Budzet += iznos;
            }
            else {
                Budzet -= iznos;
            }
        }

        /// <summary>
        /// Dohvata popust koji kupac ostvaruje na osnovu svoje clanske kartice.
        /// </summary>
        /// <returns></returns>
        public double DajPopust() {
            return (Kartica != null) ? Kartica.DajPopust() : 0;
        }

        /// <summary>
        /// Proverava da li kupac ima rezervaciju u odredjenom vremenskom periodu.
        /// </summary>
        /// <param name="pocetak"></param>
        /// <param name="kraj"></param>
        /// <returns></returns>
        public bool DaLiImaRezervaciju(DateTime pocetak, DateTime kraj) {
            foreach (var r in Rezervacije) {
                if(r.Item1 <= kraj && r.Item2 >= pocetak) {
                    return true;
                }
            }
            return false;
        }

        public override string ToString() {
            string s = Constants.LINE + Environment.NewLine;
            s += "ID: " + Id + Environment.NewLine +
                    "Ime: " + Ime + Environment.NewLine +
                    "Prezime: " + Prezime + Environment.NewLine +
                    "Budzet: " + Budzet + "e" + Environment.NewLine +
                    "Kartica: " + ((Kartica != null) ? Kartica.ToString() : "NEMA") + Environment.NewLine;
            s += Constants.LINE;
            return s;
        }

    }
}
