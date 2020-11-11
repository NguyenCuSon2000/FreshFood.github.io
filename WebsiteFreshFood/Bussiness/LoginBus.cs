using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteFreshFood.Models;
using WebsiteFreshFood.DataAccess;

namespace WebsiteFreshFood.Bussiness
{
    public class LoginBus
    {
        UserDAL ul = new UserDAL();

        public User checkUser(string name, string pass)
        {
            return ul.CheckAccount(name, pass);
        }
    }
}