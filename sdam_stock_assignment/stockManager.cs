using System;
using System.Collections.Generic;
using System.Text;

namespace sdam_stock_assignment
{
    public class stockManager
    {
        private Dictionary<string, stockItem> stocks = new Dictionary<string, stockItem>();

        public stockItem[] Items;
            
        public void RemoveItem(string ItemCode)
            {

            }

        public void AddItem(stockItem stockitem)
        {
            stocks.Add(stockitem.ItemCode, stockitem);
        }

        public Dictionary<string, stockItem> GetAll()
        {
            return stocks;
        }






    }
}
