using System;
using System.Collections.Generic;
using System.Linq;

namespace SilpoBonusCore.checkout
{
    public class FactorByCategoryOffer : Offer
    {
        public Category category;
        public int factor;

        public FactorByCategoryOffer(Category category, int factor, DateTime outflowDate) : base(outflowDate)
        {
            this.category = category;
            this.factor = factor;
        }

        public override void apply(Check check)
        {
            int points = check.GetCostByCategory(category);
            check.AddPoints(points * (factor - 1)); 
        }
    }
}