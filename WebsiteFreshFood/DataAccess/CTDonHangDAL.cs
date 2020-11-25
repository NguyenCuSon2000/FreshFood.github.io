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
            DataColumn c4 = new DataColumn("SoLuong");
            DataColumn c5 = new DataColumn("DonGia");
            DataColumn c6 = new DataColumn("GiamGia");
            dt.Columns.Add(c1);
            dt.Columns.Add(c2);
            dt.Columns.Add(c3);
            dt.Columns.Add(c4);
            dt.Columns.Add(c5);
            dt.Columns.Add(c6);
            //for(int i = 0; i < lct.Count; i++)
            //{
            //    DataRow[i] 
            //}
        }
    }
}