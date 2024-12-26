using System;

namespace Rent_A_Car {
    internal class Program {

        static void Main(string[] args) {

            // Pristup omogucen preko interfejsa kako bi se ogranicila upotreba metoda klase Simulator i omogucila zamena klase
            // Simulator nekom drugom klasom koja implementira interfejs IReservation bez potrebe za menjanjem ostatka koda.
            IReservation simulator = new Simulator();

            simulator.IspisiVozilaSaCenom();
            simulator.IspisiKupce();

            simulator.SimulirajRezervaciju();

            Console.WriteLine();
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
