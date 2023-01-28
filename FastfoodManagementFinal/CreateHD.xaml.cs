using FastfoodManagementFinal.Models;
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
            txtbox_NV.Text = b.StaffID + " | " + b.StaffName;
            txtbox_KH.Text = b.CustomerID + " | " + b.CustomerName;
            datepicker_NgaySinh.SelectedDate = b.Bill_Time;
            txtbox_discount.Text = b.Bill_Discount.ToString();
            txtBox_BillID.Text = b.Bill_ID;
            double DiscountAmount = total * b.Bill_Discount / 100;
            double Paid = total-DiscountAmount;
            txtblock_tongtien.Text = total.ToString();
            txtblock_giamgia.Text = DiscountAmount.ToString();
            txtblock_thanhtien.Text = Paid.ToString();
        }

        public List<Order> odrs { get; set; } = new List<Order> { new Order() };
        DateTime picked_date = DateTime.Now;
        private void datepicker_NgaySinh_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            //picked_date = (DateTime)(((DatePicker)sender).SelectedDate);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
