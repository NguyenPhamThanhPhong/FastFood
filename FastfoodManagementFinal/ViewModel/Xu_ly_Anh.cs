using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FastfoodManagementFinal.ViewModel
{
    public static class Xu_ly_Anh
    {
        public static string ProductAvatar = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "ProductAvatar");
        public static string AccountAvatar = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "AccountAvatar");
        public static void LuuAnh(string path,string store_to,string ID)
        {
            FileInfo fileInfo = new FileInfo(path);
            store_to = Path.Combine(store_to, ID + fileInfo.Name);
            MessageBox.Show(store_to);
            if (fileInfo.Exists)
            {
                File.Copy(fileInfo.FullName, store_to, true);
            }
        }
        public static string GetAnh(string directory, string filename)
        {
            FileInfo fileInfo = new FileInfo(Path.Combine(directory,filename));
            if(fileInfo.Exists) 
            { 
                return fileInfo.FullName;
            }
            return null;
        }
    }
}
