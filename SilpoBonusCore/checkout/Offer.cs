using System;

namespace SilpoBonusCore.checkout
{
    public abstract class Offer {
        public abstract void apply(Check check);

        public DateTime OutflowDate;

        public Offer(DateTime outflowDate)
        {
            this.OutflowDate = outflowDate;
        }

        public bool NotOutflow()
        {
            bool fl = false;
            if (DateTime.Now <= OutflowDate)
            {
                fl = true;
            }
            else
            {
                fl = false;
            }
            return fl;
        }
    }
}