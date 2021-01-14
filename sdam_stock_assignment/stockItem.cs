using System;
using System.Collections.Generic;
using System.Text;

namespace sdam_stock_assignment
{
    public class stockItem
    {


        public string ItemCode { get; }
        public string ItemName { get; }
        public float Price { get; }
        public int Quantity { get; }



        public stockItem(string itemCode, string itemName, float price, int quantity)
        {
            this.ItemCode = itemCode;
            this.ItemName = itemName;
            this.Price = price;
            this.Quantity = quantity;
        }






    }
}
