
namespace Rent_A_Car {
    /// <summary>
    /// Interfejs koji sadrzi metode za simuliranje rezervacije, ispis vozila sa cenom, ispis kupaca, ispis prethodnih rezervacija i ispis zahteva za rezervacijom.<br></br>
    /// Koristi se kako bi se izdvojile metode koje se koriste za rezervaciju i na taj nacin poboljsala organizacija koda.
    /// </summary>
    internal interface IReservation {
        void SimulirajRezervaciju();
        void IspisiVozilaSaCenom();
        void IspisiKupce();
        void IspisiPrethodneRezervacije();
        void IspisiZahteveZaRezervacijom();
    }
}
