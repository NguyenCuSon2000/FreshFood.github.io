﻿
namespace WebsiteFreshFood.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CTDonHang")]
    public partial class CTDonHang
    {
        [Key]
        public int MaCTDonDatHang { get; set; }

        [StringLength(50)]
        public string MaDonHang { get; set; }

        public int MaSP { get; set; }

        [StringLength(100)]
        public string TenSP { get; set; }

        public float SoLuong { get; set; }

        public double DonGia { get; set; }

        public float GiamGia { get; set; }

        public DateTime NgayNhap { get; set; }
        public CTDonHang() { }
        
        public CTDonHang(int maCTDonDatHang, string maDonHang, int maSP,string tenSP, float soLuong, double donGia, float giamGia, DateTime ngayNhap)
        {
            this.MaCTDonDatHang = maCTDonDatHang;
            this.MaDonHang = maDonHang;
            this.MaSP = maSP;
            this.TenSP = tenSP;
            this.SoLuong = soLuong;
            this.DonGia = donGia;
            this.GiamGia = giamGia;
            this.NgayNhap = ngayNhap;
        }
    }
}