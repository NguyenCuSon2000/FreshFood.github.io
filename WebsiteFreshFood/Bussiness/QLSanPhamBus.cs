using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteFreshFood.DataAccess;
using WebsiteFreshFood.Models;

namespace WebsiteFreshFood.Bussiness
{
    public class QLSanPhamBus
    {
        SanPhamDAL SanPhamDAL = new SanPhamDAL();
        public List<SanPham> LaySP(string maloai)
        {
            return SanPhamDAL.LaySPTheoLoai(maloai);
        }

        public List<SanPham> LaySPTheoMa(string masp)
        {
            return SanPhamDAL.LaySPTheoMa(masp);
        }

        public SanPhamList LaySanPhamPT(string maloai, int pageIndex, int pageSize, string productName)
        {
            return SanPhamDAL.GetSanPham(maloai, pageIndex, pageSize, productName);
        }

        public List<SanPham> LayAllSanPham()
        {
            return SanPhamDAL.GetAllSanPham();
        }

        public string ThemSanPham(SanPham s)
        {
            return SanPhamDAL.ThemSanPham(s);
        }
        public string XoaSanPham(string id)
        {
            return SanPhamDAL.XoaSanPham(id);
        }
        public string SuaSanPham(SanPham s)
        {
            return SanPhamDAL.SuaSanPham(s);
        }
        public List<SanPham> TimKiemSanPham(string tenSP)
        {
            return SanPhamDAL.Search(tenSP);
        }

        public List<SanPham> SearchNameSP(string tensp)
        {
            return SanPhamDAL.SearchName(tensp);
        }

    }
}