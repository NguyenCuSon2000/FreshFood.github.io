﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using WebsiteFreshFood.Models;


namespace WebsiteFreshFood.DataAccess
{
    public class NhaCungCapDAL
    {
        DataHelper dc = new DataHelper();

        public List<NhaCungCap> ToList(DataTable dt)
        {
            List<NhaCungCap> l = new List<NhaCungCap>();
            foreach (DataRow dr in dt.Rows)
            {
                NhaCungCap n = new NhaCungCap();
                n.MaNCC = Convert.ToString(dr[0]);
                n.TenNCC = Convert.ToString(dr[1]);
                n.SDT = Convert.ToString(dr[2]);
                n.DiaChi = Convert.ToString(dr[3]);
                n.Email = Convert.ToString(dr[4]);
                n.Fax = Convert.ToString(dr[5]);
                l.Add(n);
            }
            return l;
        }
        public List<NhaCungCap> GetAllNhaCungCap()
        {
            DataTable dt = dc.GetDataTable("select * from NhaCungCap");
            return ToList(dt);
        }

        public string ThemNhaCungCap(NhaCungCap ncc)
        {
            string sql = "INSERT into NhaCungCap values('" + ncc.MaNCC + "',N'" + ncc.TenNCC + "',N'" + ncc.DiaChi + "','" +
                ncc.SDT + "','" + ncc.Email + "','" + ncc.Fax + "')";

            return dc.ExcuteNonQuery(sql);
        }

        public string XoaNhaCungCap(string id)
        {
            string st = "DELETE from NhaCungCap where MaNCC='" + id + "'";
            return dc.ExcuteNonQuery(st);

        }
        public string SuaNhaCungCap(NhaCungCap ncc)
        {
            string st = "UPDATE NhaCungCap set TenNCC=N'" + ncc.TenNCC + "', SDT='" +
                ncc.SDT + "', DiaChi=N'" + ncc.DiaChi + "',Email='" + ncc.Email + "',Fax='" + ncc.Fax + "' where MaNCC='" + ncc.MaNCC + "'";
            return dc.ExcuteNonQuery(st);
        }
        public List<NhaCungCap> Search(string tenNCC) // Search Admin
        {
            string st;
            st = "select * from NhaCungCap where TenNCC like N'%" + tenNCC + "%'";
            DataTable dt = dc.GetDataTable(st);
            return ToList(dt);
        }

    }
}