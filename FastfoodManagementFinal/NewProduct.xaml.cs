using FastfoodManagementFinal.Models;
using FastfoodManagementFinal.ViewModel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FastfoodManagementFinal
{
    /// <summary>
    /// Interaction logic for NewProduct.xaml
    /// </summary>
    public partial class NewProduct : Window
    {
        public NewProduct()
        {
            InitializeComponent();
        }
        private string Avatar_path="";
        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            if(txt_maSP.Text.Trim()=="" || txt_tenSP.Text.Trim() =="" ||
                txt_loaiSP.Text.Trim() ==""||txt_giaSP.Text.Trim() ==""||txt_SoLuongCon.Text.Trim() =="")
            {
                MessageBox.Show("dien day du");
                return;
            }
            int if_num;
            if(Int32.TryParse(txt_giaSP.Text.Trim(),out if_num)==false|| 
                Int32.TryParse(txt_SoLuongCon.Text.Trim(), out if_num) == false)
            {
                MessageBox.Show("nhap so");
                return; 
            }
            if(!new FileInfo(Avatar_path).Exists)
            {
                Avatar_path = "";
            }
            Product p = new Product();
            p.ProductId = txt_maSP.Text.Trim();
            p.Avatar = p.ProductId + (new FileInfo(Avatar_path).Extension);
            
            p.Name = txt_tenSP.Text.Trim();
            
            p.Price = int.Parse(txt_giaSP.Text.Trim());
            p.Product_Type = txt_loaiSP.Text.Trim();
            p.Remaining_quantity = int.Parse(txt_SoLuongCon.Text.Trim());
            p.description = txt_description.Text.Trim();
            Xu_ly_Anh.LuuAnh(Avatar_path, Xu_ly_Anh.ProductAvatar, p.Avatar);
            Xu_Ly_SQL.Insert_Products(p);
            MessageBox.Show("đã thêm mới");
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|all files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true && openFileDialog.CheckFileExists == true)
            {
                Avatar_path = openFileDialog.FileName;
            }
            FileInfo fileInfo = new FileInfo(Avatar_path);
            if (!(fileInfo.Exists) || (fileInfo.Extension != ".jpg" && fileInfo.Extension != ".png"))
            {
                MessageBox.Show("chon file anh thich hop!");
            }
            else
            {
                image_avatar.Source = new BitmapImage(new Uri(Avatar_path));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
