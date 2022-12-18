using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastfoodManagementFinal.Models
{
    public class Order
    {
        //public Order(string Bill_ID, string order_Name, Product P, int order_Sell_Quantity, int order_Discount)
        //{
        //    this.Bill_ID = Bill_ID;
        //    Order_ID = Bill_ID + P.ProductId;
        //    Order_Name = order_Name;
        //    Order_Product_ID = P.ProductId;
        //    Order_Product_Name = P.Name;
        //    Order_Product_Price = P.Price;
        //    Order_Sell_Quantity = order_Sell_Quantity;
        //    Order_Discount = order_Discount;
        //    Order_Total = Order_Product_Price*order_Sell_Quantity*Order_Discount;
        //}
        public Order()
        {

        }
        public string Bill_ID { get; set; }
        public string Order_ID { get; set; }
        public string Order_Product_ID { get; set; }
        public string Order_Product_Name { get;set; }
        public int Order_Product_Price { get; set; }
        public int Order_Sell_Quantity { get; set; }
        public int Order_Total { get; set; }
        public int Order_Discount { get; set; }
    }
}
