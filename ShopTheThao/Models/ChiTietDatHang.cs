//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShopTheThao.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ChiTietDatHang
    {
        public int MaDonHang { get; set; }
        public Nullable<int> MaSP { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<decimal> Gia { get; set; }
    
        public virtual DonDatHang DonDatHang { get; set; }
    }
}
