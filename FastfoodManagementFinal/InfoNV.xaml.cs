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
            List<Process> p = FileUtil.WhoIsLocking(Xu_ly_Anh.GetAnh(Xu_ly_Anh.AccountAvatar, "NV05"));
            MessageBox.Show(p.Count.ToString());
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
                //this.image_avatar.Source = new BitmapImage(new Uri(Xu_ly_Anh.GetAnh(Xu_ly_Anh.AccountAvatar, a.Avatar)));
                this.image_avatar.Source = new BitmapImage(new Uri("C:\\Users\\anhng\\OneDrive\\Máy tính\\ảnh\\fast-food-transparent-png-pictures-icons-and-png-18.png"));

            }
            Avatar_path = "";

            //List<Process> p2 = FileUtil.WhoIsLocking(Xu_ly_Anh.GetAnh(Xu_ly_Anh.AccountAvatar, a.Avatar));
            //MessageBox.Show(p2.Count.ToString());


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
                image_avatar.Source = new BitmapImage(new Uri(Avatar_path));
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
            MessageBox.Show(datepicker_NgaySinh.Text);
            if(a.Is_valid())
            {
                Xu_Ly_SQL.Update_Staff(a);

                Avatar_path = "C:\\Users\\anhng\\OneDrive\\Máy tính\\ảnh\\png-transparent-fast-food-drink-junk-food-eating-food-icon-food-text-logo-thumbnail.png";

                if (Avatar_path != "")
                {
                    Xu_ly_Anh.LuuAnh(Avatar_path, Xu_ly_Anh.AccountAvatar, "abc.png");
                }
            }

        }

        private void button_xoa_Click(object sender, RoutedEventArgs e)
        {
            Xu_Ly_SQL.Delete_Staff(txtbox_maNV.Text.Trim());
        }
    }
}
