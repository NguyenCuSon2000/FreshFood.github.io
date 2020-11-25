using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteFreshFood.Models;

namespace WebsiteFreshFood.DataAccess
{
    public class DonHangDAL
    {
        DataHelper dc = new DataHelper();
        public string ThemDonHang(DonHang d)
        {
            string sql = "INSERT into DonHang values('" + d.MaDonHang + "','" + d.MaKH + "',N'" + d.DiaChiNhan + "','" +
                d.SDTNhan + "','" + d.TinhTrang + "','" + d.ThanhTien + "','" + d.NgayDat + "','" + d.NgayGiao + "')";

            return dc.ExcuteNonQuery(sql);
        }
    }
}