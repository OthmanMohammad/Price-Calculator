using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculator
{
    public class Tax
    {
        public readonly int Percent;
        public double TaxRate { get;}
        public Tax(int percent)
        {
            if (percent < 0 || percent > 100)
                throw new ArgumentOutOfRangeException(
                    nameof(percent),
                    $"{nameof(Tax)} percentage should be greater than 0 and less than 100");

            this.Percent = percent;
            TaxRate = (double)Percent / 100;
        }
        public override string ToString() => $"{Percent}%";
    }
}
