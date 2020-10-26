namespace WebsiteFreshFood.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("LoaiSanPham")]
    public partial  class LoaiSanPham
    {
        [Key]
        [StringLength(50)]
        public string MaLoaiSP { get; set; }

        [StringLength(100)]
        public string TenLoai { get; set; }

        public LoaiSanPham(string maloaisp, string tenloai)
        {
            this.MaLoaiSP = maloaisp;
            this.TenLoai = tenloai;
        }
    }
}