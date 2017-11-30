using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Products; 
namespace VendingMachine
{
    
    class VendingMachine
    {
        //Money denominations
        private int[] moneyDenominations = { 1, 5, 10, 20, 50, 100, 500, 1000 };

        //List of all available products for sale
        private List<Product> inventory = new List<Product>(); 

        //This is the sum of all moneyinsertions during session
        private int moneyPool { get; set; }

        

        public VendingMachine()
        {
            
            initInventory();
        }

        private void initInventory()
        {
            inventory.Add(new Snack(15, "Chocolate bar"));
            inventory.Add(new Snack(25, "Cake"));
            inventory.Add(new Food(55, "Hamburger"));
            inventory.Add(new Food(75, "Pizza"));
            inventory.Add(new Fruit(10, "Apple"));
            inventory.Add(new Fruit(12, "Banana"));
            inventory.Add(new Drink(15, "Coffee"));
            inventory.Add(new Drink(45, "Beer"));
            inventory.Add(new Drink(20, "Soda"));
            
        }

        public Product PurchaseProduct(int index)
        {
            if(index >= inventory.Count())
            {
                Console.WriteLine("That item does not exist");
                return null;
            }
            Product temp = inventory[index];

            if(temp.GetPrice() > moneyPool)
            {
                Console.WriteLine(temp.GetProductName() + " costs " + temp.GetPrice() + " kr. You only have " + moneyPool + " kr.");
                return null;
            }
            else
            {
                moneyPool -= temp.GetPrice();
                Console.WriteLine(temp.GetPrice() + " withdrawn. " + temp.GetProductName() + " purchased");
                return temp;
            }
        }

        public int GetMoneyPool()
        {
            return this.moneyPool;
        }

        public void SetMoneyPool(int index)
        {
            moneyPool += moneyDenominations[index];
            Console.WriteLine(moneyDenominations[index] + " kr inserted.");
        }






        


        
       
    }
}
