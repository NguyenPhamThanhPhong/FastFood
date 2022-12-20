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

    }
}
