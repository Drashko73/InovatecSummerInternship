
namespace Rent_A_Car.Vozila.Automobili {
    internal sealed class AutomobilCreator {

        public Automobil KreirajAutomobil(
            int id,
            string marka,
            string model,
            double potrosnja,
            double kilometraza,
            TipKaroserije karoserija
        ) {
            switch (marka.Trim().ToLower()) {
                case "mercedes":
                    return new Mercedes(id, model, potrosnja, kilometraza, karoserija);
                case "bmw":
                    return new BMW(id, model, potrosnja, kilometraza, karoserija);
                case "peugeot":
                    return new Peugeot(id, model, potrosnja, kilometraza, karoserija);
                default:
                    throw new System.ArgumentException("Neispravna marka automobila.");
            }
        }

    }
}
