using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculator
{
    public class Amount
    {
        public double value { get;}

        public Amount(double value)
        {
            if (value < 0) throw new ArgumentException("Amount can't be less than zero");
            this.value = Math.Round(value, 2, MidpointRounding.AwayFromZero);
        }

    }
}
