using FastfoodManagementFinal.Models;
using FastfoodManagementFinal.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
    /// Interaction logic for ProductForm.xaml
    /// </summary>
    public partial class ProductForm : Page
    {
        public ProductForm()
        {
            InitializeComponent();
            List<string> str = Xu_Ly_SQL.Select_distinct_ProductType();
            BoLocComboBox.Items.Clear();
            foreach (string s in str)
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Content = s;
                BoLocComboBox.Items.Add(cbi);
            }
            //Load_Stuff();
            //MessageBox.Show(pros.Count.ToString());
        }
        public ObservableCollection<Product> pros { get; set; } = new ObservableCollection<Product>(new List<Product>());
        private void Load_Stuff(List<Product> pp)
        {
            List<string> str = Xu_Ly_SQL.Select_distinct_ProductType();
            BoLocComboBox.Items.Clear();
            foreach (string s in str)
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Content = s;
                BoLocComboBox.Items.Add(cbi);
            }

            pros.Clear();
            foreach (Product p in pp)
            {
                pros.Add(p);
            }
        }
        private void load_list(List<Product> pp)
        {
            pros.Clear();
            foreach (Product p in pp)
            {
                pros.Add(p);
            }
        }
        private string Find_orderby()
        {
            string order_by = "productName asc";
            switch (SapXepComboBox.SelectedIndex)
            {
                case 1:
                    order_by = "productPrice asc";
                    break;
                case 2:
                    order_by = "RemainingQuantity asc";
                    break;
                default:
                    break;
            }
            return order_by;
        }
        private void Xu_ly_ScrollViewer(List<Product> pp)
        {
            ////this.stack_panel_food.Children.Clear();
            //StackPanel stkpn = new StackPanel();
            //for (int i = 0; i < pp.Count; i++)
            //{
            //    if (i % 4 == 0)
            //    {
            //        stkpn = new StackPanel();
            //        stkpn.Orientation = Orientation.Horizontal;
            //        //this.stack_panel_food.Children.Add(stkpn);
            //    }
            //    stkpn.Children.Add(Food_Grid(pp[i].Name, pp[i].Price, pp[i].Avatar));
            //}
            
        }

        private void Button_view_ChiTiet(object sender, RoutedEventArgs e)
        {
            var parent = (Grid)VisualTreeHelper.GetParent(e.Source as Button);
            TextBlock a1 = (TextBlock)parent.Children[3];
            List<Product> products = Xu_Ly_SQL.Select_all_product();
            foreach (Product p in products)
            {
                if (p.Name == a1.Text)
                {
                    ((Image)VisualTreeHelper.GetChild(parent, 2)).Source = null;
                    GC.Collect();
                    Selected.product = p;
                    NewProduct f = new NewProduct(p);
                    f.ShowDialog();

                    if(Selected.product.Product_Type.ToLower()!=p.Product_Type.ToLower())
                    {
                        Load_Stuff(Xu_Ly_SQL.Select_all_product());
                    }
                    else
                    {
                        string order_by = Find_orderby();
                        load_list(Xu_Ly_SQL.Search_Product(BoLocComboBox.Text,
                            order_by, txtbox_timkiem.Text));
                        
                    }
                    break;
                }
            }
        }
        //button them SP
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewProduct NewProduct = new NewProduct();
            NewProduct.ShowDialog();
            string order_by = Find_orderby();
            string current = BoLocComboBox.Text;
            Load_Stuff(Xu_Ly_SQL.Search_Product(BoLocComboBox.Text,
                order_by, txtbox_timkiem.Text));
            for(int i=0;i<BoLocComboBox.Items.Count;i++)
            {
                ComboBoxItem cbi = (ComboBoxItem)BoLocComboBox.Items[i];
                if (cbi.Content.ToString() == current)
                    BoLocComboBox.SelectedIndex = i;
            }
            //Load_Stuff(Xu_Ly_SQL.Select_all_product());
        }



        private void Setting_Click(object sender, RoutedEventArgs e)
        {
            Setting setting = new Setting();
            setting.ShowDialog();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string order_by = Find_orderby();
            load_list(Xu_Ly_SQL.Search_Product(BoLocComboBox.Text,
                order_by, txtbox_timkiem.Text));
        }

        private void BoLocComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cbi = (sender as ComboBox).SelectedItem as ComboBoxItem;
            if (cbi == null)
            {
                return;
            }
            string order_by = "productName asc";
            switch (SapXepComboBox.SelectedIndex)
            {
                case 1:
                    order_by = "productPrice asc";
                    break;
                case 2:
                    order_by = "RemainingQuantity asc";
                    break;
                default:
                    break;
            }
            //ComboBoxItem cbi = (sender as ComboBox).SelectedItem as ComboBoxItem;
            if (cbi != null)
            {
                string text = cbi.Content.ToString();
                load_list(Xu_Ly_SQL.Search_Product(text,
                    order_by, txtbox_timkiem.Text));
            }
        }

        private void SapXepComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string order_by = "productName asc";
            switch (SapXepComboBox.SelectedIndex)
            {
                case 1:
                    order_by = "productPrice asc";
                    break;
                case 2:
                    order_by = "RemainingQuantity asc";
                    break;
                default:
                    break;
            }
            load_list(Xu_Ly_SQL.Search_Product(BoLocComboBox.Text,
                order_by, txtbox_timkiem.Text));
        }
    }
}
