using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using WebsiteFreshFood.Models;

namespace WebsiteFreshFood.DataAccess
{
    public class GiamGiaDAL
    {
        DataHelper dc = new DataHelper();
        public List<GiamGia> ToList(DataTable dt)
        {
            List<GiamGia> l = new List<GiamGia>();
            foreach (DataRow dr in dt.Rows)
            {
                GiamGia g = new GiamGia();
                g.MaGiamGia = Convert.ToInt32(dr[0]);
                g.MaSP = Convert.ToInt32(dr[1]);
                g.TenSP = Convert.ToString(dr[2]);
                g.PhanTram = Convert.ToInt32(dr[3]);
                g.GiaGiam = Convert.ToDouble(dr[4]);
                g.HinhAnh = Convert.ToString(dr[5]);
                g.Active = Convert.ToString(dr[6]);
                g.NgayBatDau = Convert.ToString(dr[7]);
                g.NgayKetThuc = Convert.ToString(dr[8]);
                g.NgayNhap = Convert.ToString(dr[9]);
                l.Add(g);
            }
            return l;
        }

        public List<GiamGia> LaySPKhuyenMai()
        {
            DataTable dt = dc.GetDataTable("select * from GiamGia");
            return ToList(dt);
        }

    }
}