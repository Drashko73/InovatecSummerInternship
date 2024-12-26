
using Rent_A_Car.Other;
using System;
using System.Collections.Generic;

namespace Rent_A_Car.Vozila.Motori {
    internal sealed class Harley : Motor {

        public Harley(
            int id,
            string model,
            double potrosnja,
            double kubikaza,
            double snaga,
            TipMotora tip
        ) : base(id, model, potrosnja, kubikaza, snaga, tip) { }

        public Harley(
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

            cena = Calculation.PrimeniProcenatNaIznos(cena, pocetnaCena, Constants.HARLEY_UVECANJE_CENE_START, true);

            if (Kubikaza > Constants.HARLEY_KUBIKAZA) {
                cena = Calculation.PrimeniProcenatNaIznos(cena, pocetnaCena, Constants.HARLEY_UVECANJE_CENE_KUBIKAZA, true);
            }
            else {
                cena = Calculation.PrimeniProcenatNaIznos(cena, pocetnaCena, Constants.HARLEY_UMANJENJE_CENE_KUBIKAZA, false);
            }

            return cena;
        }

        public override string ToString() {
            return base.ToString() + "Marka: Harley" + Environment.NewLine + Constants.LINE + Environment.NewLine;
        }
    }
}
