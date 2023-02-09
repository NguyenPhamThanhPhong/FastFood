using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastfoodManagementFinal.Models;
using Microsoft.Office.Interop.Excel;
using OfficeOpenXml;
using Excel = Microsoft.Office.Interop.Excel;

namespace FastfoodManagementFinal.ViewModel
{
    public static class Xu_ly_excel
    {
        public static void Xuat_excel_HoaDon(Bill b)
        {

            string source = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "ExcelTemplate", "Hóa-đơn.xlsx");
            string destination = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "ExcelTemplate", "RandomBill.pdf");

            Excel.Application excel= new Excel.Application();
            Workbook wb = excel.Workbooks.Open(source);
            Worksheet ws = wb.Worksheets[1];
            //excel.Application.Workbooks.Add(Type.Missing);

            string rangetop = "C5:C5";
            string[] content = new[] { b.Bill_Time.ToString("dd/MM/yyyy") };
            Range rangingtop = ws.Range[rangetop];
            rangingtop.set_Value(XlRangeValueDataType.xlRangeValueDefault, content);

            rangetop = "C6:C6";
            content = new[] { b.StaffID };
            rangingtop = ws.Range[rangetop];
            rangingtop.set_Value(XlRangeValueDataType.xlRangeValueDefault, content);
            
            rangetop = "F4:F4";
            content = new[] { b.CustomerID };
            rangingtop = ws.Range[rangetop];
            rangingtop.set_Value(XlRangeValueDataType.xlRangeValueDefault, content);

            rangetop = "F5:F5";
            content = new[] { b.CustomerID };
            rangingtop = ws.Range[rangetop];
            rangingtop.set_Value(XlRangeValueDataType.xlRangeValueDefault, content);

            int RowIndex = 11;
            foreach(Order o in b.orders)
            {
                string range_str = "B"+RowIndex+":F"+RowIndex+"";
                string[] intput = new[] {
                        o.Order_ID.Substring(6),
                        o.Order_Product_Name,
                        o.Order_Sell_Quantity.ToString(),
                        o.Order_Product_Price.ToString(),
                        (o.Order_Sell_Quantity * o.Order_Product_Price).ToString()};
                Range rng = ws.Range[range_str];
                rng.set_Value(XlRangeValueDataType.xlRangeValueDefault, intput);
                RowIndex++;
            }
            //Tổng tiền
            RowIndex++;
            string range_string = "E" + RowIndex + ":F" + RowIndex + "";
            string[] print_str = new[] {"Tổng tiền",b.Bill_Total.ToString() };  
            Range ranging = ws.Range[range_string];
            ranging.set_Value(XlRangeValueDataType.xlRangeValueDefault, print_str);
            //giảm giá
            RowIndex++;
            range_string = "E" + RowIndex + ":F" + RowIndex + "";
            print_str = new[] { "Giảm giá", (b.Bill_Total * b.Bill_Discount).ToString() };
            ranging = ws.Range[range_string];
            ranging.set_Value(XlRangeValueDataType.xlRangeValueDefault, print_str);

            //Thành tiền
            RowIndex++;
            range_string = "E" + RowIndex + ":F" + RowIndex + "";
            print_str = new[] { "Thành tiền", (b.Bill_Total * b.Bill_Discount).ToString() };
            ranging = ws.Range[range_string];
            ranging.set_Value(XlRangeValueDataType.xlRangeValueDefault, print_str);


            wb.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF, destination);
            //excel.ActiveWorkbook.Saved = true;
            wb.Close(0);
            excel.Quit();

            Process.Start(destination);

            
            //for(int i=0;i<)
        }
    }
}
