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
    
    public partial class PRODUCTS
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductType { get; set; }
        public int ProductPrice { get; set; }
        public short Stock { get; set; }
        public string Descriptions { get; set; }
        public byte[] ProductImage { get; set; }
    }
}
