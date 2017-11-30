using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products
{
    class Drink : Product
    {
        public Drink(int price, string productName) : base(price, productName){ }

        public override void Use()
        {
            Console.WriteLine("You are drinking your refreshing " + productName);
        }
    }
}
