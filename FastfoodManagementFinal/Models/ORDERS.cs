//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FastfoodManagementFinal.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ORDERS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ORDERS()
        {
            this.BILL = new HashSet<BILL>();
        }
    
        public string OrderID { get; set; }
        public System.DateTime OrdTime { get; set; }
        public string StaffID { get; set; }
        public string CustomerID { get; set; }
        public string ProductID { get; set; }
        public Nullable<byte> Quantity { get; set; }
        public Nullable<int> Total { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BILL> BILL { get; set; }
        public virtual CUSTOMERS CUSTOMERS { get; set; }
        public virtual PRODUCTS PRODUCTS { get; set; }
        public virtual STAFF STAFF { get; set; }
    }
}
