using FastfoodManagementFinal.Models;
using FastfoodManagementFinal.ViewModel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
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
    /// Interaction logic for SignUp.xaml
    /// </summary>
    /// 

    public partial class SignUp : Window
    {
        public SignUp()
        {
            InitializeComponent();
            txtKey.Visibility = Visibility.Hidden;
            datepicker_NgaySinh.SelectedDate = DateTime.Now;
        }
        string Avatar_path;
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=FastFood;Integrated Security=True");
        DateTime picked_date;

        string Mailcode;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string access_right = "Nhân viên";
            if (radio_button_nhanvien.IsChecked == true)
            {
                access_right = "Nhân viên";
            }
            else if (radio_button_quanly.IsChecked == true)
            {
                access_right = "Quản lý";
            }
            
            Account a = new Account();
            a.AccessRight = access_right;
            a.StaffID = Xu_ly_ID.GetStaffID(access_right);
            a.Avatar = a.StaffID + new FileInfo(Avatar_path).Extension;
            a.Username = txtĐK_TK.Text;
            a.Pass = txtĐK_Pass.Text;
            a.Name = txtĐK_Name.Text;
            a.Sex = txtĐK_Sex.Text;
            a.DateOfBirth = picked_date;
            a.Phone_Number = txtĐK_Phone.Text;
            a.Email = txtĐK_Email.Text;
            a.address = txtĐK_Address.Text;
            a.Visible = true;
            if (a.Is_valid())
            {

                if (txtKey.Visibility == Visibility.Visible && txtKey.Text != "QL_VIP_PRO")
                {
                    MessageBox.Show("Sai mã key quản lý! " +
                        "   \n Vui lòng chọn đúng quyền hạn hoặc nhập đúng mã Key!");
                    return;
                }
                if(txtbox_maEmail.Text!=Mailcode)
                {
                    MessageBox.Show("Mã email ko hợp lệ");
                    return;
                }
                Xu_Ly_SQL.Insert_Staff(a);
                if (Avatar_path != "")
                {
                    Xu_ly_Anh.LuuAnh(Avatar_path, Xu_ly_Anh.AccountAvatar, a.Avatar);
                }
            }
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|all files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true && openFileDialog.CheckFileExists == true)
            {
                Avatar_path = openFileDialog.FileName;
            }
            if(Avatar_path=="" || Avatar_path==null)
            {
                return;
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

        private void datepicker_NgaySinh_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            picked_date = (DateTime)(((DatePicker)sender).SelectedDate);   
        }

        private void radio_button_nhanvien_Checked(object sender, RoutedEventArgs e)
        {
            txtKey.Visibility = Visibility.Visible;
        }

        private void radio_button_quanly_Checked(object sender, RoutedEventArgs e)
        {
            txtKey.Visibility = Visibility.Hidden;
        }

        private void txtĐK_Sex_KeyDown(object sender, KeyEventArgs e)
        {
            if((e.Key>=Key.D0 && e.Key<=Key.D9)) 
            { 
                e.Handled = true;
            }
        }

        private void txtĐK_Phone_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(e.Key >= Key.D0 && e.Key <= Key.D9))
            {
                e.Handled = true;
            }
        }

        private void button_guima_Click(object sender, RoutedEventArgs e)
        {
            string x = txtĐK_Email.Text.Trim();
            Xu_ly_Mail.SendMail(x);
            //Xu_ly_Mail.SendEmail(txtĐK_Email.Text.Trim());
            //Mailcode = ;
        }
    }

}
