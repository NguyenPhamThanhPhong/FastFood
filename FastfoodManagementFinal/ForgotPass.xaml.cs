using FastfoodManagementFinal.Models;
using FastfoodManagementFinal.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Interaction logic for ForgotPass.xaml
    /// </summary>
    public partial class ForgotPass : Window
    {
        public ForgotPass()
        {
            InitializeComponent();

        }
        
        private void QMK_Btn_Click(object sender, RoutedEventArgs e)
        {
            string Mail="";
            string pass="";
            SqlConnection con = Xu_Ly_SQL.con;
            string sql = "select Email,pass from staff where username = N'"+txtbox_username.Text.Trim()+"' ";
            if(con.State != ConnectionState.Open) 
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader= cmd.ExecuteReader();
                while(reader.Read()) 
                { 
                    Mail = reader.GetString(0);
                    pass =reader.GetString(1);
                }
                con.Close();
            }
            
            if(Mail.Length > 0 && pass.Length>0) 
            { 
                Xu_ly_Mail.SendMailwithPass(Mail, pass);
            }
            else
            {
                MessageBox.Show("Tên đăng nhập không đúng!");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
