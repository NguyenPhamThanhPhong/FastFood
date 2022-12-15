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
    public static class Xu_Ly_SQL
    {
        //public static Product Select_Product_specified_ProductID(string productID)
        //{


        //    return product;
        //}

        public static SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["FastFoodDataBase"].ConnectionString);

        public static void Insert_Bill(Bill b)
        {
            
            if (con.State != ConnectionState.Open)
            {
                con.Open();
                string sql = "insert into bill (billID,staffid,customerID,BillDate,Discount,Total) " +
                    "values ('" + b.Bill_ID + "','" + b.StaffID + "','" + b.CustomerID + "','" + b.Bill_Time + "'," +
                    "'" + b.Bill_Discount + "','" + b.Bill_Total + "')";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public static void Insert_Customers(Customer c)
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
                string sql = "insert into customers (customerID, fullname, sex, phone, total, customerRank, customerAddress)" +
                    "values ('" + c.CustomerID + "',N'" + c.CustomerName + "',N'" + c.CustomerSex + "'," +
                    "'" + c.CustomerPhone + "','" + c.CustomerTotal + "',N'" + c.CustomerRank + "',N'" + c.Address + "')";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public static void Insert_Import(Import i)
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
                string sql = "insert into import values" +
                    " ('" + i.ImportID + "','" + i.AdminID + "','" + i.ImportDate + "')";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public static void Insert_ImportProducts(ImportProduct ip)
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
                string sql = "insert into importproduct values" +
                    " ('" + ip.ImportProductID + "',N'" + ip.ImportProductName + "'," +
                    "'" + ip.ImportID + "','" + ip.ImportProductPrice + "'," +
                    "N'" + ip.ProductType + "','" + ip.ImportQuantity + "',N'" + ip.Unit + "')";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public static void Insert_Orders(Order o)
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
                string sql = "insert into orders values" +
                    " ('" + o.Order_Product_ID + "','" + o.Bill_ID + "','" + o.Order_Product_ID + "'," +
                    "'" + o.Order_Sell_Quantity + "','" + o.Order_Product_Price + "'," +
                    "'" + o.Order_Discount + "','" + o.Order_Total + "')";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public static void Insert_Products(Product p)
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
                string sql = "insert into products " +
                    "values ('" + p.ProductId + "',N'" + p.Name + "',N'" + p.Product_Type + "'," +
                    "'" + p.Price + "','" + p.Remaining_quantity + "',N'" + p.description + "',N'" + p.Avatar + "')";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public static void Insert_Staff(Account a)
        {
            MessageBox.Show(System.Configuration.ConfigurationManager.ConnectionStrings["FastFoodDataBase"].ConnectionString);
            if (con.State != ConnectionState.Open)
            {
                con.Open();
                string sql = "insert into staff values ('" + a.StaffID + "',N'" + a.Avatar + "'," +
                    "N'" + a.AccessRight + "',N'" + a.Username + "',N'" + a.Pass + "',N'" + a.Name + "'," +
                    "N'" + a.Sex + "','" + a.DateOfBirth + "','" + a.Phone_Number + "',N'" + a.Email + "'," +
                    "N'" + a.address + "')";
                SqlCommand cmd = new SqlCommand(sql, con);
                int check = cmd.ExecuteNonQuery();
                MessageBox.Show(check.ToString());
                con.Close();
            }
        }
        public static Account Select_LoggedIn_Account(string username, string password)
        {
            Account a = new Account();
            if (con.State != ConnectionState.Open)
            {
                con.Open();
                string sql = "select * from staff where username='"+username+"' and pass='"+password+"'";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
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
                }
                con.Close();
            }
            return a;
        }
        public static List<Customer> Select_all_Customers()
        {
            List<Customer> customers = new List<Customer>();
            if (con.State != ConnectionState.Open)
            {
                con.Open();
                string sql = "select * from customers ";
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
            return customers;
        }
        private static List<ImportProduct> select_all_Import_Product_specified_ImportID(string ImportID)
        {
            List<ImportProduct> importProducts = new List<ImportProduct>();
            if (con.State != ConnectionState.Open)
            {
                con.Open();
                string sql = "select * from import where importID = '" + ImportID + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ImportProduct ip = new ImportProduct();
                    ip.ImportProductID = reader.GetString(0);
                    ip.ImportProductName = reader.GetString(1);
                    ip.ImportID = reader.GetString(2);
                    ip.ImportProductPrice = reader.GetInt32(3);
                    ip.ProductType = reader.GetString(4);
                    ip.ImportQuantity = reader.GetInt32(5);
                    ip.Unit = reader.GetString(6);
                    importProducts.Add(ip);
                }
                con.Close();
            }
            return importProducts;
        }
        public static List<Import> Select_all_Import()
        {
            List<Import> imports = new List<Import>();
            if (con.State != ConnectionState.Open)
            {
                con.Open();
                string sql = "select * from import ";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Import i = new Import();
                    i.ImportID = reader.GetString(0);
                    i.AdminID = reader.GetString(1);
                    i.ImportDate = reader.GetDateTime(2);
                    i.importProducts = new List<ImportProduct>();
                    imports.Add(i);
                }
                foreach (Import i in imports)
                {
                    select_all_Import_Product_specified_ImportID(i.ImportID);
                }
                con.Close();
            }
            return imports;
        }
        public static List<Product> Select_all_product()
        {
            List<Product> p = new List<Product>();
            if (con.State != ConnectionState.Open)
            {
                con.Open();
                string sql = "select * from Products";
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
            return p;
        }

        public static List<Order> Select_all_Orders_specified_BillID(string Bill_ID)
        {
            List<Order> o = new List<Order>();
            if (con.State != ConnectionState.Open)
            {
                con.Open();
                string sql = "select o.OrderID, o.Bill_ID, o.ProductID," +
                            " o.Sell_Quantity, o.UnitPrice, o.Discount," +
                            " o.total, p.ProductName" +
                            " from ORDERS o inner join PRODUCTS p " +
                            "ON o.ProductID = p.ProductID " +
                            "where Bill_ID='" + Bill_ID + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Order oItem = new Order();
                    oItem.Order_ID = reader.GetString(0);
                    oItem.Bill_ID = reader.GetString(1);
                    oItem.Order_Product_ID = reader.GetString(2);
                    oItem.Order_Sell_Quantity = reader.GetInt32(3);
                    oItem.Order_Product_Price = reader.GetInt32(4);
                    oItem.Order_Discount = reader.GetInt32(5);
                    oItem.Order_Total = reader.GetInt32(6);
                    oItem.Order_Product_Name = reader.GetString(7);
                    o.Add(oItem);
                }
                con.Close();
            }
            return o;
        }
        public static void Select_all_Bill()
        {
            List<Bill> bills = new List<Bill>();
            if (con.State != ConnectionState.Open)
            {
                con.Open();
                string sql = "select b.BillID, b.StaffID, b.CustomerID, b.BillDate," +
                    "b.Discount,b.Total,c.Fullname,s.FullName  " +
                    "from BILL b inner join CUSTOMERS c ON b.CustomerID = c.CustomerID " +
                                    "inner join STAFF s on b.StaffID = s.ID";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Bill b = new Bill();
                    b.Bill_ID = reader.GetString(0);
                    b.StaffID = reader.GetString(1);
                    b.CustomerID = reader.GetString(2);
                    b.Bill_Time = reader.GetDateTime(3);
                    b.Bill_Discount = reader.GetInt32(4);
                    b.Bill_Total = reader.GetInt32(5);
                    b.StaffName = reader.GetString(6);
                    b.CustomerName = reader.GetString(7);
                    b.orders = new List<Order>();
                    bills.Add(b);
                }
                con.Close();
            }
            foreach (Bill b in bills)
            {
                b.orders = Select_all_Orders_specified_BillID(b.Bill_ID);
            }
            //total & list <order>
        }
        public static List<Account> Select_all_Account()
        {
            List<Account> acc = new List<Account>();

            if (con.State != ConnectionState.Open)
            {
                con.Open();
                string sql = "select * from staff ";
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
            return acc;
        }
        public static int Select_today_sales()
        {
            int s = 0;
            if (con.State != ConnectionState.Open)
            {
                con.Open();
                string sql = "select sum(total) from Bill where" +
                    "  DAY(BillDate)=" + DateTime.Today.Day + " and Month(billdate)=" + DateTime.Today.Month + "" +
                    " and YEAR(BillDate)=" + "" + DateTime.Today.Year + "";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if(!reader.IsDBNull(0))
                        s = reader.GetInt32(0);
                }
                con.Close();
            }
            return s;
        }
        public static int Select_today_sold_product()
        {
            int s = 0;
            if (con.State != ConnectionState.Open)
            {
                con.Open();
                string sql = "select Sum(o.Sell_Quantity) from BILL b inner join ORDERS o on b.BillID = o.Bill_ID  where" +
                    "  DAY(BillDate)=" + DateTime.Today.Day + " and Month(billdate)=" + DateTime.Today.Month + "" +
                    " and YEAR(BillDate)=" + "" + DateTime.Today.Year + "";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                        s = reader.GetInt32(0);
                }
                con.Close();
            }
            return s;
        }
        public static int Select_today_Orders()
        {
            int s = 0;
            if (con.State != ConnectionState.Open)
            {
                con.Open();
                string sql = "select Count(o.orderID) from BILL b inner join ORDERS o on b.BillID = o.Bill_ID  where" +
                    "  DAY(BillDate)=" + DateTime.Today.Day + " and Month(billdate)=" + DateTime.Today.Month + "" +
                    " and YEAR(BillDate)=" + "" + DateTime.Today.Year + "";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                        s = reader.GetInt32(0);
                }
                con.Close();
            }
            return s;
        }
        public static List<Product> Search_Product(string product_type, string sort_by, string parameter_search)
        {
            // product_type : all hoặc product.type
            // sort_by: product.name hoặc product.price??
            // vd: ProductPrice asc, ProductPrice dsc, ProductName
            List<Product> p = new List<Product>();
            string sql = "";
            if ( product_type == "all")
            sql = "select * from products where productName = '%"+parameter_search+"%' order by '"+sort_by+"'";
            else
            {
                sql = "select * from products where ProductType = '"+product_type+"' and lower(productName) = lower('%" + parameter_search + "%') order by '" + sort_by + "'";
            }
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
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
            return p;
        }

        public static List<Bill> Search_bill_hoten(string search_by, string parameter)
        {
            string sql = "select b.BillID, b.StaffID, b.CustomerID, b.BillDate," +
                    "b.Discount,b.Total,c.Fullname,s.FullName  " +
                    "from BILL b inner join CUSTOMERS c ON b.CustomerID = c.CustomerID " +
                                    "inner join STAFF s on b.StaffID = s.ID";
            if (search_by == "hoten")
            {
                sql += "where c.fullname = '%" + parameter + "'%";
            }
            else if (search_by == "sdt")
            {
                sql += "where c.phone = '%" + parameter + "'%";
            }
            else if (search_by == "gia_up")
            {
                int gia = int.Parse(parameter);
                sql += "where b.total >= '" + gia + "'";
            }
            else if (search_by == "gia_down")
            {
                int gia = int.Parse(parameter);
                sql += "where b.total <= '" + gia + "'";
            }
            else if (search_by == "ngay_up")
            {
                DateTime d = DateTime.Parse(parameter);
                sql += "where b.billDate >= '" + d + "'";
            }
            else if (search_by == "ngay_up")
            {
                DateTime d = DateTime.Parse(parameter);
                sql += "where b.billDate <= '" + d + "'";
            }
            List<Bill> bills = new List<Bill>();
            if (con.State != ConnectionState.Open)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Bill b = new Bill();
                    b.Bill_ID = reader.GetString(0);
                    b.StaffID = reader.GetString(1);
                    b.CustomerID = reader.GetString(2);
                    b.Bill_Time = reader.GetDateTime(3);
                    b.Bill_Discount = reader.GetInt32(4);
                    b.Bill_Total = reader.GetInt32(5);
                    b.StaffName = reader.GetString(6);
                    b.CustomerName = reader.GetString(7);
                    b.orders = new List<Order>();
                    bills.Add(b);
                }
                con.Close();
            }
            foreach (Bill b in bills)
            {
                b.orders = Select_all_Orders_specified_BillID(b.Bill_ID);
            }
            return bills;
        }

    }
}


