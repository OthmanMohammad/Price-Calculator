using System.ComponentModel;

namespace PriceCalculator
{
    public class DiscountAfterCap: ICalculateCap
    {
        private readonly Cap cap;
        public DiscountAfterCap(Cap cap)
        {
            this.cap = cap;
        }
        public void Calculate(IProduct product)
        {
            cap.Amount = cap.CapType == CapType.Percentage 
                ? new Amount(cap.Value * product.Price.Value / 100)
                : new Amount(cap.Value);
            product.TotalDiscount = product.TotalDiscount.Value > cap.Value
                ? new Amount(cap.Value)
                : new Amount(product.TotalDiscount.Value);
        }
    }
}
