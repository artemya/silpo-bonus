using System;

namespace SilpoBonusCore.checkout
{
    public class AnyGoodsOffer : Offer
    {
        public int totalCost;
        public int points;
        public AnyGoodsOffer(int totalCost, int points, DateTime outflowDate) : base(outflowDate)
        {
            this.totalCost = totalCost;
            this.points = points;
        }
        public override void apply(Check check)
        {
            if (totalCost <= check.GetTotalCost()) {
                check.AddPoints(points);
            }
        }
    }
}