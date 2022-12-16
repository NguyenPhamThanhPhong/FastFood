using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastfoodManagementFinal.Models;
using OfficeOpenXml;
using Excel = Microsoft.Office.Interop.Excel;

namespace FastfoodManagementFinal.ViewModel
{
    public static class Xu_ly_excel
    {
        public static void Xuat_excel(Bill b, string source, string destination)
        {
            Excel.Application excel_app = new Excel.Application();
            excel_app.Application.Workbooks.Add(Type.Missing);
            //for(int i=0;i<)
        }
    }
}
