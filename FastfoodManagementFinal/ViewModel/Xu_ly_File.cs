using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace FastfoodManagementFinal.ViewModel
{
    public static class Xu_ly_File
    {
        public static void WriteToTextFile(string content)
        {
            try
            {
                string location = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "ProductAvatar","quanly.txt");
                File.WriteAllText(location, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while writing to the file: " + ex.Message);
            }
        }
        public static string ReadFromTextFile()
        {
            try
            {
                string location = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "ProductAvatar", "quanly.txt");

                return File.ReadAllText(location);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while reading the file: " + ex.Message);
                return string.Empty;
            }
        }
    }
}
