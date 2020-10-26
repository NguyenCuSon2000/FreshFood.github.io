using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using WebsiteFreshFood.Models;

namespace WebsiteFreshFood.DataAccess
{
    public class LoaiSanPhamDAL
    {
        DataHelper dth = new DataHelper();
        public List<LoaiSanPham> LayLoaiSanPham()
        {
            DataTable dt = dth.GetDataTable("Select * from LoaiSanPham");
            return ToList(dt);
        }
        public List<LoaiSanPham> ToList(DataTable dt)
        {
            List<LoaiSanPham> l = new List<LoaiSanPham>();
            foreach (DataRow dr in dt.Rows)
            {
                LoaiSanPham s = new LoaiSanPham(dr[0].ToString(), dr[1].ToString());
                l.Add(s);
            }
            return l;
        }
        public string ThemLoaiSP(LoaiSanPham loai)
        {
            string st = "Insert into LoaiSanPham value('" + loai.MaLoaiSP + "','" + loai.TenLoai + "','" + ")";
            return dth.ExcuteNonQuery(st);
        }
    }
}