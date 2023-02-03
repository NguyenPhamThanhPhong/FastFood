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
        public ObservableCollection<Bill> bills { get; set; } = new ObservableCollection<Bill>(Xu_Ly_SQL.Select_all_Bill());

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ViewDH viewDH = new ViewDH();
            viewDH.ShowDialog();
            string orderby = this.FindOrderby();
            string parameter = txtbox_timkiem.Text.Trim();
            //MessageBox.Show(orderby + parameter);
            load_list(Xu_Ly_SQL.Search_bill_hoten(orderby, parameter));
        }
        private void load_list(List<Bill> bb)
        {
            bills.Clear();
            foreach(Bill b in bb) 
            {
                bills.Add(b);
            }
            //MessageBox.Show(bills.Count.ToString());
        }
        private string FindOrderby()
        {
            string orderby = "hoten";
            switch(BoLocComboBox.SelectedIndex) 
            {
                case 1:
                    orderby = "sdt";
                    break;
                default:
                    break;
            }
            return orderby;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Grid parent = (Grid)VisualTreeHelper.GetParent(e.Source as Button);
            TextBlock tt = (TextBlock)parent.Children[1];
            foreach(Bill b in bills)
            {
                if(b.Bill_ID == tt.Text)
                {
                    //MessageBox.Show(b.StaffID + " | " + b.StaffName);
                    //MessageBox.Show(b.CustomerID + " | " + b.CustomerName);

                    CreateHD createHD = new CreateHD(b);
                    createHD.ShowDialog();

                    string orderby = this.FindOrderby();
                    string parameter = txtbox_timkiem.Text.Trim();
                    //MessageBox.Show(orderby + parameter);
                    load_list(Xu_Ly_SQL.Search_bill_hoten(orderby, parameter));
                    return;
                }
            }    
            
        }
        private void Setting_Click(object sender, RoutedEventArgs e)
        {
            Setting setting = new Setting();
            setting.ShowDialog();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string orderby = this.FindOrderby();
            string parameter = txtbox_timkiem.Text.Trim();
            load_list(Xu_Ly_SQL.Search_bill_hoten(orderby, parameter));
        }

        private void BoLocComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string orderby = this.FindOrderby();
            string parameter = txtbox_timkiem.Text.Trim();
            load_list(Xu_Ly_SQL.Search_bill_hoten(orderby, parameter));
        }
    }
}
