
using Rent_A_Car.Other;
using System;
using System.Collections.Generic;

namespace Rent_A_Car.Vozila.Automobili {
    internal sealed class Peugeot : Automobil {
        public Peugeot(
            int id,
            string model,
            double potrosnja,
            double kilometraza,
            TipKaroserije karoserija
        ) : base(id, model, potrosnja, kilometraza, karoserija) { }

        public Peugeot(
            int id,
            string model,
            double potrosnja,
            double kilometraza,
            TipKaroserije karoserija,
            List<Tuple<DateTime, DateTime>> rezervacije
        ) : base(id, model, potrosnja, kilometraza, karoserija, rezervacije) { }

        public Peugeot(
            int id,
            string model,
            double potrosnja,
            double kilometraza,
            TipKaroserije karoserija,
            List<Oprema> oprema
        ) : base(id, model, potrosnja, kilometraza, karoserija, oprema) { }

        public Peugeot(
            int id,
            string model,
            double potrosnja,
            double kilometraza,
            TipKaroserije karoserija,
            List<Oprema> oprema,
            List<Tuple<DateTime, DateTime>> rezervacije
        ) : base(id, model, potrosnja, kilometraza, karoserija, oprema, rezervacije) { }

        public override double CenaPoDanu() {
            double pocetnaCena = PocetnaCena();
            double cena = PocetnaCena();

            if (Karoserija == TipKaroserije.LIMUZINA) {
                cena = Calculation.PrimeniProcenatNaIznos(cena, pocetnaCena, Constants.PEUGEOT_LIMUZINA_UVECANJE_CENE, true);
            }
            else if (Karoserija == TipKaroserije.KARAVAN) {
                cena = Calculation.PrimeniProcenatNaIznos(cena, pocetnaCena, Constants.PEUGEOT_KARAVAN_UVECANJE_CENE, true);
            }
            else {
                cena = Calculation.PrimeniProcenatNaIznos(cena, pocetnaCena, Constants.PEUGEOT_DEFAULT_SMANJENJE_CENE, false);
            }

            cena += CenaOpreme();

            return cena;
        }

        public override string ToString() {
            return base.ToString() + "Marka: Peugeot" + Environment.NewLine + Constants.LINE + Environment.NewLine;
        }
    }
}
