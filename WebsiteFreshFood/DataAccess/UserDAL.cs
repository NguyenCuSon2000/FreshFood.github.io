using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using WebsiteFreshFood.Models;

namespace WebsiteFreshFood.DataAccess
{
    public class UserDAL
    {
        DataHelper db = new DataHelper();
        public User CheckAccount(string name, string Pass)
        {
            string sql = "select * from [User] as u where u.UserName = '" + name + "' and u.Password = '" + Pass + "'";
            DataTable dt = db.GetDataTable(sql);

            if(dt.Rows.Count <= 0)
            {
                return null;
            }
            else
            {
                User us = new User(int.Parse(dt.Rows[0][0].ToString()), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString(), 
                    dt.Rows[0][3].ToString(),dt.Rows[0][4].ToString(), dt.Rows[0][5].ToString(), dt.Rows[0][6].ToString());
                return us;
            }
        }
    }
}