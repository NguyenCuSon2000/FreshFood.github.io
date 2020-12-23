using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
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

        public Users CheckAccount(string name, string Pass)
        {
            string sql = "SELECT * FROM Users WHERE UserName = '" + name + "' AND Pass = '" + Pass + "'";
            DataTable dt = dc.GetDataTable(sql);

            if (dt.Rows.Count <= 0)
            {
                return null;
            }
            else
            {
                Users us = new Users(int.Parse(dt.Rows[0][0].ToString()), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString(), dt.Rows[0][3].ToString(), dt.Rows[0][4].ToString());
                return us;
            }
        }
    }
}