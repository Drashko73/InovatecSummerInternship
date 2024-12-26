
using System.Diagnostics;

namespace Rent_A_Car.Other {
    internal sealed class Calculation {

        /// <summary>
        /// Primenjuje procenat na iznos i vraca rezultat.
        /// </summary>
        /// <param name="iznos">Iznos na koji se primenjuje procenat.</param>
        /// <param name="osnovica">Osnovica za izracunavanje procenata.</param>
        /// <param name="procenat">Procenat koji se primenjuje na iznos.</param>
        /// <param name="uvecaj">Ako je true, iznos se uvecava za procenat. Ako je false, iznos se umanjuje za procenat.</param>
        /// <returns>Rezultat primene procenata na iznos.</returns>
        public static double PrimeniProcenatNaIznos(double iznos, double osnovica, double procenat, bool uvecaj) {
            Debug.Assert(procenat >= 0 && procenat <= 100, "Procenat mora biti izmedju 0 i 100.");

            if (uvecaj) return iznos + osnovica * (procenat / 100);

            return iznos - osnovica * (procenat / 100);
        }
    }
}
