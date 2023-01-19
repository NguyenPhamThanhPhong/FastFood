using FastfoodManagementFinal.Models;
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
            bills.Add(new Bill() { Bill_ID= "alskdj"});
            bills.Add(new Bill());
            MessageBox.Show( bills.Count().ToString());

            listviewBill.Items.Refresh();
        }
        public List<Bill> bills { get; set; } = new List<Bill>();

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





        private void Setting_Click(object sender, RoutedEventArgs e)
        {
            Setting setting = new Setting();
            setting.ShowDialog();
        }
    }
}
