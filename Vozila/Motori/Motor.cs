
using System;
using System.Collections.Generic;

namespace Rent_A_Car.Vozila.Motori {

    public enum TipMotora {
        ADVENTURE,
        HERITAGE,
        TOUR,
        ROADSTER,
        URBANMOBILITY,
        SPORT
    }

    /// <summary>
    /// Specijalizacija klase Vozilo za motore.
    /// </summary>
    internal abstract class Motor : Vozilo {
        public double Kubikaza { get; private set; }
        public double Snaga { get; private set; }
        public TipMotora Tip { get; private set; }

        public Motor(int id, string model, double potrosnja, double kubikaza, double snaga, TipMotora tip) : base(id, model, potrosnja) {
            Kubikaza = kubikaza;
            Snaga = snaga;
            Tip = tip;
        }

        public Motor(int id, string model, double potrosnja, double kubikaza, double snaga, TipMotora tip, List<Tuple<DateTime, DateTime>> rezervacije) : base(id, model, potrosnja, rezervacije) {
            Kubikaza = kubikaza;
            Snaga = snaga;
            Tip = tip;
        }

        public override double PocetnaCena() {
            return Constants.POCETNA_CENA_PO_DANU_MOTOR;
        }

        public override string ToString() {
            string s = base.ToString();
            s += "Vrsta:Motor" + Environment.NewLine +
                 "Potrosnja:" + Potrosnja + "l" + Environment.NewLine +
                 "Kubikaza:" + Kubikaza + "cm3" + Environment.NewLine +
                 "Snaga:" + Snaga + "KS" + Environment.NewLine +
                 "Tip:" + Tip + Environment.NewLine;
            return s;
        }
    }
}
