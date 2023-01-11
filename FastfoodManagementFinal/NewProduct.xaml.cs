using FastfoodManagementFinal.Models;
using FastfoodManagementFinal.ViewModel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            txt_maSP.Text = Xu_ly_ID.GetProductID();
            button_capnhat.IsEnabled= false;
            button_capnhat.Visibility = Visibility.Hidden;
        }
        public NewProduct(Product p)
        {
            InitializeComponent();
            loginBtn.IsEnabled=false;
            loginBtn.Visibility=Visibility.Hidden;

            txt_maSP.Text = p.ProductId;
            txt_tenSP.Text = p.Name;
            txt_loaiSP.Text = p.Product_Type;
            txt_giaSP.Text = p.Price.ToString();
            txt_SoLuongCon.Text = p.Remaining_quantity.ToString();
            txt_description.Text = p.description.ToString();
            try
            {
                if (new FileInfo(Xu_ly_Anh.GetAnh(Xu_ly_Anh.ProductAvatar, p.Avatar)).Exists)
                {
                    Avatar_path = Xu_ly_Anh.GetAnh(Xu_ly_Anh.ProductAvatar, p.Avatar);
                    BitmapImage bi = new BitmapImage();
                    bi.BeginInit();
                    bi.CacheOption = BitmapCacheOption.OnLoad;
                    bi.UriSource = new Uri(Avatar_path);
                    bi.EndInit();
                    this.image_avatar.Source = null;
                    GC.Collect();
                    image_avatar.Source = bi;
                    bi = null;
                    GC.Collect();
                }
            }
            catch
            {

            }
            

            
        }
        private string Avatar_path="";
        private void Button_Capnhat_Click(object sender, RoutedEventArgs e)
        {

            Product p = new Product();
            p.ProductId = txt_maSP.Text.Trim();
            p.Avatar = "";
            if(Avatar_path != "")
            {
                if (new FileInfo(Avatar_path).Exists )
                    p.Avatar = p.ProductId + (new FileInfo(Avatar_path).Extension);
            }
            p.Name = txt_tenSP.Text.Trim();


            p.Product_Type = txt_loaiSP.Text.Trim();
            p.description = txt_description.Text.Trim();
            p.IsValid(txt_giaSP.Text, txt_SoLuongCon.Text);

            //List<Process> p1 = FileUtil.WhoIsLocking(Xu_ly_Anh.GetAnh(Xu_ly_Anh.ProductAvatar, "SP002.png"));
            //MessageBox.Show(p1.Count.ToString());
            if (p.IsValid(txt_giaSP.Text, txt_SoLuongCon.Text))
            {
                Xu_Ly_SQL.Update_Product(p);
                if(new FileInfo(Avatar_path).Exists &&
                        Xu_ly_Anh.GetAnh(Xu_ly_Anh.ProductAvatar,p.Avatar)!=Avatar_path)
                    Xu_ly_Anh.LuuAnh(Avatar_path, Xu_ly_Anh.ProductAvatar, p.Avatar);

                this.Close();
            }
        }
        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {

            //if (txt_maSP.Text.Trim() == "" || txt_tenSP.Text.Trim() == "" ||
            //    txt_loaiSP.Text.Trim() == "" || txt_giaSP.Text.Trim() == "" || txt_SoLuongCon.Text.Trim() == "")
            //{
            //    MessageBox.Show("dien day du");
            //    return;
            //}
            //int if_num;
            //if (Int32.TryParse(txt_giaSP.Text.Trim(), out if_num) == false ||
            //    Int32.TryParse(txt_SoLuongCon.Text.Trim(), out if_num) == false)
            //{
            //    MessageBox.Show("nhap so");
            //    return;
            //}
            
            Product p = new Product();
            p.ProductId = txt_maSP.Text.Trim();
            p.Avatar = "";
            if (Avatar_path.Length != 0)
            {
                if (!new FileInfo(Avatar_path).Exists)
                {
                    p.Avatar = p.ProductId + (new FileInfo(Avatar_path).Extension);
                }
            }
            

            p.Name = txt_tenSP.Text.Trim();

            
            p.Product_Type = txt_loaiSP.Text.Trim();
            p.description = txt_description.Text.Trim();
            if(p.IsValid(txt_giaSP.Text, txt_SoLuongCon.Text))
            {
                Xu_Ly_SQL.Insert_Products(p);
                if (Avatar_path.Length != 0)
                {
                    if (!new FileInfo(Avatar_path).Exists)
                    {
                        Xu_ly_Anh.LuuAnh(Avatar_path, Xu_ly_Anh.ProductAvatar, p.Avatar);
                    }
                }
                
                MessageBox.Show("đã thêm mới");
            }
            //MessageBox.Show("Thêm mới thất bại!");
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|all files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true && openFileDialog.CheckFileExists == true)
            {
                Avatar_path = openFileDialog.FileName;
            }
            else
                return;
            FileInfo fileInfo = new FileInfo(Avatar_path);
            if (!(fileInfo.Exists) || (fileInfo.Extension != ".jpg" && fileInfo.Extension != ".png"))
            {
                MessageBox.Show("chon file anh thich hop!");
            }
            else
            {
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.CacheOption = BitmapCacheOption.OnLoad;
                bi.UriSource = new Uri(Avatar_path);
                bi.EndInit();
                this.image_avatar.Source = null;
                GC.Collect();
                image_avatar.Source = bi;
                bi = null;
                GC.Collect();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
