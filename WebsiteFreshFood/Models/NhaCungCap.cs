namespace WebsiteFreshFood.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("NhaCungCap")]
    public partial class NhaCungCap
    {
        [Key]
        [StringLength(50)]
        public string MaNCC { get; set; }

        [StringLength(100)]
        public string TenNCC { get; set; }

        [StringLength(100)]
        public string SDT { get; set; }

        [StringLength(100)]
        public string DiaChi { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(100)]
        public string Fax{ get; set; }

        public NhaCungCap() { }

        public NhaCungCap(string maNCC, string tenNCC, string sdt, string diaChi, string email, string fax)
        {
            this.MaNCC = maNCC;
            this.TenNCC= tenNCC;
            this.SDT = sdt;
            this.DiaChi = diaChi;
            this.Email = email;
            this.Fax = fax;
        }
    }
}