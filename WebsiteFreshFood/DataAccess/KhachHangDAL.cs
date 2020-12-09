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
            string sql = "INSERT into KhachHang values('" + kh.MaKH + "',N'" + kh.TenKH + "','" + kh.SDT + "',N'" + kh.DiaChi + "','" + kh.Email + "')";

            return dc.ExcuteNonQuery(sql);
        }

        public string XoaKhachHang(string id)
        {
            string st = "DELETE from KhachHang where maKH='" + id + "'";
            return dc.ExcuteNonQuery(st);

        }
        public string SuaKhachHang(KhachHang k)
        {
            string st = "UPDATE KhachHang SET TenKH=N'" + k.TenKH + "', SDT='" + k.SDT + "', DiaChi=N'" + k.DiaChi + "',Email='" + k.Email + "' where MaKH='" + k.MaKH + "'";
            return dc.ExcuteNonQuery(st);
        }

        public List<KhachHang> Search(string tenKH) // Search Admin
        {
            string st;
            st = "select * from KhachHang where TenKH like N'%" + tenKH + "%'";
            DataTable dt = dc.GetDataTable(st);
            return ToList(dt);
        }
    }
}