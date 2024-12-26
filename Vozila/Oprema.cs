
namespace Rent_A_Car.Vozila {
    internal sealed class Oprema {
        public int Id { get; private set; }
        public string Naziv { get; private set; }
        public double Cena { get; private set; }
        public bool PovecavaCenu { get; private set; }

        public Oprema(int id, string naziv, double cena, bool povecavaCenu) {
            Id = id;
            Naziv = naziv;
            Cena = cena;
            PovecavaCenu = povecavaCenu;
        }

        public override string ToString() {
            return $"{Id} {Naziv} {Cena}e {PovecavaCenu}";
        }
    }
}
