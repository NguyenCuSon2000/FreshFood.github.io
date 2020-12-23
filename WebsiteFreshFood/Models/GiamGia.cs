namespace WebsiteFreshFood.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("GiamGia")]
    public partial class GiamGia
    {
        [Key]
        public int MaGiamGia { get; set; }

       
        public int MaSP { get; set; }

        [StringLength(50)]
        public string TenSP { get; set; }

        public int PhanTram { get; set; }

        public double GiaGiam { get; set; }

        [StringLength(100)]
        public string HinhAnh { get; set; }

        public string Active { get; set; }

        [StringLength(20)]
        public string NgayBatDau { get; set; }

        [StringLength(20)]
        public string NgayKetThuc { get; set; }

        [StringLength(20)]
        public string NgayNhap { get; set; }

        public GiamGia() { }

        public GiamGia(int maGiamGia, int maSP,string tenSP, int phanTram, double giaGiam, string hinhAnh, string active, string ngayBatDau, string ngayKetThuc, string ngayNhap)
        {
            this.MaGiamGia = maGiamGia;
            this.MaSP = maSP;
            this.TenSP = tenSP;
            this.PhanTram = phanTram;
            this.GiaGiam = giaGiam;
            this.HinhAnh = hinhAnh;
            this.Active = active;
            this.NgayBatDau = ngayBatDau;
            this.NgayKetThuc = ngayKetThuc;
            this.NgayNhap = ngayNhap;
        }

    }
}