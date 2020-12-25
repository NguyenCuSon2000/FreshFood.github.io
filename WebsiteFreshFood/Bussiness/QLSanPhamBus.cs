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

        //Chi tiết sản phẩm
        public List<SanPham> LaySPTheoMa(int masp)
        {
            return SanPhamDAL.LaySPTheoMa(masp);
        }

        public SanPhamList LaySanPhamPTLoai(string maLoai,int pageIndex, int pageSize)
        {
            SanPhamList spList = SanPhamDAL.GetSanPhamPTLoai(maLoai, pageIndex, pageSize);
            return spList;
        }

        //Admin
        public SanPhamList LaySanPhamPT(int pageIndex, int pageSize)
        {
            SanPhamList spList = SanPhamDAL.GetSanPham(pageIndex, pageSize);
            return spList;
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
        public List<SanPham> TimKiemSanPham(string tenSP) // Search Admin
        {
            return SanPhamDAL.Search(tenSP);
        }

        public List<SanPham> SearchNameSP(string tensp)
        {
            return SanPhamDAL.SearchName(tensp);
        }

        public List<SanPham> SanPhamNoiBat()
        {
            return SanPhamDAL.GetSPNoiBat();
        }

        public List<SanPham> SPNoiBatHome()
        {
            return SanPhamDAL.SanPhamNoiBatHome();
        }

        public List<SanPham> SanPhamMoiNhat()
        {
            return SanPhamDAL.GetSPMoiNhat();
        }

        public ThongKeSLSP ThongKeSoLuongSP(string maloai)
        {
            ThongKeSLSP tksp = SanPhamDAL.ThongKeSLSP(maloai);
            return tksp;
        }
    }
}