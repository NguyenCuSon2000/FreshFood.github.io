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

        public SanPhamList LaySanPhamPT(string maloai, int pageIndex, int pageSize, string productName)
        {
            return SanPhamDAL.GetSanPham(maloai, pageIndex, pageSize, productName);
        }
    }
}