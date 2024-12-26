
using Rent_A_Car.Other;
using System;
using System.Collections.Generic;

namespace Rent_A_Car.Vozila.Motori {
    internal sealed class Yamaha : Motor {
        public Yamaha(
            int id,
            string model,
            double potrosnja,
            double kubikaza,
            double snaga,
            TipMotora tip
        ) : base(id, model, potrosnja, kubikaza, snaga, tip) { }

        public Yamaha(
            int id,
            string model,
            double potrosnja,
            double kubikaza,
            double snaga,
            TipMotora tip,
            List<Tuple<DateTime, DateTime>> rezervacije
        ) : base(id, model, potrosnja, kubikaza, snaga, tip, rezervacije) { }

        public override double CenaPoDanu() {
            double pocetnaCena = PocetnaCena();
            double cena = PocetnaCena();

            cena = Calculation.PrimeniProcenatNaIznos(cena, pocetnaCena, Constants.YAMAHA_UVECANJE_CENE_START, true);

            if (Snaga > Constants.YAMAHA_SNAGA) {
                cena = Calculation.PrimeniProcenatNaIznos(cena, pocetnaCena, Constants.YAMAHA_UVECANJE_CENE_SNAGA, true);
            }
            else {
                cena = Calculation.PrimeniProcenatNaIznos(cena, pocetnaCena, Constants.YAMAHA_UMANJENJE_CENE_SNAGA, false);
            }

            if (Tip == TipMotora.HERITAGE) {
                cena += Constants.YAMAHA_HERITAGE_UVECANJE_CENE;
            }
            else if (Tip == TipMotora.SPORT) {
                cena += Constants.YAMAHA_SPORT_UVECANJE_CENE;
            }
            else {
                cena -= Constants.YAMAHA_TIP_DEFAULT_UMANJENJE_CENE;
            }

            return cena;
        }

        public override string ToString() {
            return base.ToString() + "Marka: Yamaha" + Environment.NewLine + Constants.LINE + Environment.NewLine;
        }
    }
}
