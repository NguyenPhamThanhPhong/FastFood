using FastfoodManagementFinal.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FastfoodManagementFinal.Models
{
    public class Account
    {
        // nhập THÊM dữ liệu từ form thì dùng constructor này
        // type of constructor để phân biệt khi nào load từ form qua, và khi nào load từ dưới database lên
        // nhập 1 cho type of constructor để đại diện, đọc code dễ hơn
        //public Account(int Type_of_constructor,
        //    string Avatar,      string AccessRight, string Username ,
        //    string Pass,        string Name,        string Sex, DateTime DateOfBirth,
        //    string Phone_Number,string Email,       string Address)
        //{
        //    this.StaffID = "NV_" + Name;
        //    this.Username = Username;
        //    this.Avatar = Avatar;
        //    this.AccessRight = AccessRight;
        //    this.Pass = Pass;
        //    this.Name = Name;   
        //    this.Sex = Sex;
        //    this.DateOfBirth = DateOfBirth;
        //    this.Email = Email;
        //    this.Phone_Number = Phone_Number;
        //    this.address = Address;
        //}
        //// load từ dưới database lên thì dùng hàm này (truyền tất cả mọi thứ vào)
        //// update cho database thì cũng dùng hàm này
        //public Account(string staffID,
        //    string Avatar,          string AccessRight, string Username,
        //    string Pass,            string Name,        string Sex,
        //    DateTime DateOfBirth,   string Phone_Number,string Email,
        //    string Address)
        //{
        //    this.StaffID = staffID;
        //    this.Username = Username;
        //    this.Avatar = Avatar;
        //    this.AccessRight = AccessRight;
        //    this.Pass = Pass;
        //    this.Name = Name;
        //    this.Sex = Sex;
        //    this.DateOfBirth = DateOfBirth;
        //    this.Email = Email;
        //    this.Phone_Number = Phone_Number;
        //    this.address = Address;
        //}
        public Account()
        {
        }
        public string StaffID { get; set; }
        public string Avatar { get; set; }
        public string AccessRight { get; set; }
        public string Username { get; set; }
        public string Pass { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone_Number { get; set; }
        public string Email { get; set; }
        public string address { get; set; }
        public ImageSource AvatarImg { get; set; }
        public bool Visible { get; set; }
        public int Insert_num (List<int> x) 
        { 
            for(int i=0;i<x.Count-1;i++) 
            {
                if (x[i+1] - 1 > x[i])
                {
                    return x[i] + 1;
                }
            }
            return x.Count ;
        }
        public void LoadAvatar()
        {
            string path = Xu_ly_Anh.GetAnh(Xu_ly_Anh.AccountAvatar, this.Avatar);
            Uri ImageUri = new Uri(path);
            this.AvatarImg = BitmapFrame.Create(
                      ImageUri, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
        }
        public ImageSource FindAvatar()
        {
            string path = Xu_ly_Anh.GetAnh(Xu_ly_Anh.AccountAvatar, this.Avatar);
            Uri ImageUri = new Uri(path);
            return BitmapFrame.Create(
                      ImageUri, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
        }
        public bool Is_valid()
        {
            int try_parse;
            if(Name.Trim()==""|| AccessRight.Trim()=="" ||
                Username.Trim()=="" || Pass ==""|| Sex.Trim()==""||
                Phone_Number.Trim()=="")
            {
                MessageBox.Show("Vui lòng điền đủ thông tin");
                return false;
            }
            if(Xu_ly_chuoi.Is_Vietnamese(Username))
            {
                MessageBox.Show("user name không được chứa kí tự tiếng Việt (Unicode)");
                return false;
            }
            if(Name.Any(char.IsDigit))
            {
                MessageBox.Show("tên không được chứa số");
                return false;
            }
            else if (Sex.Any(char.IsDigit))
            {
                MessageBox.Show("giới tính sai định dạng");
                return false;
            }
            
            else if (int.TryParse(Phone_Number.Trim(), out try_parse)==false)
            {
                MessageBox.Show("Số điện thoại phải là số!");
                return false;
            }
            else if(DateOfBirth >= DateTime.Today)
            {
                MessageBox.Show("Ngày sinh không hợp lệ (phải bé hơn ngày hôm nay)");
                return false;
            }
            return true;
        }

        //public string Create_staffID(string AccessRight)
        //{
        //    string ID = "";
        //    if (AccessRight == "Nhân viên")
        //    {
        //        ID = "NV";
        //    }
        //    else
        //        ID = "QL";

        //    List<Account> acc = new List<Account>();
            
        //    acc = Xu_Ly_SQL.Select_all_Account();
            
        //    foreach(Account account in acc) 
        //    {
        //        int temp = int.Parse(account.StaffID.Remove(2));
        //    }
        //}
    }
}
