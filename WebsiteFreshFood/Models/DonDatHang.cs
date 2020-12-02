namespace WebsiteFreshFood.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class DonDatHang
    {
        public KhachHang Khach { get; set; }

        public double TongTien { get; set; }

        public List<CTDonHang> LCTDonHang { get; set; }
    }
}