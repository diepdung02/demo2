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
    using System.ComponentModel.DataAnnotations;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.DonDatHang = new HashSet<DonDatHang>();
        }
    
        public int ID { get; set; }
        [Required(ErrorMessage ="Vui lòng nhập họ và tên!")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Xác nhận lại mật khẩu không chính xác!")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ!")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập email!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại!")]
        public string Phone { get; set; }
        public Nullable<System.DateTime> NgaySinh { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonDatHang> DonDatHang { get; set; }
        public string LoginErrorMessage { get; set; }
    }
}
