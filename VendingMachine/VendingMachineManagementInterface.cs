using Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    interface VendingMachineManagementInterface
    {
        bool InsertMoney(int index);
        Product PurchaseProduct();
        bool SessionRunning();
        void ActivateSession();
        void DeactivateSession();
        int ReturnChange();
        string ValidOptions();
        int GetMoney();

    }
}
