using System;
using System.Collections.Generic;
using System.Text;

namespace sdam_stock_assignment
{
    public class mainMenu
    {
        public stockManager stkMgr;
        public transactionLogManager lgMgr;


        public mainMenu(stockManager sm, transactionLogManager lm)
        {
            this.stkMgr = sm;
            this.lgMgr = lm;
        }

        public void AddToStock(string ItemCode, string ItemName, int Quantity, float Price)
        {
           // stockItem stock = stkMgr.AddItem(ItemCode, ItemName, Price, Quantity);
        }


        public void TakeFromStock(string ItemCode, string Person)
        {

        }

        public string InventoryReport()
        {
            return "";

        }

        public string FinancialReport()
        {
            return "";

        }

        public string DisplayTransactionLog()
        {
            return "";

        }

        public string ReportPersonalUsage(string Person)
        {
            return "";
        }

        public Dictionary<string, stockItem> ViewAllItems()
        {
            return stkMgr.GetAll();
        }










    }
}
