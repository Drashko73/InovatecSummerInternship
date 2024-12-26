
namespace Rent_A_Car.Vozila.Motori {
    internal sealed class MotorCreator {

        public Motor KreirajMotor(
            int id,
            string marka,
            string model,
            double potrosnja,
            double kubikaza,
            double snaga,
            TipMotora tip
        ) {
            switch (marka.Trim().ToLower()) {
                case "harley":
                    return new Harley(id, model, potrosnja, kubikaza, snaga, tip);
                case "yamaha":
                    return new Yamaha(id, model, potrosnja, kubikaza, snaga, tip);
                default:
                    throw new System.ArgumentException("Neispravna marka motora.");
            }
        }

    }
}
