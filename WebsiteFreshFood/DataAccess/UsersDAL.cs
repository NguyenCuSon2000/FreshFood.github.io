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
            string sql = "SELECT * FROM Users WHERE UserName = '" + name + "' AND Password = '" + Pass + "'";
            DataTable dt = db.GetDataTable(sql);

            if(dt.Rows.Count <= 0)
            {
                return null;
            }
            else
            {
                Users us = new Users(int.Parse(dt.Rows[0][0].ToString()), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString(), 
                    dt.Rows[0][3].ToString(),dt.Rows[0][4].ToString(), dt.Rows[0][5].ToString(), dt.Rows[0][6].ToString());
                return us;
            }
        }
    }
}