using System;

namespace PriceCalculator
{
    public class Amount
    {
        public Currency Currency { get; set; }
        public double Value { get; }
        public Amount(double value)
        {
            if (value < 0) throw new ArgumentException("Amount can not be less than 0");
            Value = Math.Round(value, 4, MidpointRounding.AwayFromZero);
            Currency = new Currency("$", "USD");
        }

        public override string ToString() =>
            $"{Currency.CurrencySymbol}{Value:#0.00}";

    }
}
