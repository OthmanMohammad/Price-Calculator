

namespace PriceCalculator
{
    interface ICalculateDiscount
    {
        void CalculateAddDiscount(IProduct product);
        Amount CalculateAddionalDiscount(IProduct product);
    }

}