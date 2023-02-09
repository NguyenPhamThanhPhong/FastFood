using FastfoodManagementFinal.Models;
using FastfoodManagementFinal.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for CreateHD.xaml
    /// </summary>
    public partial class CreateHD : Window
    {
        public CreateHD()
        {
            InitializeComponent();
        }
        public CreateHD(Bill b)
        {
            InitializeComponent();
            int total = 0;
            foreach(Order o in b.orders)
            {
                this.odrs.Add(o);
                total += o.Order_Total;
            }
            txtbox_NV.Text = b.StaffID + " " + b.StaffName;
            txtbox_KH.Text = b.CustomerID + " " + b.CustomerName;
            datepicker_NgaySinh.SelectedDate = b.Bill_Time;
            txtbox_discount.Text = b.Bill_Discount.ToString();
            txtBox_BillID.Text = b.Bill_ID;
            int DiscountAmount = total * b.Bill_Discount / 100;
            int Paid = total-DiscountAmount;

            txtblock_tongtien.Text = Xu_ly_chuoi.ToVND(total);
            txtblock_giamgia.Text = Xu_ly_chuoi.ToVND(DiscountAmount);
            txtblock_thanhtien.Text = Xu_ly_chuoi.ToVND(Paid);
            txtbox_time.Text = b.Bill_Time.ToString();
        }

        public List<Order> odrs { get; set; } = new List<Order> { };
        DateTime picked_date = DateTime.Now;
        private void datepicker_NgaySinh_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            //picked_date = (DateTime)(((DatePicker)sender).SelectedDate);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
                Bill b = new Bill();
                b.Bill_ID = txtBox_BillID.Text;
                b.CustomerID = txtbox_KH.Text.Substring(0,5).Trim();
                b.CustomerName = txtbox_KH.Text.Substring(5);
                b.StaffID = txtbox_NV.Text.Substring(0, 5);
                b.StaffName = txtbox_NV.Text.Substring(5);
                b.Bill_Time = DateTime.Parse(txtbox_time.Text.Trim());
                b.Bill_Discount = Xu_ly_chuoi.ConvertVNDCurrencyToInt(txtblock_giamgia.Text.Trim());
                b.Bill_Total = Xu_ly_chuoi.ConvertVNDCurrencyToInt(txtblock_tongtien.Text.Trim());
                b.orders = this.odrs;
                Xu_ly_excel.Xuat_excel_HoaDon(b);
            }
        }
}

