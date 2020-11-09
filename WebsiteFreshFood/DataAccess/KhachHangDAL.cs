using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using WebsiteFreshFood.Models;

namespace WebsiteFreshFood.DataAccess
{
    public class KhachHangDAL
    {
        DataHelper dc = new DataHelper();

        public List<KhachHang> ToList(DataTable dt)
        {
            List<KhachHang> l = new List<KhachHang>();
            foreach (DataRow dr in dt.Rows)
            {
                KhachHang k = new KhachHang();
                k.MaKH = Convert.ToString(dr[0]);
                k.TenKH = Convert.ToString(dr[1]);
                k.SDT = Convert.ToString(dr[2]);
                k.DiaChi = Convert.ToString(dr[3]);
                k.Email = Convert.ToString(dr[4]);
                l.Add(k);
            }
            return l;
        }
        public List<KhachHang> GetAllKhachHang()
        {
            DataTable dt = dc.GetDataTable("select * from KhachHang");
            return ToList(dt);
        }

        public string ThemKhachHang(KhachHang kh)
        {
            string sql = "INSERT into KhachHang values('" + kh.MaKH + "','" + kh.TenKH + "','" + kh.DiaChi + "','" +
                kh.SDT + "','" + kh.Email + "')";

            return dc.ExcuteNonQuery(sql);
        }

        public string XoaKhachHang(string id)
        {
            string st = "DELETE from KhachHang where maKH='" + id + "'";
            return dc.ExcuteNonQuery(st);

        }
        public string SuaKhachHang(KhachHang kh)
        {
            string st = "UPDATE KhachHang set TenKH='" + kh.TenKH + "', DiaChi='" + kh.DiaChi + "', SDT='" +
                kh.SDT + "',kh.Email='" + kh.Email + "' where MaKH='" + kh.MaKH + "'";
            return dc.ExcuteNonQuery(st);
        }
        public List<KhachHang> Search(string MaKH, string tenKH)
        {
            string st;
            if (MaKH != "")
            {
                st = "select * from KhachHang where (MaKH='" + MaKH + "') and (TenKH like '%" + tenKH + "%')";
            }
            else
            { st = "select * from KhachHang where (TenKH like '%" + tenKH+ "%')"; }
            DataTable dt = dc.GetDataTable(st);
            return ToList(dt);
        }
    }
}