namespace WebsiteFreshFood.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [Key]
        [StringLength(50)]
        public string MaKH { get; set; }

        [StringLength(100)]
        public string TenKH { get; set; }

        [StringLength(100)]
        public string SDT { get; set; }

        [StringLength(100)]
        public string DiaChi { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public KhachHang() { }

        public KhachHang(string maKH, string tenKH, string sdt, string diaChi, string email)
        {
            this.MaKH = maKH;
            this.TenKH = tenKH;
            this.SDT = sdt;
            this.DiaChi = diaChi;
            this.Email = email;
        }
    }
}