
namespace WebsiteFreshFood.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CTDonHang")]
    public class CTDonHang
    {
        [Key]
        public int MaCTDonDatHang { get; set; }

        [StringLength(50)]
        public string MaDonHang { get; set; }

        [StringLength(50)]

        public string MaSP { get; set; }

        public float SoLuong { get; set; }

        public double DonGia { get; set; }

        public float GiamGia { get; set; }

        public CTDonHang() { }
        
        public CTDonHang(int maCTDonDatHang, string maDonHang, string maSP, float soLuong, double donGia, float giamGia)
        {
            this.MaCTDonDatHang = maCTDonDatHang;
            this.MaDonHang = maDonHang;
            this.MaSP = maSP;
            this.SoLuong = soLuong;
            this.DonGia = donGia;
            this.GiamGia = giamGia;
        }
    }
}