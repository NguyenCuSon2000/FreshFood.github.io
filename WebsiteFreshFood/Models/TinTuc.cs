namespace WebsiteFreshFood.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TinTuc")]
    public partial class TinTuc
    {
       [Key]
       public int ID { get; set; }

       [StringLength(200)]
       public string TieuDe { get; set; }

       [StringLength(200)]
       public string HinhAnh { get; set; }

        [StringLength(200)]
        public string NoiDung { get; set; }

        public string NgayDang { get; set; }

        public string TrangThai { get; set; }

        public TinTuc() { }

        public TinTuc(int id, string tieuDe, string hinhAnh, string noiDung, string ngayDang, string trangThai)
        {
            this.ID = id;
            this.TieuDe = tieuDe;
            this.HinhAnh = hinhAnh;
            this.NoiDung = noiDung;
            this.NgayDang = ngayDang;
            this.TrangThai = trangThai;
        }

    }
}