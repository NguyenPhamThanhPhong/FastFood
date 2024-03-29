﻿using FastfoodManagementFinal.Models;
using FastfoodManagementFinal.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static OfficeOpenXml.ExcelErrorValue;

namespace FastfoodManagementFinal.Converters
{
    public class ComboBoxText_to_Avatar : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string text = value as string;
            Product p = Product.Find(text.Trim());
            ImageSource bmp = p.LoadAvatar();
            
            return bmp;
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class ComboBoxText_to_ProductName : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string text = value as string;
            Product p = Product.Find(text.Trim());
            

            return p.Name;
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class ComboBoxText_to_ProductQuantity : IValueConverter,IMultiValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string text = value as string;
            Product p = Product.Find(text.Trim());

            return p.Remaining_quantity;
            throw new NotImplementedException();
        }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            //Multi value converter
            string text = values[0] as string;
            Product p = Product.Find(text.Trim());
            
            if(p.ProductId ==null)
            {
                return "";
            }
            int display = p.Remaining_quantity;

            string sell = values[1] as string;
            int outsell = 0;
            List<Order> odrs = values[2] as List<Order>;
            
            foreach (Order o in odrs)
            {
                if (o.Order_Product_ID == p.ProductId)
                {
                    display -= o.Order_Sell_Quantity;
                    break;
                }
            }
            
            if (int.TryParse(sell,out outsell))
            {
                display -= outsell;
            }
            return display.ToString();
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            //Multi value converter
            throw new NotImplementedException();
        }
    }
    public class ComboBoxText_to_ProducPrice : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string text = value as string;
            Product p = Product.Find(text.Trim());

            return p.Price.ToString();
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class ProductQuantity_amount_toTotal : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string sell = values[0] as string;
            string  price = values[1] as string;
            int sell_amount;
            int price_amount;
            if(int.TryParse(sell,out sell_amount) && int.TryParse(price,out price_amount))
            {
                return Xu_ly_chuoi.ToVND(sell_amount * price_amount).ToString();
            }
            else
            {
                return "0 d";
            }
            throw new NotImplementedException();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class OrderID_to_OrderNumber : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string text = value as string;
            string ID = text.Substring(6);
            return ID;
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class Customer_toDiscount : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string cus_parameter = values[0] as string;
            Customer c = Customer.FindAbsolute_ID(cus_parameter);

            string money = values[1] as string;
            int total = Xu_ly_chuoi.ConvertVNDCurrencyToInt(money);
            if (c.CustomerRank == "Bạc")
                return Xu_ly_chuoi.ToVND(total * 5 / 100);
            if (c.CustomerRank == "Vàng")
                return Xu_ly_chuoi.ToVND(total * 7/100);
            if (c.CustomerRank == "VIP")
                return Xu_ly_chuoi.ToVND(total * 7 / 100);
            return "0 d";
            throw new NotImplementedException();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class Minus : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            int first = Xu_ly_chuoi.ConvertVNDCurrencyToInt((string)values[0]);
            int second = Xu_ly_chuoi.ConvertVNDCurrencyToInt(((string)values[1]));

            return Xu_ly_chuoi.ToVND(first-second);
            throw new NotImplementedException();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class toVND_Converter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int outparse = (int)value;
            return Xu_ly_chuoi.ToVND(outparse);

            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
