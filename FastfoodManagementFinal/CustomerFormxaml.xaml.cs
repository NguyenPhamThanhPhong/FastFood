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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FastfoodManagementFinal
{
    /// <summary>
    /// Interaction logic for CustomerFormxaml.xaml
    /// </summary>
    public partial class CustomerFormxaml : Page
    {
        public CustomerFormxaml()
        {
            InitializeComponent();
            load_stack_panel(customers);
        }
        List<Customer> customers = Xu_Ly_SQL.Select_all_Customers();
        private void load_stack_panel(List<Customer> list_cus)
        {
            this.stackpanel_KH.Children.Clear();
            foreach(Customer cc in list_cus)
            {
                Grid g = load_Grid_stack_panel(cc.CustomerID, cc.CustomerName, cc.CustomerPhone, cc.Address);
                this.stackpanel_KH.Children.Add(g);
            }
        }
        private Grid load_Grid_stack_panel(string customerID,string customerName,string sdt,string address)
        {
            Grid g = new Grid();
            g.Style = (Style)this.Resources["grid_food"];
            Border b = new Border();
            b.Style = (Style)this.Resources["border_KH"];
            TextBlock t1 = new TextBlock();
            t1.Style = (Style)this.Resources["txtblock_maKH"];
            t1.Text = customerID;
            TextBlock t2 = new TextBlock();
            t2.Text = customerName;
            t2.Style = (Style)this.Resources["txtblock_tenKH"];
            TextBlock t3 = new TextBlock();
            t3.Style = (Style)this.Resources["txtblock_sdtKH"];
            t3.Text = sdt;
            TextBlock t4 = new TextBlock();
            t4.Style = (Style)this.Resources["txtblock_diachiKH"];
            t4.Text = address;
            Button button= new Button();
            button.Style = (Style)this.Resources["button_viewdetailKH"];
            button.Click += view_button_click;
            g.Children.Add(b);
            g.Children.Add(t1);
            g.Children.Add(t2);
            g.Children.Add(t3);
            g.Children.Add(t4);
            g.Children.Add(button);
            return g;
        }
        private void view_button_click(object sender,RoutedEventArgs e)
        {
            var p = VisualTreeHelper.GetParent(e.Source as Button);
            TextBlock tt = (TextBlock)VisualTreeHelper.GetChild(p, 1);
            Customer customer = new Customer();
            foreach(Customer c in customers)
            {
                if (c.CustomerID == tt.Text)
                {
                    customer = c;
                    break;
                }
            }
            InfoCustomer ff = new InfoCustomer(customer);
            ff.ShowDialog();
            load_stack_panel(Xu_Ly_SQL.Select_all_Customers());
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            InfoCustomer infoCustomer = new InfoCustomer();
            infoCustomer.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            InfoCustomer infoCustomer = new InfoCustomer();
            infoCustomer.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            InfoCustomer infoCustomer = new InfoCustomer();
            infoCustomer.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            InfoCustomer infoCustomer = new InfoCustomer();
            infoCustomer.ShowDialog();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            InfoCustomer infoCustomer = new InfoCustomer();
            infoCustomer.ShowDialog();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            InfoCustomer infoCustomer = new InfoCustomer();
            infoCustomer.ShowDialog();
        }

        private void Setting_Click(object sender, RoutedEventArgs e)
        {
            Setting setting = new Setting();
            setting.ShowDialog();
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (BoLocComboBox.Text == "Tất cả" || BoLocComboBox.Text == "")
            {
                List<Customer> lst_cus = Xu_Ly_SQL.Search_customer("fullname", textbox_timkiem.Text);
                load_stack_panel(lst_cus);
            }
            else if (BoLocComboBox.Text == "sđt")
            {
                List<Customer> lst_cus = Xu_Ly_SQL.Search_customer("phone", textbox_timkiem.Text);
                load_stack_panel(lst_cus);
            }

        }

        private void button_them_Click(object sender, RoutedEventArgs e)
        {
            InfoCustomer f = new InfoCustomer();
            f.ShowDialog();
        }
    }
}
