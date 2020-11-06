
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
        [StringLength(50)]
        public string MaSP { get; set; }

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

        public int SoLuongTon { get; set; }

        public int LuotXem { get; set; }

        public int LuotBinhLuan { get; set; }

        public int SoLanMua { get; set; }

        public double DonGia { get; set; }


        public SanPham() { }
        public SanPham(string masp, string tensp, string maloaisp, string donvi, string mota, string hinhanh, int soluongton, int luotxem, int luotbinhluan, int solanmua, double dongia)
        {
            this.MaSP = masp; this.TenSP = tensp; this.MaLoaiSP = maloaisp;
            this.DonVi = donvi; this.MoTa = mota; this.HinhAnh = hinhanh;
            this.SoLuongTon = soluongton; this.LuotXem = luotxem;
            this.LuotBinhLuan = luotbinhluan; this.SoLanMua = solanmua;
            this.DonGia = dongia;
        }
    }
}