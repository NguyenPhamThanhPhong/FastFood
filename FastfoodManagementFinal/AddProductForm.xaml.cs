﻿using FastfoodManagementFinal.Models;
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
    /// Interaction logic for AddProductForm.xaml
    /// </summary>
    public partial class AddProductForm : Page
    {
        public AddProductForm()
        {
            InitializeComponent();
            
        }
        public List<Import> imps { get; set; } = Xu_Ly_SQL.Select_all_Import();
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Grid parent = (Grid) VisualTreeHelper.GetParent(e.Source as Button);
            TextBlock tb = VisualTreeHelper.GetChild(parent, 1) as TextBlock;
            foreach (Import ip in imps)
            {
                if (ip.ImportID == tb.Text)
                {
                    ViewPNH f = new ViewPNH(ip);
                    f.ShowDialog();
                    break;
                }
            }

        }



        private void Setting_Click(object sender, RoutedEventArgs e)
        {
            Setting setting = new Setting();
            setting.ShowDialog();
        }

        private void button_them_Click(object sender, RoutedEventArgs e)
        {
            Add_PNH f = new Add_PNH();
            f.ShowDialog();
            List<Import> lst_imp = Xu_Ly_SQL.Search_import("i.importID", txtbox_timkiem.Text.Trim());
            imps.Clear();
            foreach (Import ip in lst_imp)
            {
                imps.Add(ip);
            }
            listview_show.Items.Refresh();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(BoLocComboBox.SelectedIndex==0)
            {
                List<Import> lst_imp = Xu_Ly_SQL.Search_import("i.importID", txtbox_timkiem.Text.Trim());
                imps.Clear();
                foreach(Import ip in lst_imp) 
                {
                    imps.Add(ip);
                }
                listview_show.Items.Refresh();
                return;
            }
            if (BoLocComboBox.SelectedIndex == 1)
            {
                List<Import> lst_imp = Xu_Ly_SQL.Search_import("i.adminID", txtbox_timkiem.Text.Trim());
                imps.Clear();
                foreach (Import ip in lst_imp)
                {
                    imps.Add(ip);
                }
                listview_show.Items.Refresh();
                return;
            }
            if (BoLocComboBox.SelectedIndex == 2)
            {
                List<Import> lst_imp = Xu_Ly_SQL.Search_import("s.fullname", txtbox_timkiem.Text.Trim());
                imps.Clear();
                foreach (Import ip in lst_imp)
                {
                    imps.Add(ip);
                }
                listview_show.Items.Refresh();
                return;
            }
        }

        private void BoLocComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BoLocComboBox.SelectedIndex == 0)
            {
                List<Import> lst_imp = Xu_Ly_SQL.Search_import("i.importID", txtbox_timkiem.Text.Trim());
                imps.Clear();
                foreach (Import ip in lst_imp)
                {
                    imps.Add(ip);
                }
                listview_show.Items.Refresh();
                return;
            }
            if (BoLocComboBox.SelectedIndex == 1)
            {
                List<Import> lst_imp = Xu_Ly_SQL.Search_import("i.adminID", txtbox_timkiem.Text.Trim());
                imps.Clear();
                foreach (Import ip in lst_imp)
                {
                    imps.Add(ip);
                }
                listview_show.Items.Refresh();
                return;
            }
            if (BoLocComboBox.SelectedIndex == 2)
            {
                List<Import> lst_imp = Xu_Ly_SQL.Search_import("s.fullname", txtbox_timkiem.Text.Trim());
                imps.Clear();
                foreach (Import ip in lst_imp)
                {
                    imps.Add(ip);
                }
                listview_show.Items.Refresh();
                return;
            }
        }
    }
}
