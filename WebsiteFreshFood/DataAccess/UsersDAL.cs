using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using WebsiteFreshFood.Models;

namespace WebsiteFreshFood.DataAccess
{
    public class UsersDAL
    {
        DataHelper db = new DataHelper();
        public Users CheckAccount(string name, string Pass)
        {
            string sql = "SELECT * FROM Users WHERE UserName = '" + name + "' AND Pass = '" + Pass + "'";
            DataTable dt = db.GetDataTable(sql);
            if(dt.Rows.Count <= 0)
            {
                return null;
            }
            else
            {
                Users us = new Users(int.Parse(dt.Rows[0][0].ToString()), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString(), dt.Rows[0][3].ToString(), dt.Rows[0][4].ToString());
                return us;
            }
        }


        public string SignUp(Users us)
        {
            string sql = "Insert into Users values('" + us.UserName + "','" + us.Pass + "','" + us.Role + "','" + us.Active + "')";
            return db.ExcuteNonQuery(sql);
        }

        public List<Users> ToList(DataTable dt)
        {
            List<Users> l = new List<Users>();
            foreach (DataRow dr in dt.Rows)
            {
                Users u = new Users();
                u.UserID = Convert.ToInt32(dr[0]);
                u.UserName = Convert.ToString(dr[1]);
                u.Pass = Convert.ToString(dr[2]);
                u.Role = Convert.ToString(dr[3]);
                u.Active = Convert.ToString(dr[4]);
                l.Add(u);
            }
            return l;
        }


        public List<Users> GetAllUser()
        {
            DataTable dt = db.GetDataTable("select * from Users");
            return ToList(dt);
        }
    }
}