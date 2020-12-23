using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteFreshFood.DataAccess;
using WebsiteFreshFood.Models;

namespace WebsiteFreshFood.Bussiness
{
    public class SignupBus
    {
        UsersDAL usDAL = new UsersDAL();
        public string DangKy(Users us)
        {
            return usDAL.SignUp(us);
        }
    }
}