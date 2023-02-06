using FastfoodManagementFinal.Models;
using FastfoodManagementFinal.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for ViewDH.xaml
    /// </summary>
    public partial class ViewDH : Window
    {
        public ViewDH()
        {
            InitializeComponent();
            txtbox_soHD.Text = Xu_ly_ID.GetBillID();
            txtbox_maNV.Text = Selected.LoggedIn.StaffID + " " + Selected.LoggedIn.Name;
        }
        public List<Order> odrs { get; set; } = new List<Order>();
        public ObservableCollection<Customer> customers { get; set; } = new ObservableCollection<Customer>(Xu_Ly_SQL.Select_all_Customers());
        public ObservableCollection<Product> products { get; set; } = new ObservableCollection<Product>(Xu_Ly_SQL.Select_all_product());

        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ComboBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            products.Clear();
            foreach(Product p in Product.HoaDon_Product(combobox_SP.Text.Trim()))
            {
                products.Add(p);
            }
        }
        private void ComboBox_KH_TextChanged(object sender, TextChangedEventArgs e)
        {
            customers.Clear();
            foreach (Customer c in Customer.Search_ID_Name(combobox_KH.Text.Trim()))
            {
                customers.Add(c);
            }
        }

        private void combobox_SP_GotFocus(object sender, RoutedEventArgs e)
        {
            combobox_SP.IsDropDownOpen= true;
        }
        private void combobox_KH_GotFocus(object sender, RoutedEventArgs e)
        {
            combobox_KH.IsDropDownOpen = true;
        }

        //button thêm 
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Product p = Product.Find(combobox_SP.Text.Trim());
            int sell_amount;
            int left_amount=-1;
            int.TryParse(txtblock_soluongcon.Text, out left_amount);
            if (!int.TryParse(txtbox_soluong.Text.Trim(), out sell_amount))
            {
                MessageBox.Show("vui lòng nhập số lượng");
                return;
            }
            if(sell_amount<0)
            {
                MessageBox.Show("Số lượng bán không hợp lệ");
                return;
            }
            if(txtblock_soluongcon.Text == "" || left_amount<0)
            {
                MessageBox.Show("vui lòng kiểm tra số sản phẩm còn!");
                return;
            }
            
            //Xu ly
            if ( p.ProductId!=null) 
            {
                foreach(Order oo in odrs)
                {
                    if(oo.Order_Product_ID == p.ProductId)
                    {
                        oo.Order_Sell_Quantity += sell_amount;
                        oo.Order_Total += (sell_amount * p.Price * (1 - oo.Order_Discount));
                        ListView_order.Items.Refresh();

                        string current = txtbox_soluong.Text;
                        txtbox_soluong.Text = "";
                        txtbox_soluong.Text = current;
                        return;
                    }
                }
                Order o = new Order(txtbox_soHD.Text.Trim(),odrs.Count,p,sell_amount);
                odrs.Add(o);
                ListView_order.Items.Refresh();
                string currenttxt = txtbox_soluong.Text;
                txtbox_soluong.Text = "";
                txtbox_soluong.Text = currenttxt;
            }
        }

        private void Button_tru_Click(object sender, RoutedEventArgs e)
        {
            int sell_amount;
            if (int.TryParse(txtbox_soluong.Text.Trim(), out sell_amount))
            {
                sell_amount--;
                txtbox_soluong.Text = sell_amount.ToString();
                return;
            }
        }

        private void Button_cong_Click(object sender, RoutedEventArgs e)
        {
            int sell_amount;
            if (int.TryParse(txtbox_soluong.Text.Trim(), out sell_amount))
            {
                sell_amount++;
                txtbox_soluong.Text = sell_amount.ToString();
                return;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            odrs.Clear();
            ListView_order.Items.Refresh();
        }

        private void button_reset_Click(object sender, RoutedEventArgs e)
        {
            combobox_KH.Text= string.Empty;
            combobox_SP.Text = string.Empty;
            txtbox_soluong.Text = string.Empty;
        }

        private void button_thanhtoan_Click(object sender, RoutedEventArgs e)
        {
            Customer c = Customer.FindAbsolute_ID(combobox_KH.Text.Trim());
            if(this.odrs.Count<=0)
            {
                MessageBox.Show("vui lòng nhập order của khách hàng!");
                return;
            }
            if (c.CustomerID !=null) 
            {
                Bill b = new Bill();
                b.Bill_ID = txtbox_soHD.Text;
                b.CustomerID = c.CustomerID;
                b.CustomerName= c.CustomerName;
                b.StaffID = txtbox_maNV.Text.Substring(0,5);
                b.StaffName = txtbox_maNV.Text.Substring(5);
                b.Bill_Time = datepicker_billtime.SelectedDate.Value;
                b.Bill_Discount = 0;
                b.Bill_Total = 180000;
                b.orders = this.odrs;
                Xu_Ly_SQL.Insert_Bill(b);
                foreach(Order o in odrs)
                {
                    Xu_Ly_SQL.Insert_Orders(o);
                }
                button_reset_Click(sender, e);
                Button_Click(sender, e);
            }
        }
        private void Button_Delete_Element(object sender, RoutedEventArgs e)
        {
            var p = VisualTreeHelper.GetParent(e.Source as Button);
            TextBlock tt = (TextBlock)VisualTreeHelper.GetChild(p, 1);
            foreach(Order o in odrs)
            {
                if(o.Order_ID.Substring(6)==tt.Text)
                {
                    odrs.Remove(o);
                    ListView_order.Items.Refresh();
                    return;
                }
            }

        }

        private void button_xuatExcel_Click(object sender, RoutedEventArgs e)
        {
            Customer c = Customer.FindAbsolute_ID(combobox_KH.Text.Trim());
            if (this.odrs.Count <= 0)
            {
                MessageBox.Show("vui lòng nhập order của khách hàng!");
                return;
            }
            if (c.CustomerID != null)
            {
                Bill b = new Bill();
                b.Bill_ID = txtbox_soHD.Text;
                b.CustomerID = c.CustomerID;
                b.CustomerName = c.CustomerName;
                b.StaffID = txtbox_maNV.Text.Substring(0, 5);
                b.StaffName = txtbox_maNV.Text.Substring(5);
                b.Bill_Time = datepicker_billtime.SelectedDate.Value;
                b.Bill_Discount = 0;
                b.Bill_Total = 180000;
                b.orders = this.odrs;
                Xu_Ly_SQL.Insert_Bill(b);
                foreach (Order o in odrs)
                {
                    Xu_Ly_SQL.Insert_Orders(o);
                }
                Xu_ly_excel.Xuat_excel_HoaDon(b);
                button_reset_Click(sender, e);
                Button_Click(sender, e);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
