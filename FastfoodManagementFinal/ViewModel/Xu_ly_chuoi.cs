using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastfoodManagementFinal.ViewModel
{
    public static class Xu_ly_chuoi
    {
        private static readonly string[] VietnameseSigns = new string[]
{

        "aAeEoOuUiIdDyY",

        "áàạảãâấầậẩẫăắằặẳẵ",

        "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",

        "éèẹẻẽêếềệểễ",

        "ÉÈẸẺẼÊẾỀỆỂỄ",

        "óòọỏõôốồộổỗơớờợởỡ",

        "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",

        "úùụủũưứừựửữ",

        "ÚÙỤỦŨƯỨỪỰỬỮ",

        "íìịỉĩ",

        "ÍÌỊỈĨ",

        "đ",

        "Đ",

        "ýỳỵỷỹ",

        "ÝỲỴỶỸ"
};
        private static readonly string[] Vietnamese_accent = new string[]
{

        "áàạảãâấầậẩẫăắằặẳẵ",

        "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",

        "éèẹẻẽêếềệểễ",

        "ÉÈẸẺẼÊẾỀỆỂỄ",

        "óòọỏõôốồộổỗơớờợởỡ",

        "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",

        "úùụủũưứừựửữ",

        "ÚÙỤỦŨƯỨỪỰỬỮ",

        "íìịỉĩ",

        "ÍÌỊỈĨ",

        "đ",

        "Đ",

        "ýỳỵỷỹ",

        "ÝỲỴỶỸ"
};
        public static string Sang_chuoi_khong_dau(string str)
        {

            //Tiến hành thay thế , lọc bỏ dấu cho chuỗi

            for (int i = 1; i < VietnameseSigns.Length; i++)

            {

                for (int j = 0; j < VietnameseSigns[i].Length; j++)

                    str = str.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);

            }
            return str;

        }
        public static bool Is_Vietnamese(string str)
        {
            for (int i = 0; i < Vietnamese_accent.Length; i++)

            {

                for (int j = 0; j < Vietnamese_accent[i].Length; j++)
                {
                    if (str.Contains(Vietnamese_accent[i][j]))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static string chuan_hoa(string xau)
        {
            string kq = "";
            xau = xau.Trim().ToLower();//Phải đổi sang Unicode thì sử dụng .ToLower() không bị lỗi font
            for (int i = 0; i < xau.Length; i++)
            {
                if (i == 0)
                    kq += xau[i].ToString().ToUpper();
                else
                    kq += xau[i];
                if (xau[i] == ' ')
                {
                    while (xau[i] == ' ')
                    {
                        i++;
                    }
                    kq += xau[i].ToString().ToUpper();
                }
            }
            return kq.ToString();

        }
        public static string ToVND(int amount)
        {
            string s = amount.ToString();
            int l = s.Length;
            string result = "";
            for (int i = 0; i < l; i++)
            {
                result = s[l - i - 1] + result;
                if ((i + 1) % 3 == 0 && i != l - 1)
                {
                    result = "." + result;
                }
            }
            return result + " d";
        }

        public static int ConvertVNDCurrencyToInt(string vndCurrency)
        {
            string cleanedString = vndCurrency.Replace(".", "").Replace(" d", "");
            return int.Parse(cleanedString);
        }
    }
    
}
