using FastfoodManagementFinal.Models;
using FastfoodManagementFinal.ViewModel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Cache;
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
    /// Interaction logic for StatisticalForm.xaml
    /// </summary>
    public partial class StatisticalForm : Page
    {
        public StatisticalForm()
        {
            InitializeComponent();
            txtbox_hoten.Text = Selected.LoggedIn.Name;
            txtbox_gioitinh.Text = Selected.LoggedIn.Sex;
            txtbox_sdt.Text = Selected.LoggedIn.Phone_Number;
            txtbox_diachi.Text = Selected.LoggedIn.address;
            txtbox_mail.Text= Selected.LoggedIn.Email;
            txtbox_tenDN.Text = Selected.LoggedIn.Username;
            datepicker_ngaysinh.SelectedDate = Selected.LoggedIn.DateOfBirth;
            //this.avt_img.Source = null;
            //GC.Collect();
            //Uri u = new Uri());

            BitmapImage _image = new BitmapImage();
            _image.BeginInit();
            _image.CacheOption = BitmapCacheOption.None;
            _image.UriCachePolicy = new RequestCachePolicy(RequestCacheLevel.BypassCache);
            _image.CacheOption = BitmapCacheOption.OnLoad;
            _image.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
            _image.UriSource = new Uri(Xu_ly_Anh.GetAnh(Xu_ly_Anh.AccountAvatar, Selected.LoggedIn.Avatar), UriKind.RelativeOrAbsolute);
            _image.EndInit();
            this.avt_img.Source = _image;
        }
        string avatar_path = "";
        string Mailcode;
        private void Setting_Click(object sender, RoutedEventArgs e)
        {
            Setting setting = new Setting();
            setting.ShowDialog();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|all files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true && openFileDialog.CheckFileExists == true)
            {
                string temp = openFileDialog.FileName;
                if (temp.Length > 0 && temp != null)
                {
                    avatar_path = temp;
                }
                else
                    return;
            }
            if(avatar_path!=null && avatar_path.Length>0)
            {
                FileInfo fileInfo = new FileInfo(avatar_path);
                if (!(fileInfo.Exists) || (fileInfo.Extension != ".jpg" && fileInfo.Extension != ".png"))
                {
                    MessageBox.Show("chon file anh thich hop!");
                }
                else
                {
                    if (new FileInfo(Xu_ly_Anh.GetAnh(Xu_ly_Anh.AccountAvatar, avatar_path)).Exists)
                    {
                        Uri u = new Uri(avatar_path);
                        BitmapImage b = new BitmapImage();
                        b.BeginInit();
                        b.CacheOption = BitmapCacheOption.OnLoad;
                        b.UriSource = u;
                        b.EndInit();
                        this.avt_img.Source = b;
                    }
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Account a = new Account();
            a.AccessRight = Selected.LoggedIn.AccessRight;
            a.Name = txtbox_hoten.Text.Trim();
            a.Sex = txtbox_gioitinh.Text.Trim();
            a.DateOfBirth = datepicker_ngaysinh.SelectedDate.Value;
            a.Phone_Number = txtbox_sdt.Text.Trim();
            a.Username = Selected.LoggedIn.Username;
            a.Pass = Selected.LoggedIn.Pass;
            //Gan mail
            if(txtbox_maXN.Visibility == Visibility.Hidden)
            {
                a.Email = txtbox_mail.Text.Trim();
            }
            else
            {
                if (txtbox_maXN.Text.Trim() != Mailcode)
                {
                    MessageBox.Show("Mã email ko hợp lệ");
                    return;
                }
            }
            a.address = txtbox_diachi.Text.Trim();

            if(a.Is_valid() == true)
            {
                a.StaffID = Selected.LoggedIn.StaffID;
                a.Avatar = a.StaffID + ".png";
                Xu_Ly_SQL.Update_Staff(a);
                Dashboard db = (Dashboard)Window.GetWindow(this);
                db.txtBlock_Acc_Name.Text = txtbox_hoten.Text;
                if (avatar_path.Length > 0 && avatar_path != null)
                {
                    FileInfo fi = new FileInfo(avatar_path);
                    if (fi.Exists)
                    {
                        Xu_ly_Anh.LuuAnh(avatar_path, Xu_ly_Anh.AccountAvatar, a.Avatar);
                        BitmapImage _image = new BitmapImage();
                        _image.BeginInit();
                        _image.CacheOption = BitmapCacheOption.None;
                        _image.UriCachePolicy = new RequestCachePolicy(RequestCacheLevel.BypassCache);
                        _image.CacheOption = BitmapCacheOption.OnLoad;
                        _image.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
                        _image.UriSource = new Uri(Xu_ly_Anh.GetAnh(Xu_ly_Anh.AccountAvatar, Selected.LoggedIn.Avatar), UriKind.RelativeOrAbsolute);
                        _image.EndInit();
                        db.logged_in_avatar.Source = _image;
                        
                    }
                }
                
            }
            

        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Mailcode = Xu_ly_Mail.SendMail(txtbox_mail.Text.Trim());
        }

        private void button_QL_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult check = MessageBox.Show("Bạn có muốn lưu mã quản lý là '" + txtbox_maQL.Text.Trim() + "'","",MessageBoxButton.YesNo,MessageBoxImage.Question);
            if(check==MessageBoxResult.Yes)
                Xu_ly_File.WriteToTextFile(txtbox_maQL.Text.Trim());
        }
    }
}
