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
            //load_stack_panel(customers);
        }
        public List<Customer> customers { get; set; } = Xu_Ly_SQL.Select_all_Customers();


        private void view_button_click(object sender,RoutedEventArgs e)
        {
            var p = VisualTreeHelper.GetParent(e.Source as Button);
            TextBlock tt = (TextBlock)VisualTreeHelper.GetChild(p, 1);
            Customer customer = new Customer();
            foreach (Customer c in customers)
            {
                if (c.CustomerID == tt.Text)
                {
                    customer = c;
                    break;
                }
            }

            InfoCustomer ff = new InfoCustomer(customer);
            ff.ShowDialog();

            List<Customer> list_cus = Xu_Ly_SQL.Select_all_Customers();
            customers.Clear();
            foreach(Customer c in list_cus)
            {
                customers.Add(c);
            }
            listview_show.Items.Refresh();
            //load_stack_panel(Xu_Ly_SQL.Select_all_Customers());
        }


        private void Setting_Click(object sender, RoutedEventArgs e)
        {
            Setting setting = new Setting();
            setting.ShowDialog();
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (BoLocComboBox.SelectedIndex == 0 || BoLocComboBox.SelectedIndex == 1)
            {
                List<Customer> lst_cus = Xu_Ly_SQL.Search_customer("fullname", textbox_timkiem.Text);
                customers.Clear();
                foreach (Customer c in lst_cus)
                {
                    customers.Add(c);
                }
                listview_show.Items.Refresh();
            }
            else if (BoLocComboBox.SelectedIndex == 2)
            {
                List<Customer> lst_cus = Xu_Ly_SQL.Search_customer("phone", textbox_timkiem.Text);
                customers.Clear();
                foreach (Customer c in lst_cus)
                {
                    customers.Add(c);
                }
                listview_show.Items.Refresh();
            }

        }

        private void button_them_Click(object sender, RoutedEventArgs e)
        {
            InfoCustomer f = new InfoCustomer();
            f.ShowDialog();
            if (BoLocComboBox.SelectedIndex == 0 || BoLocComboBox.SelectedIndex == 1)
            {
                List<Customer> lst_cus = Xu_Ly_SQL.Search_customer("fullname", textbox_timkiem.Text);
                customers.Clear();
                foreach (Customer c in lst_cus)
                {
                    customers.Add(c);
                }
                listview_show.Items.Refresh();
            }
            else if (BoLocComboBox.SelectedIndex == 2)
            {
                List<Customer> lst_cus = Xu_Ly_SQL.Search_customer("phone", textbox_timkiem.Text);
                customers.Clear();
                foreach (Customer c in lst_cus)
                {
                    customers.Add(c);
                }
                listview_show.Items.Refresh();
            }
        }

        private void BoLocComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BoLocComboBox.SelectedIndex == 0 || BoLocComboBox.SelectedIndex == 1)
            {
                List<Customer> lst_cus = Xu_Ly_SQL.Search_customer("fullname", textbox_timkiem.Text);
                customers.Clear();
                foreach (Customer c in lst_cus)
                {
                    customers.Add(c);
                }
                listview_show.Items.Refresh();
            }
            else if (BoLocComboBox.SelectedIndex == 2)
            {
                List<Customer> lst_cus = Xu_Ly_SQL.Search_customer("phone", textbox_timkiem.Text.Trim());
                customers.Clear();
                foreach (Customer c in lst_cus)
                {
                    customers.Add(c);
                }
                listview_show.Items.Refresh();
            }
        }

        //private void Button_Click_6(object sender, RoutedEventArgs e)
        //{

        //}
    }
}
