using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FastfoodManagementFinal.ViewModel;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace FastfoodManagementFinal.Models
{
    public class Product
    {
        //public Product(int type_of_constructor)
        //{

        //}
        // load từ dưới database lên
        //public Product(string ProductId, string name, int price, string product_Type, int remaining_quantity, string avatar)
        //{
        //    this.ProductId = ProductId;
        //    Name = name;
        //    Price = price;
        //    Product_Type = product_Type;
        //    Remaining_quantity = remaining_quantity;
        //    Avatar = avatar;
        //}
        public Product()
        {

        }
        public bool IsValid(string price, string quantity)
        {
            if (this.ProductId == "" || Name == ""|| Product_Type=="")
            {
                MessageBox.Show("Món ăn phải có tên món ăn và loại món ăn!");
                return false;
            }
            int try_parse;
            if(int.TryParse(price,out try_parse)==false||
                    int.TryParse(quantity,out try_parse)==false)
            {
                MessageBox.Show("Số lượng sản phẩm và giá sản phẩm phải là số!");
                return false;
            }
            else 
            {
                Price = int.Parse(price);
                Remaining_quantity = int.Parse(quantity);
            }
            
            return true;
        }
        public static List<Product> HoaDon_Product(string parameter)
        {
            string sql = "select * from products where lower(ProductID) + lower(productName) like N'%" + parameter.Trim() + "%'";
            string ID = parameter;
            if(parameter.Length>6)
            {
                 ID = parameter.Substring(0, 5); 
                string pName = parameter.Substring(6);
                sql = "select * from products where lower(ProductID) + lower(productName) like N'%" + ID + "%" + pName + "%'";
            }
            List<Product> p = new List<Product>();
            SqlConnection con = Xu_Ly_SQL.con;
            if (con.State != ConnectionState.Open)
            {
                con.Open();
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
        public static Product Find(string parameter)
        {
            Product product = new Product();
            if (parameter.Length>6)
            {
                string strID = parameter.Substring(0, 5);
                string strName = parameter.Substring(6);
                SqlConnection con = Xu_Ly_SQL.con;
                string sql = "select * from products where productID = N'"+strID.Trim()+"' " +
                                        "and productName = N'"+strName.Trim()+"'";
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sql, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        
                        product.ProductId = reader.GetString(0);
                        product.Name = reader.GetString(1);
                        product.Product_Type = reader.GetString(2);
                        product.Price = reader.GetInt32(3);
                        product.Remaining_quantity = reader.GetInt32(4);
                        product.description = reader.GetString(5);
                        product.Avatar = reader.GetString(6);
                    }
                    con.Close();
                }
            }
            return product;
        }
        public override string ToString()
        {
            return this.ProductId + " " + this.Name;
        }
        public ImageSource LoadAvatar()
        {
            string path = Xu_ly_Anh.GetAnh(Xu_ly_Anh.ProductAvatar, this.Avatar);
            Uri ImageUri = new Uri(path);
            return BitmapFrame.Create(
                      ImageUri, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
        }
        public string ProductId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Product_Type { get; set; }
        public int Remaining_quantity { get; set; }
        public string description { get; set; }
        public string Avatar { get; set; }
    }
}
