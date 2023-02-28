using System;
using System.Collections.Generic;
using System.Linq;

namespace PriceCalculator
{
    public class Products
    {

        public IEnumerable<IProduct> ContainedProducts { get; }
        public IEnumerable<UpcDiscounts> UpcDiscounts { get; set; } = Enumerable.Empty<UpcDiscounts>();

        private ITaxCalculate taxCalculate;
        private ICalculateDiscount calculateDiscount;
        private ICalculateExpense calculateExpense;
        public Expenses Expenses { get; set; }
        private readonly IResult result;
        public Products(IEnumerable<IProduct> products)
        {
            ContainedProducts = products.ToList();
            calculateDiscount = new DiscountCalculate(new Discount(0)
            , Enumerable.Empty<UpcDiscounts>());
            result = new DisplayConsole();
            calculateExpense = new ExpenseCalculator(new Expenses());
        }

        public Products WithTax(Tax tax)
        {

            taxCalculate = new TaxCalculate(tax);
            return this;
        }
        public Products WithDiscount(Discount discount, IEnumerable<UpcDiscounts> upcDiscounts = null)
        {

            UpcDiscounts = upcDiscounts ?? Enumerable.Empty<UpcDiscounts>();
            calculateDiscount = new DiscountCalculate(discount, UpcDiscounts);
            return this;
        }
        public Products WithExpense(Expenses expenses)
        {
            Expenses = expenses;
            calculateExpense = new ExpenseCalculator(Expenses);
            return this;
        }


        public void DisplayResult()
        {

            ContainedProducts.Each(s =>
            {
                taxCalculate.CalculateTax(s, calculateDiscount.CalculateAddionalDiscount);
                calculateDiscount?.CalculateAddDiscount(s);

                s.FinalPrice = new Amount(s.Price.Value + s.TotalTax.Value - s.TotalDiscount.Value - s.AddionalDiscount.Value);
                s.TotalDiscount = new Amount(s.TotalDiscount.Value + s.AddionalDiscount.Value);
                calculateExpense.Calculate(s);
                result.Display(s);
            });
        }
    }
}
