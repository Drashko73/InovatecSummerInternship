
using System;

namespace Rent_A_Car.Rezervacije {
    /// <summary>
    /// Klase koja predstavlja zahtev za rezervaciju vozila.
    /// </summary>
    internal sealed class RezervacijaZahtev : Rezervacija {
        public DateTime DatumDolaska { get; private set; }

        public RezervacijaZahtev(
            int voziloId,
            int kupacId,
            DateTime pocetakRezervacije,
            DateTime krajRezervacije, DateTime datumDolaska
        ) : base(voziloId, kupacId, pocetakRezervacije, krajRezervacije) {
            DatumDolaska = datumDolaska;
        }

        public override string ToString() {
            return $"VoziloId: {VoziloId}, KupacId: {KupacId}, PocetakRezervacije: {PocetakRezervacije}, KrajRezervacije: {KrajRezervacije}, DatumDolaska: {DatumDolaska}";
        }
    }
}
