using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products
{
    abstract class Product
    {
        protected int price { get; set; }
        protected string productName { get; set; }

        protected Product(int price, string productName)
        {
            this.price = price;
            this.productName = productName;
        }

        public string Examine()
        {
            return "Product:\t" + productName + "\n" + "Price:\t" + price + " kr\n";
        }

        public int GetPrice()
        {
            return this.price;
        }

        public string GetProductName()
        {
            return this.productName;
        }

        public abstract void Use();
    }
}
