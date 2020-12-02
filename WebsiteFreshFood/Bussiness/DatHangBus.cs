using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteFreshFood.Models;
using WebsiteFreshFood.DataAccess;

namespace WebsiteFreshFood.Bussiness
{
    public class DatHangBus
    {
        DonHangDAL dh = new DonHangDAL();
        public string SinhMaDonHang()
        {
            return Guid.NewGuid().ToString();
        }

        public void DatHang(KhachHang k, DonHang d, List<CTDonHang> ct)
        {
            //Tạo mã đơn hàng
            string mdh = Guid.NewGuid().ToString();
            d.MaDonHang = mdh;
            //Gán mã đơn hàng cho chi tiết đơn hàng
            for (int i = 0; i < ct.Count; i++)
            {
                ct[i].MaDonHang = mdh;
            }
            DonHangDAL dh = new DonHangDAL();
            dh.ThemDonHang(d);
            CTDonHangDAL ctdh = new CTDonHangDAL();
            ctdh.LuuCTDonHang(ct);
        }

        public Users KiemTraDangNhap(string name, string pass)
        {
            return dh.CheckAccount(name, pass);
        }
    }
}