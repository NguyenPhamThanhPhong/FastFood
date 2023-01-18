using FastfoodManagementFinal.Models;
using FastfoodManagementFinal.ViewModel;
using System;
using System.Collections.Generic;
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

            Load_Stuff();
        }
        private void Load_Stuff()
        {
            List<Product> pp = Xu_Ly_SQL.Select_all_product();
            Xu_ly_ScrollViewer(pp);
            List<string> str = Xu_Ly_SQL.Select_distinct_ProductType();
            BoLocComboBox.Items.Clear();
            foreach (string s in str)
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Content = s;
                BoLocComboBox.Items.Add(cbi);
            }
        }
        private void Xu_ly_ScrollViewer(List<Product> pp)
        {
            this.stack_panel_food.Children.Clear();
            StackPanel stkpn = new StackPanel();
            for (int i = 0; i < pp.Count; i++)
            {
                if (i % 4 == 0)
                {
                    stkpn = new StackPanel();
                    stkpn.Orientation = Orientation.Horizontal;
                    this.stack_panel_food.Children.Add(stkpn);
                }
                stkpn.Children.Add(Food_Grid(pp[i].Name, pp[i].Price, pp[i].Avatar));
            }
            
        }
        private Grid Food_Grid(string ten, int gia, string avt_food)
        {
            Grid g = new Grid();
            g.Style = (Style)this.Resources["grid_food"];
            Image i1 = new Image();
            i1.Style = (Style)this.Resources["image1"];
            Image i2 = new Image();
            i2.Style = (Style)this.Resources["image2"];
            Image i3 = new Image();
            i3.Style = (Style)this.Resources["image_food"];
            if (Xu_ly_Anh.GetAnh(Xu_ly_Anh.ProductAvatar, avt_food) != "")
            {
                i3.Source = null;
                GC.Collect();

                Uri u = new Uri(Xu_ly_Anh.GetAnh(Xu_ly_Anh.ProductAvatar, avt_food));

                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.CacheOption = BitmapCacheOption.OnLoad;
                bi.UriSource = u;
                bi.EndInit();
                i3.Source = bi;

                u = null;
                bi = null;
                GC.Collect();
            }
            Image i4 = new Image();
            i4.Style = (Style)this.Resources["image_price"];
            TextBlock a1 = new TextBlock();
            a1.Style = (Style)this.Resources["txtblock_foodname"];
            a1.Text = ten;
            TextBlock a2 = new TextBlock();
            a2.Style = (Style)this.Resources["txtblock_price"];
            a2.Text = gia.ToString();
            TextBlock a3 = new TextBlock();
            a3.Style = (Style)this.Resources["txtblock_chitiet"];
            a3.Text = "chi tiết";
            Button b = new Button();
            b.Style = (Style)this.Resources["button_chitiet"];
            b.Click += Button_view_ChiTiet;


            g.Children.Add(i1);
            g.Children.Add(i2);
            g.Children.Add(i3);
            g.Children.Add(i4);
            g.Children.Add(b);
            g.Children.Add(a1);
            g.Children.Add(a2);
            g.Children.Add(a3);
            return g;
        }

        private void Button_view_ChiTiet(object sender, RoutedEventArgs e)
        {
            var parent = (Grid)VisualTreeHelper.GetParent(e.Source as Button);
            TextBlock a1 = (TextBlock)parent.Children[5];
            List<Product> products = Xu_Ly_SQL.Select_all_product();
            foreach (Product p in products)
            {
                if (p.Name == a1.Text)
                {
                    ((Image)VisualTreeHelper.GetChild(parent, 2)).Source = null;
                    GC.Collect();
                    NewProduct f = new NewProduct(p);
                    f.ShowDialog();
                    Load_Stuff();
                    break;
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewProduct NewProduct = new NewProduct();
            NewProduct.ShowDialog();
            Load_Stuff();
        }

        //private void chitiet7_Click(object sender, RoutedEventArgs e)
        //{
        //    DetailSP detailSP = new DetailSP();
        //    detailSP.ShowDialog();
        //}

        private void Setting_Click(object sender, RoutedEventArgs e)
        {
            Setting setting = new Setting();
            setting.ShowDialog();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string order_by = "productName asc";
            if(Xu_ly_chuoi.Sang_chuoi_khong_dau( SapXepComboBox.Text).ToLower() == "ten"
                || SapXepComboBox.Text=="")
            {
                order_by = "productName asc";
            }
            else if(Xu_ly_chuoi.Sang_chuoi_khong_dau(SapXepComboBox.Text).ToLower() == "gia")
            {
                order_by = "productPrice asc";
            }
            Xu_ly_ScrollViewer( Xu_Ly_SQL.Search_Product(BoLocComboBox.Text, 
                order_by, txtbox_timkiem.Text));
        }

        private void BoLocComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string sss = ((ComboBoxItem)(BoLocComboBox.SelectedItem)).Content.ToString();
                //MessageBox.Show(SapXepComboBox.SelectedIndex.ToString());
                string sapxep = "";
                if (SapXepComboBox.SelectedIndex > 0)
                {
                    sapxep = ((ComboBoxItem)(SapXepComboBox.SelectedItem)).Content.ToString();
                }
                string order_by = "productName asc";
                //if (Xu_ly_chuoi.Sang_chuoi_khong_dau(sapxep).ToLower() == "ten"
                //    || SapXepComboBox.Text == "")
                //{
                //    order_by = "productName asc";
                //}
                if (sapxep.Trim() == "Giá")
                {
                    order_by = "productPrice asc";
                }
                Xu_ly_ScrollViewer(Xu_Ly_SQL.Search_Product(sss,
                    order_by, txtbox_timkiem.Text));
            }
            catch
            {

            }
            
        }

        private void SapXepComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string sss = "";
                if (BoLocComboBox.SelectedIndex > 0)
                {
                    sss = ((ComboBoxItem)(BoLocComboBox.SelectedItem)).Content.ToString();
                }
                //MessageBox.Show(SapXepComboBox.SelectedIndex.ToString());
                string sapxep = ((ComboBoxItem)(SapXepComboBox.SelectedItem)).Content.ToString();
                string order_by = "productName asc";

                if (sapxep.Trim()== "Giá")
                {
                    order_by = "productPrice asc";
                }
                Xu_ly_ScrollViewer(Xu_Ly_SQL.Search_Product(sss,
                    order_by, txtbox_timkiem.Text));
            }
            catch
            {

            }
        }
    }
}
