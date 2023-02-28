using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCalculator
{
    internal interface IProduct
    {
        string Name { get; }
        int Upc { get; }
        Amount Price { get; }
        Tax Tax { get; set; }
        Amount TotalTax { get; set; }
        Amount FinalPrice { get; set; }
    }
}
