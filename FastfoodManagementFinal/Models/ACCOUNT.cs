﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
