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

namespace FastfoodManagementFinal.ViewModel
{
    public static class Xu_ly_ID
    {
        public static SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["FastFoodDataBase"].ConnectionString);
        public static string GetStaffID(string accessright)
        {
            List<Account> acc = new List<Account>();
            int count = 1;
            if (con.State != ConnectionState.Open)
            {
                con.Open();
                string sql = "select ID from staff order by ID asc";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string MS = reader.GetString(0);
                    bool isHaveMS = false;
                    switch (accessright)
                    {
                        case "Nhân viên":
                            {
                                if (MS.Substring(0, 2).Equals("NV"))
                                {
                                    string numberId = reader.GetString(0).Substring(2);
                                    if (count == int.Parse(numberId))
                                    {
                                        count++;
                                    }
                                    else
                                    {
                                        isHaveMS = true;
                                        break;
                                    }
                                }
                            }
                            break;
                        case "Quản lý":
                            {
                                if (MS.Substring(0, 2).Equals("QL"))
                                {
                                    string numberId = reader.GetString(0).Substring(2);
                                    if (count == int.Parse(numberId))
                                    {
                                        count++;
                                    }
                                    else
                                    {
                                        isHaveMS = true;
                                        break;
                                    }
                                }
                            }
                            break;
                    }

                    if (isHaveMS)
                    {
                        con.Close();
                        break;
                    }
                }
            }
            switch (accessright)
            {
                case "Nhân viên":
                    return "NV" + count.ToString().PadLeft(3, '0');
                case "Quản lý":
                    return "QL" + count.ToString().PadLeft(3, '0');
                default:
                    return "";
            }
        }
        public static string GetProductID()
        {
            List<Account> acc = new List<Account>();
            int count = 1;
            if (con.State != ConnectionState.Open)
            {
                con.Open();
                string sql = "select ProductID from PRODUCTS order by ProductID asc";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string MS = reader.GetString(0);
                    bool isHaveMS = false;
                    if (MS.Substring(0, 2).Equals("SP"))
                    {
                          string numberId = reader.GetString(0).Substring(2);
                          if (count == int.Parse(numberId))
                          {
                              count++;
                          }
                          else
                          {
                              isHaveMS = true;
                              break;
                          }
                    }
                    if (isHaveMS)
                    {
                        con.Close();
                    }
                }
            }
            return "SP" + count.ToString().PadLeft(3, '0');
        }
        public static string GetCustomerID()
        {
            List<Customer> csm = Xu_Ly_SQL.Select_all_Customers();
            for(int i=0;i<csm.Count-1;i++)
            {
                int pre = int.Parse(csm[i].CustomerID.Substring(2, 3));
                int next = int.Parse(csm[i + 1].CustomerID.Substring(2, 3));
                if(next-pre>1)
                {
                    return "KH" + (pre+1).ToString().PadLeft(3, '0');
                }
            }
            return "KH" + (csm.Count+1).ToString().PadLeft(3, '0');
        }
        public static string GetBillID()
        {
            List<Account> acc = new List<Account>();
            int count = 1;
            if (con.State != ConnectionState.Open)
            {
                con.Open();
                string sql = "select BillID from BILL order by BillID asc";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string MS = reader.GetString(0);
                    bool isHaveMS = false;
                    if (MS.Substring(0, 2).Equals("HD"))
                    {
                        string numberId = reader.GetString(0).Substring(2);
                        if (count == int.Parse(numberId))
                        {
                            count++;
                        }
                        else
                        {
                            isHaveMS = true;
                            break;
                        }
                    }
                    if (isHaveMS)
                    {
                        con.Close();
                    }
                }
            }
            return "HD" + count.ToString().PadLeft(3, '0');
        }
        public static string GetOrderID(int i, string billID)
        {
            return billID + "_DH" + i.ToString().PadLeft(3, '0');
        }
        public static string GetImportID()
        {
            List<Account> acc = new List<Account>();
            int count = 1;
            if (con.State != ConnectionState.Open)
            {
                con.Open();
                string sql = "select ImportID from IMPORT order by ImportID asc";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string MS = reader.GetString(0);
                    bool isHaveMS = false;
                    if (MS.Substring(0, 2).Equals("NH"))
                    {
                        string numberId = reader.GetString(0).Substring(2);
                        if (count == int.Parse(numberId))
                        {
                            count++;
                        }
                        else
                        {
                            isHaveMS = true;
                            break;
                        }
                    }
                    if (isHaveMS)
                    {
                        con.Close();
                    }
                }
            }
            return "NH" + count.ToString().PadLeft(3, '0');
        }
        public static string GetImportProductID(int i, string ImportID)
        {
            return ImportID + "_MH" + i.ToString().PadLeft(3, '0');
        }
    }
}
