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
            //List<Customer> list = Xu_Ly_SQL.
        }
        private Grid load_Grid_stack_panel(List<Customer> c)
        {
            Grid g = new Grid();
            g.Style = (Style)this.Resources["grid_food"];
            Border b = new Border();
            b.Style = (Style)this.Resources["border_KH"];
            TextBlock t1 = new TextBlock();
            t1.Style = (Style)this.Resources["txtblock_maKH"];
            TextBlock t2 = new TextBlock();
            t2.Style = (Style)this.Resources["txtblock_tenKH"];
            TextBlock t3 = new TextBlock();
            t3.Style = (Style)this.Resources["txtblock_sdtKH"];
            TextBlock t4 = new TextBlock();
            t4.Style = (Style)this.Resources["txtblock_diachiKH"];
            Button button= new Button();
            button.Style = (Style)this.Resources["button_viewdetailKH"];
            g.Children.Add(button);
            g.Children.Add(t1);
            g.Children.Add(t2);
            g.Children.Add(t3);
            g.Children.Add(t4);
            g.Children.Add(b);
            return g;
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
    }
}
