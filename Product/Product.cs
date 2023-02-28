using System.Linq;

namespace PriceCalculator
{

    public class Product : IProduct
    {
        public string Name { get; }
        public int Upc { get; }
        public Amount Price { get; }
        public Amount TotalTax { get; set; }
        public Amount TotalDiscount { get; set; }
        public Amount AddionalDiscount { get; set; } 
        public Cap Cap { get; set; }
        public Amount FinalPrice { get; set; } = new Amount(0);
        public Tax Tax { get; set; }
        public Discount Discount { get; set; }
        public Expenses Expenses { get; set; }

        public Product(string name, int upc, Amount amount)
        {
            Name = name;
            Upc = upc;
            Price = amount;
            Expenses = new Expenses();
        }

        public override string ToString() =>
            $"Product Name {Name} UPC {Upc} Price {Price}";
    }
}
