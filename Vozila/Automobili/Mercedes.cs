
using Rent_A_Car.Other;
using System;
using System.Collections.Generic;

namespace Rent_A_Car.Vozila.Automobili {
    internal sealed class Mercedes : Automobil {
        public Mercedes(
            int id,
            string model,
            double potrosnja,
            double kilometraza,
            TipKaroserije karoserija
        ) : base(id, model, potrosnja, kilometraza, karoserija) { }

        public Mercedes(
            int id,
            string model,
            double potrosnja,
            double kilometraza,
            TipKaroserije karoserija,
            List<Tuple<DateTime, DateTime>> rezervacije
        ) : base(id, model, potrosnja, kilometraza, karoserija, rezervacije) { }

        public Mercedes(
            int id,
            string model,
            double potrosnja,
            double kilometraza,
            TipKaroserije karoserija,
            List<Oprema> oprema
        ) : base(id, model, potrosnja, kilometraza, karoserija, oprema) { }

        public Mercedes(
            int id,
            string model,
            double potrosnja,
            double kilometraza,
            TipKaroserije karoserija,
            List<Oprema> oprema,
            List<Tuple<DateTime, DateTime>> rezervacije
        ) : base(id, model, potrosnja, kilometraza, karoserija, oprema, rezervacije) { }

        public override double CenaPoDanu() {
            double cena = PocetnaCena();
            double pocetnaCena = PocetnaCena();

            if (Kilometraza < Constants.MERCEDES_KILOMETRAZA_MANJE_OD) {
                cena = Calculation.PrimeniProcenatNaIznos(cena, pocetnaCena, Constants.UVECANJE_CENE_MANJA_KILOMETRAZA_MERCEDES, true);
            }

            if (Karoserija == TipKaroserije.LIMUZINA) {
                cena = Calculation.PrimeniProcenatNaIznos(cena, pocetnaCena, Constants.UVECANJE_CENE_LIMUZINA_MERCEDES, true);
            }

            if (Karoserija == TipKaroserije.HECBEK && Kilometraza > Constants.MERCEDES_KILOMETRAZA_VECE_OD) {
                cena = Calculation.PrimeniProcenatNaIznos(cena, pocetnaCena, Constants.UMANJENJE_CENE_MERCEDES_HECBEK_KILOMETRAZA, false);
            }

            cena += CenaOpreme();

            return cena;
        }

        public override string ToString() {
            return base.ToString() + "Marka: Mercedes" + Environment.NewLine + Constants.LINE + Environment.NewLine;
        }
    }
}
