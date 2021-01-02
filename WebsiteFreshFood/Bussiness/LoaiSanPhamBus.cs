using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteFreshFood.DataAccess;
using WebsiteFreshFood.Models;

namespace WebsiteFreshFood.Bussiness
{
    public class QLLoaiSanPhamBus
    {
        LoaiSanPhamDAL lspDAL = new LoaiSanPhamDAL();
        public string SinhMaHoaDon(string ngay)
        {
            string ma = "";
            return ma;
        }
        public List<LoaiSanPham> LayLoaiSanPham()
        {
            return lspDAL.LayLoaiSanPham();
        }
        public string ThemLoaiSanPham(LoaiSanPham l)
        {
            return lspDAL.ThemLoaiSP(l);
        }
        public string XoaLoaiSanPham(string id)
        {
            return lspDAL.XoaLoaiSanPham(id);
        }
        public string SuaLoaiSanPham(LoaiSanPham l)
        {
            return lspDAL.SuaLoaiSanPham(l);
        }
        public List<LoaiSanPham> TimKiemLoaiSanPham(string tenLoai) // Search Admin
        {
            return lspDAL.Search(tenLoai);
        }
    }
}