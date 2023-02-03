using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Windows;

namespace FastfoodManagementFinal.ViewModel
{
    public static class Xu_ly_Mail
    {
        //public static SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["FastFoodDataBase"].ConnectionString);
        public static string GenerateCode(this Random random, int length)
        {
            const string chars = "0123456789";
            IEnumerable<string> string_Enumerable = Enumerable.Repeat(chars, length);
            char[] arr = string_Enumerable.Select(s => s[random.Next(s.Length)]).ToArray();
            return new string(arr);
        }
        //public static void SendMail(string FromMail, string ToMail) {}
        public static string SendMail(string ToMail)
        {
            string fromMail = "democustomerservicemail@gmail.com";
            string fromPassword = "rfmhfddhfbnkzftd";

            MailMessage mail = new MailMessage();
            SmtpClient Smtp = new SmtpClient("smtp.gmail.com");

            Random random = new Random();
            string code = GenerateCode(random, 6);
            string mailBody = "Chào bạn đến với đồ án của nhóm, Quản lý bán đồ ăn nhanh\n\t mã xác nhận của bạn là: " + code;

            mail.From = new MailAddress(fromMail);
            mail.Subject = "Cofirmation Number";
            mail.To.Add(new MailAddress(ToMail));
            mail.Body = mailBody;
            Smtp.EnableSsl = true;
            Smtp.Port = 587;
            Smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            Smtp.Credentials = new NetworkCredential(fromMail, fromPassword);

            try
            {
                Smtp.Send(mail);
                MessageBox.Show("Code send successfully");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return code;
            }
            return code;
        }
    }
}
