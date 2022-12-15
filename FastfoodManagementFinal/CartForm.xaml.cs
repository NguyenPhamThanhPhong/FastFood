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
    /// Interaction logic for CartForm.xaml
    /// </summary>
    public partial class CartForm : Page
    {
        public CartForm()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ViewDH viewDH = new ViewDH();
            viewDH.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CreateHD createHD = new CreateHD();
            createHD.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            CreateHD createHD = new CreateHD();
            createHD.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            CreateHD createHD = new CreateHD();
            createHD.ShowDialog();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            CreateHD createHD = new CreateHD();
            createHD.ShowDialog();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            CreateHD createHD = new CreateHD();
            createHD.ShowDialog();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            CreateHD createHD = new CreateHD();
            createHD.ShowDialog();
        }

        private void Setting_Click(object sender, RoutedEventArgs e)
        {
            Setting setting = new Setting();
            setting.ShowDialog();
        }
    }
}
