using Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{

    /*
     * CsharpVending machine 
Your assignment for this week is to make a vending machine. It should be able to take requests from the user as to what product it is supposed to return. It should also take payment, and send the product back to the user with an appropriate amount of change.
Required Features:


•	Money should be input in fixed denominations:
        ○ 1kr, 5kr, 10kr, 20kr, 50kr, 100kr, 500kr and 1000kr.
• The user should be able to put any amount of money in, adding to the “money pool”.
• The user should be able to buy any number of products, as long as they have the money for it in the machine. 
• When the user decides to stop buying things, the remaining money should be returned as change.
• The vending machine should have at least three different types of product, such as drinks, snacks, food and so on. 
• Once a product has been purchased, the user should be able to use it, showing a message about how it is used (drink the drink, eat the snack / food, etc…)

Code Requirements:


• Money denominations should be defined as an array of integers.
• Each product type should be its own class.
        ○ These classes should all inherit form the same interface or abstract class, to get the methods they have in common. This base class is the type the vending machine itself should look for.
        ○ The common methods should include at least:
	Purchase, to buy the product
	Examine, to show the product’s price and info
	Use, to put the product to use once it has been purchased (output a message to the console)
     */

    class Program
    {
        private static VendingMachineManagementInterface management = new VendingMachineManagement();

        static void Main(string[] args)
        {
            

            do
            {
                management.ActivateSession();
                Console.WriteLine("****Vending Machine****");
                Console.WriteLine("Money inserted:\t" + management.GetMoney() + " kr");
                printOptions();
                switch (Console.ReadKey(true).KeyChar)
                {
                    case '1':
                        management.InsertMoney(GetDepositSelection());
                        break;
                    case '2':
                        Product prod = management.PurchaseProduct();
                        if(prod != null)
                        {
                            prod.Use();
                        }
                        break;
                    case '3':
                        Console.WriteLine("You got " + management.ReturnChange() + " kr back");
                        break;
                    case '4':
                        management.DeactivateSession();
                        break;
                }
            } while (management.SessionRunning());

        }

        public static int GetDepositSelection()
        {
            int selection = 0;
            Console.WriteLine("These are your options:");
            Console.WriteLine(management.ValidOptions());

            int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out selection);

            return selection;
            

        }

        private static void printOptions()
        {
            Console.WriteLine("1. Insert Coin");
            Console.WriteLine("2. Purchase Product");
            Console.WriteLine("3. Return Change");
            Console.WriteLine("4. Quit session");
        }
    }
}
