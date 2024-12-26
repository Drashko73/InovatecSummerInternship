
namespace Rent_A_Car.Kartice {
    internal sealed class VipClanskaKartica : ClanskaKartica {
        public override double DajPopust() {
            return Constants.VIP_CLANSKA_KARTICA_POPUST;
        }

        public override string ToString() {
            return "VIP (" + Constants.VIP_CLANSKA_KARTICA_POPUST + "% popusta)";
        }
    }
}
