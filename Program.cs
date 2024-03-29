using System;
using System.Collections.Generic;
using System.Linq;

namespace PriceCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<UpcDiscounts> upcDiscounts = new List<UpcDiscounts>() { new UpcDiscounts() { Upc = 12345, Discount = new Discount(7) } };
            Console.WriteLine("----------TAX--------");
            //----------TAX--------
            Products products = new Products(new[] { new Product("The Little Prince", 12345, new Amount(20.25)) { } });
            products.WithTax(new Tax(20));
            products.DisplayResult();

            Console.WriteLine("----------Discount--------");
            //---------Discount-----
            products = new Products(new[]
            {
                new Product("The Little Prince", 12345, new Amount(20.25)) { },
                new Product("The Little Prince1", 123, new Amount(20.25)) { }
            });
            
            products.WithTax(new Tax(20))
                    .WithDiscount(new Discount(15),Enumerable.Empty<UpcDiscounts>());
            products.DisplayResult();

            Console.WriteLine("----------Selective--------");
            //---------Selective-----
            products = new Products(new[]
            {
                new Product("The Little Prince", 12345, new Amount(20.25)) { },
                new Product("The Little Prince1", 123, new Amount(20.25)) { }
            });
            products.WithTax(new Tax(20))
                    .WithDiscount(new Discount(15), upcDiscounts);
            products.DisplayResult();

            Console.WriteLine("----------Selective Case 2--------");
            products = new Products(new[]
            {
                new Product("The Little Prince", 12345, new Amount(20.25)) { },
                new Product("The Little Prince1", 789, new Amount(20.25)) { }
            });
            products.WithTax(new Tax(21))
                    .WithDiscount(new Discount(15), new List<UpcDiscounts>() { new UpcDiscounts() { Upc = 789, Discount = new Discount(7) } });
            products.DisplayResult();

            Console.WriteLine("----------Precedance--------");
            products = new Products(new[]
            {
                new Product("The Little Prince", 12345, new Amount(20.25)) { },
            });
            products.WithTax(new Tax(20))
                    .WithDiscount(new Discount(15), new List<UpcDiscounts>() { new UpcDiscounts() { Upc = 12345, Discount = new Discount(7), CanTaxCalculateAfterDiscount = true } })
                    ;
            products.DisplayResult();

            Console.WriteLine("----------Expense--------");
            products = new Products(new[]
            {
                new Product("The Little Prince", 12345, new Amount(20.25)) { },
            });
            var expense = new Expenses();
            expense.AddExpense(
                new Expense()
                {
                    Name = "Packaging",
                    ExpenseType = ExpenseType.Percentage,
                    Value = 1
                });
            expense.AddExpense(
                new Expense()
                {
                    Name = "Transport",
                    ExpenseType = ExpenseType.Monetary,
                    Value = 2.2
                });
            products.WithTax(new Tax(21))
                    .WithDiscount(new Discount(15), new List<UpcDiscounts>() { new UpcDiscounts() { Upc = 12345, Discount = new Discount(7), CanTaxCalculateAfterDiscount = false } })
                    .WithExpense(expense);
            products.DisplayResult();

            Console.WriteLine("----------Expense  2--------");
            products = new Products(new[]
            {
                new Product("The Little Prince", 12345, new Amount(20.25)) { },
            });
            products.WithTax(new Tax(21));
            products.DisplayResult();

            Console.WriteLine("----------Cap--------");
            products = new Products(new[]
           {
                new Product("The Little Prince", 12345, new Amount(20.25)) { },
            });
            var cap = new Cap();
            cap.CapType = CapType.Monetary;
            cap.Value = 20;
            expense = new Expenses();
            expense.AddExpense(
                new Expense()
                {
                    Name = "Packaging",
                    ExpenseType = ExpenseType.Percentage,
                    Value = 1
                });
            expense.AddExpense(
                new Expense()
                {
                    Name = "Transport",
                    ExpenseType = ExpenseType.Monetary,
                    Value = 2.2
                });
            products.WithTax(new Tax(21))
                    .WithDiscount(new Discount(15), new List<UpcDiscounts>() { new UpcDiscounts() { Upc = 12345, Discount = new Discount(7), CanTaxCalculateAfterDiscount = false } })
                    .WithExpense(expense)
                    .WithCap(cap);
                    
            products.DisplayResult();



            Console.ReadKey();
        }
    }
}
