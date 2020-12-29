using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteFreshFood.DataAccess;
using WebsiteFreshFood.Models;

namespace WebsiteFreshFood.Bussiness
{
    public class QLUserBus
    {
        UsersDAL usDAL = new UsersDAL();
        public List<Users> LayAllUser()
        {
            return usDAL.GetAllUser();
        }

        public string ThemUser(Users us)
        {
            return usDAL.ThemUser(us);
        }
      
        public string SuaUser(Users us)
        {
            return usDAL.SuaUser(us);
        }
        public List<Users> TimKiemUser(string userName) // Search Admin
        {
            return usDAL.Search(userName);
        }


        public string XoaUser(string id)
        {
            return usDAL.XoaUser(id);
        }
    }
}