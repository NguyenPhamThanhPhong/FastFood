using FastfoodManagementFinal.Models;
using FastfoodManagementFinal.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        //private Grid Load_Grid(Account acc)
        //{
        //    //Grid g = new Grid();
        //    //g.Style = (Style)this.Resources["grid_NV"];
        //    //Image i1 = new Image();
        //    //i1.Style = (Style)this.Resources["image"];
        //    //Image i2 = new Image();
        //    //i2.Style = (Style)this.Resources["image_NV"];
        //    //Image i3 = new Image();
        //    //i3.Style = (Style)this.Resources["image_MaMV"];
        //    //TextBlock t1 = new TextBlock();
        //    //t1.Style = (Style)this.Resources["txtblock_MaNV"];
        //    //t1.Text = ten;

        //    //TextBlock t2 = new TextBlock();
        //    //t2.Style = (Style)this.Resources["txtblock_TenNV"];

        //    //TextBlock t3 = new TextBlock();
        //    //t3.Style = (Style)this.Resources["txtblock_SĐT"];
            
        //    //TextBlock t4 = new TextBlock();
        //    //t3.Style = (Style)this.Resources["txtblock_ĐC"];




        //    //if (Xu_ly_Anh.GetAnh(Xu_ly_Anh.ProductAvatar, avt_food) != "")
        //    //{ i3.Source = new BitmapImage(new Uri(Xu_ly_Anh.GetAnh(Xu_ly_Anh.ProductAvatar, avt_food))); }

            

        //    //a2.Text = gia.ToString();
        //    //TextBlock a3 = new TextBlock();
        //    //a3.Style = (Style)this.Resources["txtblock_chitiet"];
        //    //a3.Text = "chi tiết";
        //    //Button b = new Button();
        //    //b.Style = (Style)this.Resources["button_chitiet"];
        //    //g.Children.Add(i1);
        //    //g.Children.Add(i2);
        //    //g.Children.Add(i3);
        //    //g.Children.Add(i4);
        //    //g.Children.Add(b);
        //    //g.Children.Add(a1);
        //    //g.Children.Add(a2);
        //    //g.Children.Add(a3);
        //    //return g;
        //}

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
