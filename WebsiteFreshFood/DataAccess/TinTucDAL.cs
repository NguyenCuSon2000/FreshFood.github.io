using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using WebsiteFreshFood.Models;

namespace WebsiteFreshFood.DataAccess
{
    public class TinTucDAL
    {
        DataHelper dc = new DataHelper();

        public List<TinTuc> ToList(DataTable dt)
        {
            List<TinTuc> l = new List<TinTuc>();
            foreach (DataRow dr in dt.Rows)
            {
                TinTuc t = new TinTuc();
                t.ID = Convert.ToInt32(dr[0]);
                t.TieuDe = Convert.ToString(dr[1]);
                t.HinhAnh = Convert.ToString(dr[2]);
                t.NoiDung = Convert.ToString(dr[3]);
                t.NgayDang = Convert.ToString(dr[4]);
                t.TrangThai = Convert.ToString(dr[5]);
                l.Add(t);
            }
            return l;
        }

        public List<TinTuc> GetAllTinTuc()
        {
            DataTable dt = dc.GetDataTable("select * from TinTuc");
            return ToList(dt);
        }

        public List<TinTuc> GetTinTucMoiNhat()
        {
            DataTable dt = dc.GetDataTable("select top(3) * from TinTuc order by ID desc");
            return ToList(dt);
        }

        public string ThemTinTuc(TinTuc t)
        {
            string sql = "INSERT into TinTuc values(N'" + t.TieuDe + "','" + t.HinhAnh + "',N'" +
                t.NoiDung + "','" + t.NgayDang + "','" + t.TrangThai + "')";

            return dc.ExcuteNonQuery(sql);
        }

        public string XoaTinTuc(string id)
        {
            string st = "delete from TinTuc where ID='" + id + "'";
            return dc.ExcuteNonQuery(st);

        }
        public string SuaTinTuc(TinTuc t)
        {
            string st = "Update TinTuc SET TieuDe=N'" + t.TieuDe + "', HinhAnh='" + t.HinhAnh + "', NoiDung=N'" +
                t.NoiDung + "',NgayDang='" + t.NgayDang + "', TrangThai='" + t.TrangThai + "' where ID='" + t.ID + "'";
            return dc.ExcuteNonQuery(st);
        }
    }
}