using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using WebsiteFreshFood.Models;

namespace WebsiteFreshFood.DataAccess
{
    public class CTDonHangDAL
    {
        DataHelper dc = new DataHelper();
        public void LuuCTDonHang(List<CTDonHang> lct)
        {
            // Chuyển list thành table
            DataTable dt = new DataTable();
            DataColumn c1 = new DataColumn("MaCTDonHang");
            DataColumn c2 = new DataColumn("MaDonHang");
            DataColumn c3 = new DataColumn("MaSP");
            DataColumn c4 = new DataColumn("TenSP");
            DataColumn c5 = new DataColumn("SoLuong");
            DataColumn c6 = new DataColumn("DonGia");
            DataColumn c7 = new DataColumn("GiamGia");
            DataColumn c8 = new DataColumn("Ngaynhap");
            dt.Columns.Add(c1);
            dt.Columns.Add(c2);
            dt.Columns.Add(c3);
            dt.Columns.Add(c4);
            dt.Columns.Add(c5);
            dt.Columns.Add(c6);
            dt.Columns.Add(c7);
            dt.Columns.Add(c8);
            for (int i = 0; i < lct.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[1] = lct[i].MaDonHang;
                dr[2] = lct[i].MaSP;
                dr[3] = lct[i].TenSP;
                dr[3] = lct[i].SoLuong;
                dr[4] = lct[i].DonGia;
                dr[5] = lct[i].NgayNhap;
                dt.Rows.Add(dr);
            }
            dc.UpdateDataTabletoDataBase(dt, "CTDonHang");
        }
    }
}