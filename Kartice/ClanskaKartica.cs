
namespace Rent_A_Car.Kartice {
    internal abstract class ClanskaKartica {

        /// <summary>
        /// Metoda koja vraca popust koji korisnik ostvaruje sa odredjenom karticom
        /// </summary>
        /// <returns></returns>
        public abstract double DajPopust();

        /// <summary>
        /// Preklopljen operator > koji poredi dva objekta klase ClanskaKartica
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns></returns>
        public static bool operator >(ClanskaKartica c1, ClanskaKartica c2) {
            return c1.DajPopust() > c2.DajPopust();
        }

        /// <summary>
        /// Preklapanje operatora < koji poredi dva objekta klase ClanskaKartica
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns></returns>
        public static bool operator <(ClanskaKartica c1, ClanskaKartica c2) {
            return c1.DajPopust() < c2.DajPopust();
        }

    }
}
