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
            //Lấy về hóa đơn cùng ngày
            //Đưa ra quy tắc sinh
            return ma;
        }
        public List<LoaiSanPham> LayLoaiSanPham()
        {
            return lspDAL.LayLoaiSanPham();
        }
    }
}