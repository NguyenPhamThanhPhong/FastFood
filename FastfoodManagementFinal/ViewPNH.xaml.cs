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
using System.Windows.Shapes;

namespace FastfoodManagementFinal
{
    /// <summary>
    /// Interaction logic for ViewPNH.xaml
    /// </summary>
    public partial class ViewPNH : Window
    {
        public ViewPNH()
        {
            InitializeComponent();
        }
        public ViewPNH(Import ip)
        {
            InitializeComponent();
            int total = 0;
            txtbox_date.Text = ip.ImportDate.ToString("dd/MM/yyyy");
            txtbox_maImport.Text = ip.ImportID;
            txtbox_maNV.Text = ip.AdminID + " " + ip.AdminName;
            foreach(ImportProduct ipp in ip.importProducts)
            {
                imps.Add(ipp);
                total += (ipp.ImportProductPrice * ipp.ImportQuantity);
            }
            txtblock_total.Text = total.ToString();
        }
        public List<ImportProduct> imps { get; set; } = new List<ImportProduct>();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
