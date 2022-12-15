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
    /// Interaction logic for HomeForm.xaml
    /// </summary>
    public partial class HomeForm : Page
    {
        public HomeForm()
        {
            InitializeComponent();
            txtblock_today_order.Text = Xu_Ly_SQL.Select_today_Orders().ToString();
            txtblock_today_sales.Text = Xu_Ly_SQL.Select_today_sales().ToString() + "VND";
            txtblock_today_sell_quantity.Text = Xu_Ly_SQL.Select_today_sold_product().ToString();
        }
    }
}
