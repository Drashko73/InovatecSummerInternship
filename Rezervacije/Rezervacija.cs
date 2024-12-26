using System;

namespace Rent_A_Car.Rezervacije {
    /// <summary>
    /// Klasa koja predstavlja rezervaciju vozila.
    /// </summary>
    internal class Rezervacija {
        public int VoziloId { get; protected set; }
        public int KupacId { get; protected set; }
        public DateTime PocetakRezervacije { get; protected set; }
        public DateTime KrajRezervacije { get; protected set; }

        public Rezervacija(int voziloId, int kupacId, DateTime pocetakRezervacije, DateTime krajRezervacije) {
            VoziloId = voziloId;
            KupacId = kupacId;
            PocetakRezervacije = pocetakRezervacije;
            KrajRezervacije = krajRezervacije;
        }

        public override string ToString() {
            return $"VoziloId: {VoziloId}, KupacId: {KupacId}, PocetakRezervacije: {PocetakRezervacije}, KrajRezervacije: {KrajRezervacije}";
        }
    }
}
