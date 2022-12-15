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
    /// Interaction logic for ManageForm.xaml
    /// </summary>
    public partial class ManageForm : Page
    {
        public ManageForm()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ViewNV viewNV = new ViewNV();
            viewNV.ShowDialog();
        }

        private void eye1_Click(object sender, RoutedEventArgs e)
        {
            InfoNV infoNV = new InfoNV();
            infoNV.ShowDialog();
        }

        private void eye2_Click(object sender, RoutedEventArgs e)
        {
            InfoNV infoNV = new InfoNV();
            infoNV.ShowDialog();
        }

        private void eye3_Click(object sender, RoutedEventArgs e)
        {
            InfoNV infoNV = new InfoNV();
            infoNV.ShowDialog();
        }

        private void eye4_Click(object sender, RoutedEventArgs e)
        {
            InfoNV infoNV = new InfoNV();
            infoNV.ShowDialog();
        }
        private void eye5_Click(object sender, RoutedEventArgs e)
        {
            InfoNV infoNV = new InfoNV();
            infoNV.ShowDialog();
        }
        private void eye6_Click(object sender, RoutedEventArgs e)
        {
            InfoNV infoNV = new InfoNV();
            infoNV.ShowDialog();
        }

        private void Setting_Click(object sender, RoutedEventArgs e)
        {
            Setting setting = new Setting();
            setting.ShowDialog();
        }
    }
}
