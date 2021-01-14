using System;
using System.Collections.Generic;
using System.Text;

namespace sdam_stock_assignment
{
    public class transactionLogEntry
    {
        private DateTime Date;
        private string ItemCode;
        private string ItemName;
        private string Type;

        public void TransactionLogEntry(DateTime date, string itemcode, string itemname, string type)
        {
            this.Date = date;
            this.ItemCode = itemcode;
            this.ItemName = itemname;
            this.Type = type;
 
        }



    }
}
