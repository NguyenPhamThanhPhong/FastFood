using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastfoodManagementFinal.Models
{
    public class Bill
    {
        //public Bill(int ordinal_number,string CustomerID_CustomerName,string StaffID,DateTime Bill_Time, int Bill_Discount, List<Order> orders, string Payment_status)
        //{
        //    this.Bill_ID = CustomerID_CustomerName + StaffID + Bill_Time.Date + ordinal_number;
        //    this.Bill_CustomerID_CustomerName = CustomerID_CustomerName;
        //    this.StaffID = StaffID;
        //    this.Bill_Time = Bill_Time;
        //    this.Bill_Discount = Bill_Discount;
        //    this.orders = orders;
        //    this.Bill_Total = 0;
        //    foreach(var order in orders)
        //    {
        //        this.Bill_Total += order.Order_Total;
        //    }
        //    this.Bill_Total *= this.Bill_Discount / 100;
        //    this.Payment_status = Payment_status;
        //}
        public Bill()
        {

        }

        public string Bill_ID { get; set; }
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string StaffID { get; set; }
        public string StaffName { get; set; }
        public DateTime Bill_Time { get; set; }
        public int Bill_Discount { get; set; }
        public int Bill_Total { get; set; }
        public List<Order> orders { get; set; }
        //public string Payment_status { get; set; }
    }
}
