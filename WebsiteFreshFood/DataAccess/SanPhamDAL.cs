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

        public List<SanPham> SearchName(string tensp)
        {
            string sqlselect = "SELECT * FROM SanPham WHERE (TenSP like N'%" + tensp + "%')";
            DataTable dt = dc.GetDataTable(sqlselect);
            return ToList(dt);
        }

        //Chi tiết sản phẩm
        public List<SanPham> LaySPTheoMa(string masp)
        {
            string sqlselect = "select * from SanPham where MaSP ='" + masp + "'";
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
                s.DonGia = Convert.ToInt32(dr[6]);
                l.Add(s);
            }
            return l;
        }

        //public SanPhamList GetSanPham(string maloai, int pageIndex, int pageSize, string productName)
        //{
        //    SanPhamList spl = new SanPhamList();
        //    List<SanPham> l = new List<SanPham>();
        //    SqlDataReader dr = dc.StoreReaders("GetSanPhams", maloai, pageIndex, pageSize, productName);
        //    while (dr.Read())
        //    {
        //        SanPham s = new SanPham(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(),
        //            dr[4].ToString(), dr[5].ToString(), double.Parse(dr[6].ToString()));
        //        l.Add(s);
        //    }
        //    spl.SanPhams = l;
        //    dr.NextResult();
        //    while (dr.Read())
        //    {
        //        spl.totalCount = dr["totalCount"].ToString();
        //    }
        //    return spl;
        //}
      
        public List<SanPham> GetAllSanPham()
        {
            DataTable dt = dc.GetDataTable("select * from SanPham");
            return ToList(dt);
        }

        public string ThemSanPham(SanPham sp)
        {
            //DA3_QuanLyFreshFoodEntities d = new DA3_QuanLyFreshFoodEntities();
            //try
            //{
            //    d.SanPhams.Add(sp);
            //    d.SaveChanges();
            //    return "";
            //}
            //catch (Exception e)
            //{
            //    return e.Message;
            //}
            string sql = "INSERT into SanPham values('" + sp.MaSP + "',N'" + sp.TenSP + "','" + sp.MaLoaiSP + "',N'" +
                sp.DonVi + "',N'" + sp.MoTa + "','" + sp.HinhAnh + "','" + sp.DonGia + "')";

            return dc.ExcuteNonQuery(sql);
        }

        public string XoaSanPham(string id)
        {
            //DA3_QuanLyFreshFoodEntities d = new DA3_QuanLyFreshFoodEntities();
            //SanPham s = d.SanPhams.Find(id);
            //d.SanPhams.Remove(s);
            //d.SaveChanges();
            //return "";
            string st = "delete from SanPham where masp='" + id + "'";
            return dc.ExcuteNonQuery(st);

        }
        public string SuaSanPham(SanPham s)
        {
            string st = "Update SANPHAM SET TenSP=N'" + s.TenSP + "', MaLoaiSP='" + s.MaLoaiSP + "', DonVi=N'" +
                s.DonVi + "',MoTa=N'" + s.MoTa + "', HinhAnh='" + s.HinhAnh + "', dongia = '" + s.DonGia + "' where MaSP='" + s.MaSP + "'";
            return dc.ExcuteNonQuery(st);
        }

        public List<SanPham> Search(string tenSP) // Search Admin
        {
            string st;
            st = "select * from SanPham where TenSP like N'%" + tenSP + "%'";
            DataTable dt = dc.GetDataTable(st);
            return ToList(dt);
        }

    }
}