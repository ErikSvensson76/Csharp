using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Products;

namespace VendingMachine
{
    class VendingMachineManagement : VendingMachineManagementInterface
    {
        private bool session;
        private VendingMachine vendingMachine { get; }
        
        public VendingMachineManagement()
        {
            vendingMachine = new VendingMachine();
        }

        public void ActivateSession()
        {
            session = true;
        }

        public bool InsertMoney(int index)
        {
            return vendingMachine.SetMoneyPool(index);
        }

        public Product PurchaseProduct()
        {
            Product chosenProduct;
            int selection;
            ShowAllProducts();
            while (true)
            {
                Console.WriteLine("-1 to abort");
                selection = SelectProduct();
                if(selection < 0)
                {
                    return null;
                }
                chosenProduct = vendingMachine.PurchaseProduct(selection);
                
                
                if(chosenProduct != null)
                {
                    return chosenProduct;
                }
            }
        }

        private void ShowAllProducts()
        {
            for(int i = 0; i < vendingMachine.NumberOfProducts(); i++)
            {
                Console.WriteLine("Selection " + (i + 1) + ":");
                Console.WriteLine(vendingMachine.GetProduct(i));
            }
        }

        

        public int ReturnChange()
        {
            return vendingMachine.WithDrawMoney();
        }

        private int SelectProduct()
        {
            //If TryParse fails selection remains at default -100 which is not valid
            int selection = -100;
            while (true)
            {

                int.TryParse(Console.ReadLine(), out selection);
               
                if(selection == 0)
                {
                    Console.WriteLine("Invalid input");
                }
                else
                {
                    //To get user input zero indexed
                    selection --;
                    return selection;
                }
            }
            
        }

        public int GetMoney()
        {
            return vendingMachine.GetMoneyPool();
        }

        public bool SessionRunning()
        {
            return this.session;
        }

        public void DeactivateSession()
        {
            this.session = false;
        }

        public string ValidOptions()
        {
            string validOptions = "";
            validOptions += "-----------------------------\n";

            int[] values = vendingMachine.GetMoneyDenominations();
            for(int option = 0; option < values.Length; option++)
            {
                validOptions += (option + 1) + ".\tDeposit " + values[option] + " kr\n";

            }
            validOptions += "-----------------------------";
            return validOptions;
        }
    }
}
