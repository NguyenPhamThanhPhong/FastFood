using FastfoodManagementFinal.Models;
using FastfoodManagementFinal.ViewModel;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=FastFood;Integrated Security=True");

        //public void Store_Account_Table() 
        //{

        //}

        private void ForgotPass_Click(object sender, RoutedEventArgs e)
        {
            ForgotPass Forgotpass = new ForgotPass();
            this.Hide();
            Forgotpass.ShowDialog();
            this.Show();
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            SignUp Signup = new SignUp();
            this.Hide();
            Signup.ShowDialog();
            this.Show();
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            Account a = new Account();
            a = Xu_Ly_SQL.Select_LoggedIn_Account(txtEmail.Text, txtPass.Text);
            
            if (a.Username != null && a.Pass != null)
            {
                Dashboard dashboard = new Dashboard(a);
                this.Hide();
                dashboard.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("tài khoản hoặc mật khẩu không đúng!");
            }
            
            
        }
        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if(!(e.Key == Key.Space))
            {
                e.Handled= false;
            }
        }
    }
}
