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
            //List_acc = Xu_Ly_SQL.Select_all_Account();
            FindAvatar();
            
        }
        public List<Account> List_acc { get; set; } = Xu_Ly_SQL.Select_all_Account();

        public void FindAvatar()
        {
            List<string> str = new List<string>();
            foreach (Account a in List_acc)
            {
                a.Avatar = Xu_ly_Anh.GetAnh(Xu_ly_Anh.AccountAvatar, a.Avatar);
                a.LoadAvatar();
            }
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
            
            foreach (Account a in List_acc)
            {
                if (a.StaffID == tt.Text)
                {
                    ((Image)VisualTreeHelper.GetChild(p, 1)).Source = null;
                    GC.Collect();

                    InfoNV ff = new InfoNV(a);
                    ff.ShowDialog();

                    // Load list view lai
                    List<Account>aaa = Xu_Ly_SQL.Select_all_Account();
                    List_acc.Clear();
                    foreach (Account aa in aaa)
                    {
                        List_acc.Add(aa);
                    }
                    FindAvatar();
                    listview_show.Items.Refresh();



                    break;
                }
            }
        }



        private void Setting_Click(object sender, RoutedEventArgs e)
        {
            Setting setting = new Setting();
            setting.ShowDialog();
        }

        private void TextChanged()
        {
            
            //Load_stack_panel(list_acc);
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string search_by = "ID";
            if (BoLocComboBox.SelectedIndex == 1)
            {
                search_by = "Fullname";
            }
            else if (BoLocComboBox.SelectedIndex == 2)
            {
                search_by = "Phone";
            }
            string parameter = textbox_timkiem.Text.Trim();

            List<Account> aaa = Xu_Ly_SQL.Search_staff(parameter, search_by);

            List_acc.Clear();
            foreach (Account a in aaa)
            {
                List_acc.Add(a);
            }
            FindAvatar();
            listview_show.Items.Refresh();
        }

        private void eye1_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
