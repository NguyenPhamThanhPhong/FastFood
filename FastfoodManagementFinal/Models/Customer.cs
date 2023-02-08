using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastfoodManagementFinal.ViewModel;

namespace FastfoodManagementFinal.Models
{
    public class Customer
    {
        public Customer()
        {

        }
        public static List<Customer> Search_ID_Name(string parameter)
        {
            List<Customer> customers = new List<Customer>();
            string sql = "select * from customers where ( lower(customerID) + lower(fullname) like lower(N'%" + parameter + "%') " +
                "or lower(customerID) like lower(N'%"+parameter+"%') or lower(fullname) like lower(N'%"+parameter+"%') ) and avail = '1'";
            //if (parameter.Length >6)
            //{
            //    string ID = parameter.Substring(0, 5);
            //    string pName = parameter.Substring(6);
            //    sql = "select * from customers where lower(customerID) + lower(fullname) like lower(N'%" + ID + "%" + pName + "%') and avail = '1'";

            //}
            SqlConnection con = Xu_Ly_SQL.con;
            if (con.State != ConnectionState.Open)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Customer c = new Customer();
                    c.CustomerID = reader.GetString(0);
                    c.CustomerName = reader.GetString(1);
                    c.CustomerSex = reader.GetString(2);
                    c.CustomerPhone = reader.GetString(3);
                    c.CustomerTotal = reader.GetInt32(4);
                    c.CustomerRank = reader.GetString(5);
                    c.Address = reader.GetString(6);
                    customers.Add(c);
                }
                con.Close();
            }

            //System.Windows.MessageBox.Show(customers.Count.ToString());

            return customers;
        }
        public static Customer FindAbsolute_ID(string parameter)
        {
            Customer c = new Customer();
            if(parameter.Trim().Length<=5)
            {
                return c;
            }
            SqlConnection con = Xu_Ly_SQL.con;
            string strID = parameter.Substring(0, 5);
            string strName = parameter.Substring(5);
            string sql = "select * from customers where customerID = N'"+strID.Trim()+"' and Fullname = N'"+strName.Trim()+"' and avail = 1 ";
            if (con.State != ConnectionState.Open)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    
                    c.CustomerID = reader.GetString(0);
                    c.CustomerName = reader.GetString(1);
                    c.CustomerSex = reader.GetString(2);
                    c.CustomerPhone = reader.GetString(3);
                    c.CustomerTotal = reader.GetInt32(4);
                    c.CustomerRank = reader.GetString(5);
                    c.Address = reader.GetString(6);
                }
                con.Close();
            }
            return c;
        }
        public override string ToString()
        {
            return this.CustomerID + " " + this.CustomerName ;
        }
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSex { get; set; }
        public string CustomerPhone { get; set; }
        public List<Bill> CustomerBills { get; set; }
        public int CustomerTotal { get; set; }
        public string CustomerRank { get; set; }
        public string Address { get; set; }
    }
}
