using FastfoodManagementFinal.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace FastfoodManagementFinal.Converters
{
    public class ImportProduct_to_Total : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            List<ImportProduct> imps = value as List<ImportProduct>;
            int total = 0;
            foreach(ImportProduct ip in imps)
            {
                total += (ip.ImportQuantity * ip.ImportProductPrice);
            }
            MessageBox.Show(imps.Count.ToString());
            return total;
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
