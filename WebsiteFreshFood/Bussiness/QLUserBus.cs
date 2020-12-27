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

        public string XoaUser(string id)
        {
            return usDAL.XoaUser(id);
        }
    }
}