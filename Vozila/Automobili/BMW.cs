
using Rent_A_Car.Other;
using System;
using System.Collections.Generic;

namespace Rent_A_Car.Vozila.Automobili {
    internal sealed class BMW : Automobil {
        public BMW(
            int id,
            string model,
            double potrosnja,
            double kilometraza,
            TipKaroserije karoserija
        ) : base(id, model, potrosnja, kilometraza, karoserija) { }

        public BMW(
            int id,
            string model,
            double potrosnja,
            double kilometraza,
            TipKaroserije karoserija,
            List<Tuple<DateTime, DateTime>> rezervacije
        ) : base(id, model, potrosnja, kilometraza, karoserija, rezervacije) { }

        public BMW(
            int id,
            string model,
            double potrosnja,
            double kilometraza,
            TipKaroserije karoserija,
            List<Oprema> oprema
        ) : base(id, model, potrosnja, kilometraza, karoserija, oprema) { }

        public BMW(
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

            if (Potrosnja < Constants.BMW_POTROSNJA_MANJA_OD) {
                cena = Calculation.PrimeniProcenatNaIznos(cena, pocetnaCena, Constants.UVECANJE_CENE_POTROSNJA_BMW, true);
            }
            else if (Potrosnja > Constants.BMW_POTROSNJA_MANJA_OD) {
                cena = Calculation.PrimeniProcenatNaIznos(cena, pocetnaCena, Constants.UMANJENJE_CENE_POTROSNJA_BMW, false);
            }
            else {
                cena = Calculation.PrimeniProcenatNaIznos(cena, pocetnaCena, Constants.UMANJENJE_CENE_POTROSNJA_DEFAULT_BMW, false);
            }

            cena += CenaOpreme();

            return cena;
        }

        public override string ToString() {
            return base.ToString() + "Marka: BMW" + Environment.NewLine + Constants.LINE + Environment.NewLine;
        }
    }
}
