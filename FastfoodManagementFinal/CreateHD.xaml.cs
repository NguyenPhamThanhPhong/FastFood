using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FastfoodManagementFinal
{
    /// <summary>
    /// Interaction logic for CreateHD.xaml
    /// </summary>
    public partial class CreateHD : Window
    {
        public CreateHD()
        {
            InitializeComponent();
        }
        DateTime picked_date = DateTime.Today;
        private void datepicker_NgaySinh_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            picked_date = (DateTime)(((DatePicker)sender).SelectedDate);
        }
    }
}
