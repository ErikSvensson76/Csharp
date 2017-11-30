using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products
{
    class Snack : Product
    {
        public Snack(int price, string productName) : base(price, productName){}

        public override void Use()
        {
            Console.WriteLine("You are eating and enjoying your" + productName);
        }
    }
}
