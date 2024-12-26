
using System;
using System.Collections.Generic;

namespace Rent_A_Car.Vozila.Automobili {

    public enum TipKaroserije {
        LIMUZINA,
        HECBEK,
        KARAVAN,
        KUPE,
        KABRIOLET,
        MINIVAN,
        SUV,
        PICKUP
    }

    /// <summary>
    /// Specijalizacija klase Vozilo za automobile.
    /// </summary>
    internal abstract class Automobil : Vozilo {
        public double Kilometraza { get; private set; }
        public TipKaroserije Karoserija { get; private set; }
        public List<Oprema> Oprema { get; set; }

        public Automobil(int id, string model, double potrosnja, double kilometraza, TipKaroserije karoserija) : base(id, model, potrosnja) {
            Kilometraza = kilometraza;
            Karoserija = karoserija;
            Oprema = new List<Oprema>();
        }

        public Automobil(int id, string model, double potrosnja, double kilometraza, TipKaroserije karoserija, List<Tuple<DateTime, DateTime>> rezervacije) : base(id, model, potrosnja, rezervacije) {
            Kilometraza = kilometraza;
            Karoserija = karoserija;
            Oprema = new List<Oprema>();
        }

        public Automobil(int id, string model, double potrosnja, double kilometraza, TipKaroserije karoserija, List<Oprema> oprema) : base(id, model, potrosnja) {
            Kilometraza = kilometraza;
            Karoserija = karoserija;
            Oprema = oprema;
        }

        public Automobil(int id, string model, double potrosnja, double kilometraza, TipKaroserije karoserija, List<Oprema> oprema, List<Tuple<DateTime, DateTime>> rezervacije) : base(id, model, potrosnja, rezervacije) {
            Kilometraza = kilometraza;
            Karoserija = karoserija;
            Oprema = oprema;
        }

        /// <summary>
        /// Metoda za dodavanje opreme u listu opreme.
        /// </summary>
        /// <param name="oprema"></param>
        public void DodajOpremu(Oprema oprema) {
            Oprema.Add(oprema);
        }

        /// <summary>
        /// Metoda koja racuna cenu svih delova opreme koji se nalaze na automobilu.
        /// </summary>
        /// <returns></returns>
        public double CenaOpreme() {
            double cena = 0;
            foreach (Oprema oprema in Oprema) {
                if (oprema.PovecavaCenu) cena += oprema.Cena;
                else cena -= oprema.Cena;
            }
            return cena;
        }

        public override double PocetnaCena() {
            return Constants.POCETNA_CENA_PO_DANU_AUTOMOBIL;
        }

        public override string ToString() {
            string s = base.ToString();
            s += "Vrsta:Automobil" + Environment.NewLine +
                    "Potrosnja:" + Potrosnja + "l" + Environment.NewLine +
                    "Kilometraza:" + Kilometraza + "km" + Environment.NewLine +
                    "Karoserija:" + Karoserija + Environment.NewLine;
            s += "\tOprema (Id, Naziv, Cena, PovecavaCenu):" + Environment.NewLine;
            foreach (Oprema o in Oprema) {
                s += "\t" + o + Environment.NewLine;
            }
            return s;
        }

    }
}
