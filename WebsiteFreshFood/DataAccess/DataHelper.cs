using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace WebsiteFreshFood.DataAccess
{
    public class DataHelper
    {
        string stcon = @"Data Source=DESKTOP-BPP6VQ6\SQLEXPRESS;Initial Catalog=DA3_QuanLyFreshFood;Integrated Security=True";
        SqlConnection con;
        public DataHelper()
        {
            //ConfigurationManager.ConnectionStrings["con"].ConnectionString
            con = new SqlConnection(stcon);
        }
        public void MoKetNoi()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }
        public void DongKetNoi()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
        /// <summary>
        /// Phương thức lấy dữ liệu về Datatable
        /// </summary>
        /// <param name="sqlSelect">Câu lệnh truy vấn Select</param>
        /// <returns>Đối tượng DataTable chứa các bản ghi lấy về</returns>
        public DataTable GetDataTable(string sqlSelect)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, con);
            da.Fill(dt);
            return dt;
        }
        public void InsertRow(DataTable dt, params object[] values)
        {
            //b1. tạo 1 dòng có cấu trúc giống bảng 
            DataRow dr = dt.NewRow();
            //b2. Gán giá trị các cho các trường của dòng
            for (int i = 0; i < values.Length; i++)
            {
                dr[i] = values[i];
            }
            //b3. Add datarow vào DataTable
            dt.Rows.Add(dr);
        }

        public void UpdateRow(DataTable dt, string ma, params object[] values)
        {
            //B1 tìm
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //  MessageBox.Show(ma + (dt.Rows[i][0].ToString() == ma).ToString());
                if (dt.Rows[i][0].ToString() == ma)
                {
                    for (int j = 0; j < values.Length; j++)
                    {
                        //b2. Thấy sửa
                        dt.Rows[i][j] = values[j];


                    }
                    //b3. Sửa xong thì thoát
                    break;
                }
            }
        }

        public void DeleteRow(DataTable dt, string ma)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][0].ToString() == ma)
                {
                    dt.Rows.RemoveAt(i);
                    break;
                }
            }
        }

        /// <summary>
        /// Lấy về các bản ghi bằng phương pháp hướng nối
        /// </summary>
        /// <param name="sqlSelect"> Câu lệnh truy vấn select</param>
        /// <returns></returns>
        public SqlDataReader ExecuteReader(string sqlSelect)
        {
            MoKetNoi();
            SqlCommand cm = new SqlCommand(sqlSelect, con);
            SqlDataReader d = cm.ExecuteReader();
            return d;
        }
        public string ExcuteNonQuery(string sql)
        {
            MoKetNoi();
            try
            {
                SqlCommand cm = new SqlCommand(sql, con);
                cm.ExecuteNonQuery();
                return "";

            }
            catch (SqlException e)
            {
                return e.Message;
                //throw new Exception(e.Message);
                //if (e.Message.Contains("") )
            }
        }
        public void UpdateDataTabletoDataBase(DataTable dt, string tenbang)
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from " + tenbang, con);
            SqlCommandBuilder cm = new SqlCommandBuilder(da);
            da.Update(dt);

        }
        ///// <summary>
        ///// mo ta cho no
        ///// </summary>
        ///// <param name="tenStore">Dối vào 1 là Tên của strore</param>
        ///// <param name="giatri"> các đối tự chọn sau là các giá trị cần truyền cho strore</param>

        public void StoreNonQuery(string tenStore, params object[] giatri)
        {
            MoKetNoi();
            SqlCommand cm;
            try
            {
                cm = new SqlCommand(tenStore, con);
                cm.CommandType = CommandType.StoredProcedure;
                SqlCommandBuilder.DeriveParameters(cm);
                for (int i = 1; i < cm.Parameters.Count; i++)
                {
                    cm.Parameters[i].Value = giatri[i - 1];
                }
                cm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tenStore">Tên của Store procedure</param>
        /// <param name="giatri">Mảng các giá trị truyền vào cho đối số của store</param>
        /// <returns></returns>

        public DataTable StoreReader(string tenStore, params object[] giatri)
        {
            DataTable r = new DataTable();
            SqlCommand cm;
            MoKetNoi();
            try
            {
                cm = new SqlCommand(tenStore, con);
                cm.CommandType = CommandType.StoredProcedure;
                SqlCommandBuilder.DeriveParameters(cm);
                for (int i = 1; i < cm.Parameters.Count; i++)
                {
                    cm.Parameters[i].Value = giatri[i - 1];
                }
                new SqlDataAdapter(cm).Fill(r);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return r;
        }
        public SqlDataReader StoreReaders(string tenStore, params object[] giatri)
        {

            SqlCommand cm;

            MoKetNoi();
            try
            {
                cm = new SqlCommand(tenStore, con);
                cm.CommandType = CommandType.StoredProcedure;
                SqlCommandBuilder.DeriveParameters(cm);
                for (int i = 1; i < cm.Parameters.Count; i++)
                {
                    cm.Parameters[i].Value = giatri[i - 1];
                }
                SqlDataReader dr = cm.ExecuteReader();
                return dr;
            }
            catch
            {
                return null;

            }

        }
    }
}