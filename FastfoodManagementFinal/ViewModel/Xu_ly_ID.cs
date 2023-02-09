using FastfoodManagementFinal.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Runtime.CompilerServices;
using System.Windows;
using Microsoft.Office.Interop.Excel;

namespace FastfoodManagementFinal.ViewModel
{
    public static class Xu_ly_ID
    {
        public static SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["FastFoodDataBase"].ConnectionString);
        public static string GetStaffID(string accessright)
        {
            List<Account> acc = new List<Account>();
            if (con.State != ConnectionState.Open)
            {
                con.Open();
                string sql = "select * from staff where acessRight = N'"+accessright+"' order by ID asc";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Account a = new Account();
                    a.StaffID = reader.GetString(0);
                    a.Avatar = reader.GetString(1);
                    a.AccessRight = reader.GetString(2);
                    a.Username = reader.GetString(3);
                    a.Pass = reader.GetString(4);
                    a.Name = reader.GetString(5);
                    a.Sex = reader.GetString(6);
                    a.DateOfBirth = reader.GetDateTime(7);
                    a.Phone_Number = reader.GetString(8);
                    a.Email = reader.GetString(9);
                    a.address = reader.GetString(10);
                    acc.Add(a);
                }
                con.Close();
            }
            string prefix = "NV";
            if(accessright=="Quản lý")
            {
                prefix = "QL";
            }
            for (int i=0; i< acc.Count - 1;i++)
            {
                int pre = int.Parse(acc[i].StaffID.Substring(2, 3));
                //int next = int.Parse(acc[i + 1].StaffID.Substring(2, 3));
                if (pre - i > 1)
                {
                    return prefix + (i+1).ToString().PadLeft(3, '0');
                }
            }
            return prefix + (acc.Count + 1).ToString().PadLeft(3, '0');
            
        }
        public static string GetProductID()
        {
            List<Product> p = new List<Product>();
            if (con.State != ConnectionState.Open)
            {
                con.Open();
                string sql = "select * from Products order by productID asc ";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Product product = new Product();
                    product.ProductId = reader.GetString(0);
                    product.Name = reader.GetString(1);
                    product.Product_Type = reader.GetString(2);
                    product.Price = reader.GetInt32(3);
                    product.Remaining_quantity = reader.GetInt32(4);
                    product.description = reader.GetString(5);
                    product.Avatar = reader.GetString(6);
                    p.Add(product);
                }
                con.Close();
            }
            
            for (int i = 0; i < p.Count - 1; i++)
            {
                int pre = int.Parse(p[i].ProductId.Substring(2, 3));
                int next = int.Parse(p[i + 1].ProductId.Substring(2, 3));
                if (pre - i > 1)
                {
                    return "SP" + (i+1).ToString().PadLeft(3, '0');
                }
            }
            return "SP" + (p.Count + 1).ToString().PadLeft(3, '0');
        }
        public static string GetCustomerID()
        {
            List<Customer> csm = new List<Customer>();
            if (con.State != ConnectionState.Open)
            {
                con.Open();
                string sql = "select * from customers order by customerID asc ";
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
                    csm.Add(c);
                }

                con.Close();
            }
            for (int i=0;i<csm.Count-1;i++)
            {
                int pre = int.Parse(csm[i].CustomerID.Substring(2, 3));
                int next = int.Parse(csm[i + 1].CustomerID.Substring(2, 3));
                if(pre - i>1)
                {

                    return "KH" + (i+1).ToString().PadLeft(3, '0');
                }
            }
            return "KH" + (csm.Count+1).ToString().PadLeft(3, '0');
        }

        public static string GetBillID()
        {
            List<Bill> bills = Xu_Ly_SQL.Select_all_Bill();
            for (int i = 0; i < bills.Count-1; i++)
            {
                int pre = int.Parse(bills[i].Bill_ID.Substring(2, 3));
                //int next = int.Parse(bills[i + 1].Bill_ID.Substring(2, 3));
                if (pre - i > 1)
                {
                    return "HD" + (i+1).ToString().PadLeft(3, '0');
                }
            }
            return "HD" + (bills.Count+1).ToString().PadLeft(3, '0');
        }
        public static string GetOrderID(int i, string billID)
        {
            return billID + "_DH" + i.ToString().PadLeft(3, '0');
        }
        public static string GetImportID()
        {
            List<Import> imps = Xu_Ly_SQL.Select_all_Import();
            for (int i = 0; i < imps.Count-1; i++)
            {
                int pre = int.Parse(imps[i].ImportID.Substring(2, 3));
                //int next = int.Parse(imps[i + 1].ImportID.Substring(2, 3));
                if (pre - i > 1)
                {
                    return "NH" + (i+1).ToString().PadLeft(3, '0');
                }
            }
            return "NH" + (imps.Count+1).ToString().PadLeft(3, '0');
        }
        public static string GetImportProductID(int i, string ImportID)
        {
            return ImportID + "_MH" + i.ToString().PadLeft(3, '0');
        }
    }
}
