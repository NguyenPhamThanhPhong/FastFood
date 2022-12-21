using FastfoodManagementFinal.Models;
using FastfoodManagementFinal.ViewModel;
using Microsoft.Office.Interop.Excel;
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
    /// Interaction logic for InfoNV.xaml
    /// </summary>
    public partial class InfoNV : System.Windows.Window
    {
        public InfoNV(Account a)
        {
            InitializeComponent();


            txtbox_maNV.Text = a.StaffID;
            txtbox_tenNV.Text = a.Name;
            txtbox_GioiTinh.Text = a.Sex;
            txtbox_ChucVu.Text = a.AccessRight;



            txtbox_sdt.Text = a.Phone_Number;
            datepicker_NgaySinh.Text = a.DateOfBirth.ToString();
            txtbox_email.Text = a.Email;
            txtbox_diachi.Text = a.address;



            username = a.Username;
            pass = a.Pass;
            Avatar_path = Xu_ly_Anh.GetAnh(Xu_ly_Anh.AccountAvatar, a.Avatar);



            if (new FileInfo(Xu_ly_Anh.GetAnh(Xu_ly_Anh.AccountAvatar, a.Avatar)).Exists)
            {
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.CacheOption = BitmapCacheOption.OnLoad;
                bi.UriSource = new Uri(Xu_ly_Anh.GetAnh(Xu_ly_Anh.AccountAvatar, a.Avatar));
                bi.EndInit();
                this.image_avatar.Source = null;
                GC.Collect();
                this.image_avatar.Source = bi;
            }
            List<Process> p1 = FileUtil.WhoIsLocking(Xu_ly_Anh.GetAnh(Xu_ly_Anh.AccountAvatar, "NV05.png"));
            MessageBox.Show(p1.Count.ToString());




            txtbox_ChucVu.IsEnabled = false;
            txtbox_maNV.IsEnabled= false;


            
        }
        string username = "";
        string pass = "";
        DateTime picked_date = DateTime.Today;
        string Avatar_path = "";
        private void datepicker_NgaySinh_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            picked_date = (DateTime)(((DatePicker)sender).SelectedDate);
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

        private void button_capnhat_Click(object sender, RoutedEventArgs e)
        {
            //bool containsInt = "your string".Any(char.IsDigit);
            Account a = new Account();
            a.StaffID = txtbox_maNV.Text;
            a.Avatar = a.StaffID + new FileInfo(Avatar_path).Extension;
            a.AccessRight = txtbox_ChucVu.Text.Trim();
            a.Username = username;
            a.Pass = pass;
            a.Name = txtbox_tenNV.Text;
            a.Sex = txtbox_GioiTinh.Text;
            a.DateOfBirth = picked_date;
            a.Phone_Number = txtbox_sdt.Text;
            a.Email = txtbox_email.Text;
            a.address = txtbox_diachi.Text;
            if(a.Is_valid())
            {
                Xu_Ly_SQL.Update_Staff(a);
                if (Avatar_path != "")
                {
                    Xu_ly_Anh.LuuAnh(Avatar_path, Xu_ly_Anh.AccountAvatar, a.Avatar);
                }
            }

        }

        private void button_xoa_Click(object sender, RoutedEventArgs e)
        {
            Xu_Ly_SQL.Delete_Staff(txtbox_maNV.Text.Trim());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
