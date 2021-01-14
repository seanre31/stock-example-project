using System;
using System.Collections.Generic;
using System.Text;
using System.Dynamic;
using System.IO;
using System.Runtime.CompilerServices;

namespace sdam_stock_assignment
{
    public class transactionLogEntryAdd: transactionLogManager
    {
        public float Price;

        public void TransactionLogEntryAdd(float price, DateTime Date, string type, string code, string ItemName, float Price, string Person)
        {
            this.Price = price;
        }



    }
}
