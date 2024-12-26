
using System;

namespace Rent_A_Car.Kartice {

    internal sealed class KarticaCreator {

        /// <summary>
        /// Metoda koja kreira karticu na osnovu tipa kartice.
        /// Predstavlja Simple Factory Pattern koji kreira objekte na osnovu prosledjenog parametra.
        /// [href=https://refactoring.guru/design-patterns/factory-method]
        /// </summary>
        /// <param name="tipKartice"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public ClanskaKartica NapraviKarticu(string tipKartice) {
            if (tipKartice == null) {
                throw new ArgumentNullException(nameof(tipKartice));
            }

            switch (tipKartice.ToLower().Trim()) {
                case "":
                    return null;                        // nema kartice
                case "basic":
                    return new BasicClanskaKartica();   // basic kartica
                case "vip":
                    return new VipClanskaKartica();     // vip kartica
                default:
                    throw new ArgumentException("Nepoznat tip kartice", nameof(tipKartice));    // nepoznat tip kartice
            }
        }

    }
}
