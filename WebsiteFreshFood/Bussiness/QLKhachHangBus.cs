using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteFreshFood.Models;
using WebsiteFreshFood.DataAccess;

namespace WebsiteFreshFood.Bussiness
{
    public class QLKhachHangBus
    {
        KhachHangDAL KhachHangDAL = new KhachHangDAL();

        public List<KhachHang> LayAllKhachHang()
        {
            return KhachHangDAL.GetAllKhachHang();
        }

        public string ThemKhachHang(KhachHang k)
        {
            return KhachHangDAL.ThemKhachHang(k);
        }
        public string XoaKhachHang(string id)
        {
            return KhachHangDAL.XoaKhachHang(id);
        }
        public string SuaKhachHang(KhachHang k)
        {
            return KhachHangDAL.SuaKhachHang(k);
        }
    }
}