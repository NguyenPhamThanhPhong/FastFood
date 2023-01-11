using FastfoodManagementFinal.Models;
using FastfoodManagementFinal.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
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
            Load_stack_panel(List_acc);

        }
        List<Account> List_acc = Xu_Ly_SQL.Select_all_Account();
        private void Load_stack_panel(List<Account> accounts)
        {
            this.stack_panel_quanly.Children.Clear();
            foreach (StackPanel stk in stack_panel_quanly.Children)
            {
                stk.Children.Clear();
            }
            StackPanel ss = new StackPanel();
            for (int i=0;i<accounts.Count; i++)
            {
                if(i%2==0)
                {
                    ss = new StackPanel();
                    ss.Orientation = Orientation.Horizontal;
                    stack_panel_quanly.Children.Add(ss);
                }
                ss.Children.Add(Load_Grid(accounts[i]));
            }
        }
        private Grid Load_Grid(Account acc)
        {
            Grid g = new Grid();
            g.Style = (Style)this.Resources["grid_NV"];
            Image i1 = new Image();
            i1.Style = (Style)this.Resources["image"];
            Image i2 = new Image();
            i2.Style = (Style)this.Resources["image_NV"];
            if (Xu_ly_Anh.GetAnh(Xu_ly_Anh.AccountAvatar,acc.Avatar ) != "")
            {
                i2.Source = null;
                GC.Collect();

                Uri u = new Uri(Xu_ly_Anh.GetAnh(Xu_ly_Anh.AccountAvatar, acc.Avatar));
                
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.CacheOption = BitmapCacheOption.OnLoad;
                bi.UriSource = u ;
                bi.EndInit();
                i2.Source = bi;

                u = null;
                bi = null;
                GC.Collect();
            }

            Image i3 = new Image();
            //i3.Style = (Style)this.Resources["image_MaMV"];

            TextBlock t1 = new TextBlock();
            t1.Style = (Style)this.Resources["txtblock_MaNV"];
            t1.Text = acc.StaffID.ToString();

            TextBlock t2 = new TextBlock();
            t2.Style = (Style)this.Resources["txtblock_TenNV"];
            t2.Text = acc.Name.ToString();

            TextBlock t3 = new TextBlock();
            t3.Style = (Style)this.Resources["txtblock_SĐT"];

            TextBlock t4 = new TextBlock();
            t4.Style = (Style)this.Resources["txtblock_ĐC"];

            TextBlock t5 = new TextBlock();
            t5.Style = (Style)this.Resources["txtblock_SĐTNV"];
            t5.Text = acc.Phone_Number.ToString();

            TextBlock t6 = new TextBlock();
            t6.Style = (Style)this.Resources["txtblock_ĐCNV"];
            t6.Text = acc.address.ToString();

            Button button = new Button();
            button.Style = (Style)this.Resources["button_viewdetailNV"];
            button.Click += eye_Click;

            //
            //ImageBrush img = new ImageBrush();
            //string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName+"\\IMAGE"+ "\\eye-2-128.png";
            //img.ImageSource = new BitmapImage(new Uri(path));
            //
            //button.Content = button.Background;



            g.Children.Add(i1);
            g.Children.Add(i2);
            g.Children.Add(i3);
            g.Children.Add(t1);
            g.Children.Add(t2);
            g.Children.Add(t3);
            g.Children.Add(t4);
            g.Children.Add(t5);
            g.Children.Add(t6);
            g.Children.Add(button);
            return g;
        }
        public void dispose(object o)
        {
            o = null;
            GC.Collect();
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ViewNV viewNV = new ViewNV();
            viewNV.ShowDialog();
        }

        private void eye_Click(object sender, RoutedEventArgs e)
        {
            var p = VisualTreeHelper.GetParent(e.Source as Button);
            TextBlock tt = (TextBlock)VisualTreeHelper.GetChild(p, 3);

            Image i = null;
            foreach (Account a in List_acc)
            {
                if(a.StaffID == tt.Text)
                {
                    ((Image)VisualTreeHelper.GetChild(p, 1)).Source = null;
                    GC.Collect();

                    InfoNV ff = new InfoNV(a);
                    ff.ShowDialog();
                    Load_stack_panel(Xu_Ly_SQL.Select_all_Account());
                    break;
                }
            }
        }

        //private void eye2_Click(object sender, RoutedEventArgs e)
        //{
        //    InfoNV infoNV = new InfoNV();
        //    infoNV.ShowDialog();
        //}

        //private void eye3_Click(object sender, RoutedEventArgs e)
        //{
        //    InfoNV infoNV = new InfoNV();
        //    infoNV.ShowDialog();
        //}

        //private void eye4_Click(object sender, RoutedEventArgs e)
        //{
        //    InfoNV infoNV = new InfoNV();
        //    infoNV.ShowDialog();
        //}
        //private void eye5_Click(object sender, RoutedEventArgs e)
        //{
        //    InfoNV infoNV = new InfoNV();
        //    infoNV.ShowDialog();
        //}
        //private void eye6_Click(object sender, RoutedEventArgs e)
        //{
        //    InfoNV infoNV = new InfoNV();
        //    infoNV.ShowDialog();
        //}

        private void Setting_Click(object sender, RoutedEventArgs e)
        {
            Setting setting = new Setting();
            setting.ShowDialog();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string search_by = "ID";
            if(BoLocComboBox.SelectedIndex == 1)
            {
                search_by = "Fullname";
            }
            else if(BoLocComboBox.SelectedIndex == 2)
            {
                search_by = "Phone";
            }
            string parameter = textbox_timkiem.Text.Trim();
            List<Account> list_acc = Xu_Ly_SQL.Search_staff(parameter, search_by);
            Load_stack_panel(list_acc);
        }
    }
}
