using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteFreshFood.Models;
using WebsiteFreshFood.DataAccess;

namespace WebsiteFreshFood.Bussiness
{
    public class QLNhaCungCapBus
    {
        NhaCungCapDAL nccDAL = new NhaCungCapDAL();

        public List<NhaCungCap> LayAllNhaCungCap()
        {
            return nccDAL.GetAllNhaCungCap();
        }

        public string ThemKhachHang(NhaCungCap n)
        {
            return nccDAL.ThemNhaCungCap(n);
        }
        public string XoaNhaCungCap(string id)
        {
            return nccDAL.XoaNhaCungCap(id);
        }
        public string SuaKhachHang(NhaCungCap n)
        {
            return nccDAL.SuaNhaCungCap(n);
        }
    }
}