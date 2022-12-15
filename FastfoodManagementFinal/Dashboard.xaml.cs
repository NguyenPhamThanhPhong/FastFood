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
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        private Account logged_in_acc;
        public Dashboard(Account a)
        {
            InitializeComponent();
            PagesNavigation.Navigate(new System.Uri("HomeForm.xaml", UriKind.RelativeOrAbsolute));
            logged_in_acc = a;
            txtBlock_Acc_Name.Text = logged_in_acc.Name;
            txtBlock_AccessRight.Text = logged_in_acc.AccessRight;
            logged_in_avatar.Source = new BitmapImage(new Uri(Xu_ly_Anh.GetAnh(Xu_ly_Anh.AccountAvatar,a.Avatar)));
        }
        public string abc = "abc";

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           // page.NavigationService.Navigate(new Page("passing a string to the constructor"));
            //HomeForm
            PagesNavigation.Navigate(new System.Uri("HomeForm.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("ProductForm.xaml", UriKind.RelativeOrAbsolute));

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("CartForm.xaml", UriKind.RelativeOrAbsolute));

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("CustomerFormxaml.xaml", UriKind.RelativeOrAbsolute));

        }

        

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("StatisticalForm.xaml", UriKind.RelativeOrAbsolute));

        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("AddProductForm.xaml", UriKind.RelativeOrAbsolute));

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("ManageForm.xaml", UriKind.RelativeOrAbsolute));

        }
    }
}
