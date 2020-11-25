namespace WebsiteFreshFood.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("DonHang")]
    public partial class DonHang
    {
        [Key]
        [StringLength(100)]
        public string MaDonHang { get; set; }

        [StringLength(100)]
        public string MaKH { get; set; }

        [StringLength(100)]
        public string DiaChiNhan { get; set; }

        [StringLength(100)]
        public string SDTNhan { get; set; }
        
        public int TinhTrang { get; set; }

        public double ThanhTien { get; set; }

        public DateTime NgayDat { get; set; }

        public DateTime NgayGiao { get; set; }

        public DonHang() { }

        public DonHang(string maDH, string maKH, string diaChiNhan, string sdtNhan,int tinhTrang, double thanhTien, DateTime ngayDat, DateTime ngayGiao)
        {
            this.MaDonHang = maDH;
            this.MaKH = maKH;
            this.DiaChiNhan = diaChiNhan;
            this.SDTNhan = sdtNhan;
            this.ThanhTien = thanhTien;
            this.NgayDat = ngayDat;
            this.NgayGiao = ngayGiao;
        }
    }
}