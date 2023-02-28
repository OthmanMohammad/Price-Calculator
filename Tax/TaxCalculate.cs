using System;
using System.Collections.Generic;
using System.Linq;

namespace PriceCalculator
{
    class TaxCalculate : ITaxCalculate
    {

        public Tax tax { get; }

        public Amount Amount { get; set; }

        public TaxCalculate(Tax tax)
        {

            this.tax = tax ?? throw new ArgumentNullException(nameof(tax));
        }

        public override string ToString() =>
            $"Tax = {tax}";

        public void CalculateTax(IProduct product, Func<IProduct, Amount> additonaldiscount)
        {
            var price = new Amount(product.Price.Value - additonaldiscount(product).Value);
            product.TotalTax = new Amount(price.Value * tax.TaxRate);
            product.Tax = tax;
            product.FinalPrice = price;
        }
    }
}
