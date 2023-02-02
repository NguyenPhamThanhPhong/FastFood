using FastfoodManagementFinal.Models;
using FastfoodManagementFinal.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace FastfoodManagementFinal
{
    /// <summary>
    /// Interaction logic for Add_PNH.xaml
    /// </summary>
    public partial class Add_PNH : Window,INotifyPropertyChanged
    {
        public Add_PNH()
        {
            InitializeComponent();
            txtbox_maNV.Text = Selected.LoggedIn.StaffID + " " + Selected.LoggedIn.Name;
            txtbox_maImport.Text = Xu_ly_ID.GetImportID();
        }
        private List<ImportProduct> _imps = new List<ImportProduct>();
        public  List<ImportProduct> imps 
        { 
            get { return _imps;  } 
            set 
            { 
                if(_imps!=value)
                {
                    _imps = value;
                    MessageBox.Show("alskd");
                    OnPropertyChanged("_imps");
                    OnPropertyChanged("Total");
                }
            } 
        }
        public string Total
        {
            get 
            {
                int x = 0;
                foreach(ImportProduct ip in _imps)
                {
                    x += (ip.ImportProductPrice * ip.ImportQuantity);
                }
                
                return x.ToString();
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        private void button_tru_Click(object sender, RoutedEventArgs e)
        {
            int output;
            if(int.TryParse(txtbox_soluong.Text.Trim(), out output))
                txtbox_soluong.Text = (--output).ToString();
        }

        private void button_cong_Click(object sender, RoutedEventArgs e)
        {
            int output;
            if (int.TryParse(txtbox_soluong.Text.Trim(), out output))
            {
                txtbox_soluong.Text = (++output).ToString();
            }
                
        }

        private void button_them_Click(object sender, RoutedEventArgs e)
        {
            int outprice,outquantity;
            
            if(txtbox_MH.Text.Trim()== string.Empty)
            {
                MessageBox.Show("vui lòng nhập mặt hàng");
                return;
            }
            else if((!int.TryParse(txtbox_dongia.Text.Trim(),out outprice) || outprice<0) 
                || (!int.TryParse(txtbox_soluong.Text.Trim(), out outquantity) || outquantity < 0))
            {
                MessageBox.Show("Số lượng hoặc đơn giá ko hợp lệ");
                return;
            }

            ImportProduct ip = new ImportProduct();
            ip.ImportProductID = Xu_ly_ID.GetImportProductID(imps.Count(),txtbox_maImport.Text.Trim());
            ip.ImportID = txtbox_maImport.Text.Trim();
            ip.ImportProductName = txtbox_MH.Text.Trim();
            ip.ImportProductPrice = outprice;
            ip.ImportQuantity = int.Parse(txtbox_soluong.Text.Trim());
            ip.Unit = "kg";
            imps.Add(ip);
            listview_show.Items.Refresh();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(imps.Count <= 0)
            {
                MessageBox.Show("vui lòng nhập danh sách mặt hàng nhập vào!");
                return;
            }
            Import imp = new Import();
            imp.ImportID = txtbox_maImport.Text.Trim();
            imp.AdminID = Selected.LoggedIn.StaffID;
            imp.AdminName = Selected.LoggedIn.Name;
            imp.ImportDate = datepicker_billtime.SelectedDate.Value;
            imp.importProducts= imps;
            Xu_Ly_SQL.Insert_Import(imp);
            foreach(ImportProduct ip in imps)
            {
                Xu_Ly_SQL.Insert_ImportProducts(ip);
            }
            
        }
    }
}
