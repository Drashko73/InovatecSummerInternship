
namespace Rent_A_Car.Kartice {
    internal sealed class BasicClanskaKartica : ClanskaKartica {
        public override double DajPopust() {
            return Constants.BASIC_CLANSKA_KARTICA_POPUST;
        }

        public override string ToString() {
            return "BASIC (" + Constants.BASIC_CLANSKA_KARTICA_POPUST + "% popusta)";
        }
    }
}
