namespace WebsiteFreshFood.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ThongKeSLSP
    {
        public List<LoaiSanPham> LoaiSanPhams { get; set; }

        [StringLength(50)]
        public string SLSP { get; set; }
    }
}