using Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
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
