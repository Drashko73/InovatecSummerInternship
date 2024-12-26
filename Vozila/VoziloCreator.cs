
using Rent_A_Car.Vozila.Automobili;
using Rent_A_Car.Vozila.Motori;
using System.Threading;

namespace Rent_A_Car.Vozila {
    internal class VoziloCreator {

        private AutomobilCreator automobilCreator = new AutomobilCreator();
        private MotorCreator motorCreator = new MotorCreator();

        /// <summary>
        /// Metoda koja kreira vozilo na osnovu prosledjenih parametara.
        /// Predstavlja Simple Factory pattern koji kreira objekte na osnovu prosledjenih parametara.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tipVozila"></param>
        /// <param name="marka"></param>
        /// <param name="model"></param>
        /// <param name="potrosnja"></param>
        /// <param name="kubikaza"></param>
        /// <param name="kilometraza"></param>
        /// <param name="snaga"></param>
        /// <param name="tip"></param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException"></exception>
        public Vozilo KreirajVozilo(
            int id,
            string tipVozila,
            string marka,
            string model,
            string potrosnja,
            string kubikaza,
            string kilometraza,
            string snaga,
            string tip
        ) {

            switch (tipVozila.Trim().ToLower()) {
                case "automobil":
                    Automobil automobil;
                    try {
                        double potrosnjaDouble = double.Parse(potrosnja);
                        double kilometrazaDouble = double.Parse(kilometraza);
                        TipKaroserije karoserija = (TipKaroserije)System.Enum.Parse(typeof(TipKaroserije), tip);
                        automobil = automobilCreator.KreirajAutomobil(id, marka, model, potrosnjaDouble, kilometrazaDouble, karoserija);
                    }
                    catch (System.Exception e) {
                        throw new System.ArgumentException("Neispravne vrednosti prilikom kreiranja automobila.", e);
                    }
                    return automobil;
                case "motor":
                    Motor motor;
                    try {
                        double potrosnjaDouble = double.Parse(potrosnja);
                        double kubikazaDouble = double.Parse(kubikaza);
                        double snagaDouble = double.Parse(snaga);
                        TipMotora tipMotora = (TipMotora)System.Enum.Parse(typeof(TipMotora), tip);
                        motor = motorCreator.KreirajMotor(id, marka, model, potrosnjaDouble, kubikazaDouble, snagaDouble, tipMotora);
                    }
                    catch (System.Exception e) {
                        throw new System.ArgumentException("Neispravne vrednosti prilikom kreiranja motora.", e);
                    }
                    return motor;
                default:
                    throw new System.ArgumentException("Neispravan tip vozila.");
            }

        }

    }
}
