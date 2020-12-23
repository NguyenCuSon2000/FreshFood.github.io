
namespace WebsiteFreshFood.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SanPham")]
    public partial class SanPham
    {
        [Key]
        public int MaSP { get; set; }

        [StringLength(100)]
        public string TenSP { get; set; }

        [StringLength(50)]
        public string MaLoaiSP { get; set; }


        [StringLength(50)]
        public string DonVi { get; set; }

        [StringLength(500)]
        public string MoTa { get; set; }

        [StringLength(50)]
        public string HinhAnh { get; set; }

        public double DonGia { get; set; }


        public SanPham() { }
        public SanPham(int masp, string tensp, string maloaisp, string donvi, string mota, string hinhanh, double dongia)
        {
            this.MaSP = masp; this.TenSP = tensp; this.MaLoaiSP = maloaisp;
            this.DonVi = donvi; this.MoTa = mota; this.HinhAnh = hinhanh;
            this.DonGia = dongia;
        }
    }
}