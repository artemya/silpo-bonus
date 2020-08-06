using System;
using System.Collections.Generic;
using System.Linq;

namespace SilpoBonusCore.checkout
{
    public class FactorByCategoryOffer : AnyGoodsOffer
    {
        public Category category;
        public int factor;

        public FactorByCategoryOffer(Category category, int factor) : base(0, 0)
        {
            this.category = category;
            this.factor = factor;
        }

    }
}