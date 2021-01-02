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
            string st = "Insert into LoaiSanPham values('" + loai.MaLoaiSP + "',N'" + loai.TenLoai + "')";
            return dth.ExcuteNonQuery(st);
        }
        public string XoaLoaiSanPham(string id)
        {
            string st = "delete from LoaiSanPham where maloaisp='" + id + "'";
            return dth.ExcuteNonQuery(st);

        }
        public string SuaLoaiSanPham(LoaiSanPham l)
        {
            string st = "Update LoaiSanPham SET TenLoai=N'" + l.TenLoai + "' where MaLoaiSP='" + l.MaLoaiSP + "'";
            return dth.ExcuteNonQuery(st);
        }
        public List<LoaiSanPham> Search(string tenLoai) // Search Admin
        {
            string st;
            st = "select * from LoaiSanPham where TenLoai like N'%" + tenLoai + "%'";
            DataTable dt = dth.GetDataTable(st);
            return ToList(dt);
        }
    }
}