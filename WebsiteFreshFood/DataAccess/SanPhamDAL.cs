using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using WebsiteFreshFood.Models;

namespace WebsiteFreshFood.DataAccess
{
    public class SanPhamDAL
    {
        DataHelper dc = new DataHelper();

        public List<SanPham> LaySPTheoLoai(string maloaisp)
        {
            string sqlselect = "select * from SanPham where MaLoaiSP ='" + maloaisp + "'";
            DataTable dt = dc.GetDataTable(sqlselect);

            return ToList(dt);
        }
        public List<SanPham> ToList(DataTable dt)
        {
            List<SanPham> l = new List<SanPham>();
            foreach (DataRow dr in dt.Rows)
            {
                SanPham s = new SanPham();
                s.MaSP = Convert.ToString(dr[0]);
                s.TenSP = Convert.ToString(dr[1]);
                s.MaLoaiSP = Convert.ToString(dr[2]);
                s.DonVi = Convert.ToString(dr[3]);
                s.MoTa = Convert.ToString(dr[4]);
                s.HinhAnh = Convert.ToString(dr[5]);
                s.SoLuongTon = Convert.ToInt32(dr[6]);
                s.LuotXem = Convert.ToInt32(dr[7]);
                s.LuotBinhLuan = Convert.ToInt32(dr[8]);
                s.SoLanMua = Convert.ToInt32(dr[9]);
                s.DonGia = Convert.ToInt32(dr[10]);
                l.Add(s);
            }
            return l;
        }
        public SanPhamList GetSanPham(int pageIndex, int pageSize)
        {
            SanPhamList spl = new SanPhamList(); List<SanPham> l = new List<SanPham>();
            SqlDataReader dr = dc.StoreReaders("GetSanPhams", pageIndex, pageSize);
            while (dr.Read())
            {
                SanPham s = new SanPham(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(),int.Parse(dr[6].ToString()), int.Parse(dr[7].ToString()), int.Parse(dr[8].ToString()), int.Parse(dr[9].ToString()), float.Parse(dr[10].ToString()));
                l.Add(s);

            }
            spl.SanPhams = l;
            dr.NextResult();
            while (dr.Read())
            {
                spl.totalCount = dr["totalCount"].ToString();
            }
            return spl;
        }
        public string ThemSanPham(SanPham sp)
        {
            string sql = "INSERT into SanPham values('" + sp.MaSP + "','" + sp.TenSP + "','" + sp.MaLoaiSP + "','" +
                sp.DonVi + "','" + sp.MoTa + "','" + sp.HinhAnh + "','" + sp.SoLuongTon + "','" + sp.LuotXem + "','" + sp.LuotBinhLuan + "','" + sp.SoLanMua + "'','" + sp.DonGia + "')";

            return dc.ExcuteNonQuery(sql);
        }

        public List<SanPham> GetAllSanPham()
        {
            DataTable dt = dc.GetDataTable("select * from SanPham");
            return ToList(dt);
        }
        public string XoaSanPham(string id)
        {
            string st = "delete from SanPham where masp='" + id + "'";
            return dc.ExcuteNonQuery(st);

        }
        public string SuaSanPham(SanPham s)
        {
            string st = "update sanpham set TenSP='" + s.TenSP + "', MaLoai='" + s.MaLoaiSP + "', donvi='" +
                s.DonVi + "',mota='" + s.MoTa + "', HinhAnh='" + s.HinhAnh + "', soluongton='" + s.SoLuongTon + "', luotxem = '" + s.LuotXem + "', luobingluan ='" + s.LuotBinhLuan + "', solanmua ='" + s.SoLanMua + "', dongia = '" + s.DonGia + "' where MaSP='" + s.MaSP + "'";
            return dc.ExcuteNonQuery(st);
        }
        public List<SanPham> Search(string maloaisp, string tenSP)
        {
            string st;
            if (maloaisp != "")
            {
                st = "select * from SanPham where (MaLoai='" + maloaisp + "') and (TenSP like '%" + tenSP + "%')";
            }
            else
            { st = "select * from SanPham where (TenSP like '%" + tenSP + "%')"; }
            DataTable dt = dc.GetDataTable(st);
            return ToList(dt);
        }

    }
}