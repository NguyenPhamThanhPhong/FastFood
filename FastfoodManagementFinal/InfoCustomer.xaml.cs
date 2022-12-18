using FastfoodManagementFinal.Models;
using FastfoodManagementFinal.ViewModel;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for InfoCustomer.xaml
    /// </summary>
    public partial class InfoCustomer : Window
    {
        public InfoCustomer()
        {
            InitializeComponent();
            button_capnhat.Visibility = Visibility.Hidden;
            button_xoa.Visibility = Visibility.Hidden;
            button_xoa.IsEnabled= false;
            button_capnhat.IsEnabled = false;
            txtbox_doanhso.IsEnabled = false;
            txtbox_doanhso.Text = "0";
        }
        public InfoCustomer(Customer c)
        {
            InitializeComponent();
            this.txtbox_maKH.Text = c.CustomerID;
            txtbox_tenKH.Text =c.CustomerName;
            txtbox_doanhso.Text = c.CustomerTotal.ToString();
            txtbox_sdt.Text = c.CustomerPhone;
            txtbox_gioitinh.Text = c.CustomerSex;
            txtbox_capbac.Text = c.CustomerRank;
            txtbox_diachi.Text = c.Address;
            txtbox_doanhso.IsEnabled = false;
            txtbox_maKH.IsEnabled= false;
            button_them.IsEnabled = false;
            button_them.Visibility = Visibility.Hidden;
        }

        //private void txtĐK_TK_Copy3_TextChanged(object sender, TextChangedEventArgs e)
        //{

        //}
        private bool check_du_lieu()
        {
            bool check = true;
            int test;
            if(txtbox_maKH.Text=="" || txtbox_tenKH.Text=="" || txtbox_sdt.Text=="")
            {
                MessageBox.Show("thông tin cần thiết bị thiếu!");
                return false;
            }
            foreach(char s in txtbox_tenKH.Text)
            {
                if(s<='9'&&s>='0')
                {
                    MessageBox.Show("họ tên sai định dạng!!");
                }
            }
            if(int.TryParse(txtbox_sdt.Text, out test)==false) 
            {
                MessageBox.Show("số điện thoại phải là số");
                return false;
            }
            return true;
        }
        private void Button_them_Click(object sender, RoutedEventArgs e)
        {
            if(check_du_lieu()==true)
            {
                Customer c= new Customer();
                c.CustomerID = txtbox_maKH.Text;
                c.CustomerName = txtbox_tenKH.Text;
                c.CustomerPhone= txtbox_sdt.Text;
                c.CustomerRank = txtbox_sdt.Text;
                c.CustomerSex = txtbox_gioitinh.Text;
                c.CustomerRank = txtbox_capbac.Text;
                c.CustomerTotal = int.Parse(txtbox_doanhso.Text);
                c.Address = txtbox_diachi.Text;
                c.CustomerBills = new List<Bill>();
                Xu_Ly_SQL.Insert_Customers(c);
            }
        }
        private void Button_capnhat_Click(object sender, RoutedEventArgs e)
        {
            if (check_du_lieu() == true)
            {
                Customer c = new Customer();
                c.CustomerID = txtbox_maKH.Text;
                c.CustomerName = Xu_ly_chuoi.chuan_hoa(txtbox_tenKH.Text);
                c.CustomerPhone = txtbox_sdt.Text.Trim(); ;
                c.CustomerSex = Xu_ly_chuoi.chuan_hoa( txtbox_gioitinh.Text);
                c.CustomerRank = Xu_ly_chuoi.chuan_hoa(txtbox_capbac.Text);
                c.CustomerTotal = int.Parse(txtbox_doanhso.Text.Trim());
                c.Address = txtbox_diachi.Text.Trim();
                c.CustomerBills = new List<Bill>();
                Xu_Ly_SQL.Update_Customers(c);
            }
        }
        private void Button_xoa_Click(object sender, RoutedEventArgs e)
        {
            Xu_Ly_SQL.Delete_customer(txtbox_maKH.Text.Trim());
            this.Close();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void txtbox_tenKH_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key <= Key.D9 && e.Key>=Key.D0) 
            { 
                e.Handled= true;
            }
            if(Keyboard.IsKeyToggled(Key.NumLock))
            {
                if (e.Key <= Key.NumPad9 && e.Key >= Key.NumPad0)
                {
                    e.Handled = true;
                }
            }
            if(txtbox_tenKH.Text.Length>=35)
            {
                e.Handled = true;
            }
        }
    }
}
