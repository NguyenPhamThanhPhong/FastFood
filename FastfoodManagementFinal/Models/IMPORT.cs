using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastfoodManagementFinal.Models
{
    public class Import
    {
        public Import()
        { }
        public string ImportID { get; set; }
        public string AdminID { get; set; }
        public string AdminName { get; set; }
        public DateTime ImportDate { get; set; }
        public List<ImportProduct> importProducts { get; set; } // lấy thông qua importID

    }
}
