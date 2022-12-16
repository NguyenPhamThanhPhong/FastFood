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
    /// Interaction logic for ProductForm.xaml
    /// </summary>
    public partial class ProductForm : Page
    {
        public ProductForm()
        {
            InitializeComponent();
            List <Product> pp = Xu_Ly_SQL.Select_all_product();
            Xu_ly_ScrollViewer(pp);
            List<string> str = Xu_Ly_SQL.Select_distinct_ProductType();
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
            { i3.Source = new BitmapImage(new Uri(Xu_ly_Anh.GetAnh(Xu_ly_Anh.ProductAvatar, avt_food))); }
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewProduct NewProduct = new NewProduct();
            NewProduct.ShowDialog();
           
        }

        private void chitiet7_Click(object sender, RoutedEventArgs e)
        {
            DetailSP detailSP = new DetailSP();
            detailSP.ShowDialog();
        }

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
    }
}
