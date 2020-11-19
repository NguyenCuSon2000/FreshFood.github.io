using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteFreshFood.Models;
using WebsiteFreshFood.Bussiness;

namespace WebsiteFreshFood.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        Users u = new Users();
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View("Index");
        }

        //public JsonResult GetAccountCookie()
        //{
        //    Users u = new Users(0, Request.Cookies["un"].Value, Request.Cookies["pw"].Value, "", "", "", "true");
        //    return Json(u, JsonRequestBehavior.AllowGet);
           
        //}

        [HttpPost]
        public JsonResult Login(string us, string pw)
        {
            LoginBus lb = new LoginBus();
            lb.checkUser(us, pw);
            if (us != null)
            {
                return Json(us, JsonRequestBehavior.AllowGet);
            }
            else
            {
                //Tạo cookie
                //HttpCookie ck = new HttpCookie("un", u.UserName);
                //ck.Expires = DateTime.Now.AddDays(2);
                //Response.Cookies.Add(ck);
                //if (rp)
                //{
                //    HttpCookie ckp = new HttpCookie("pw", u.Password);
                //    ckp.Expires = DateTime.Now.AddDays(2);
                //    Response.Cookies.Add(ckp);
                //}

                Session.Add("User_Session", us);
                return Json(us, JsonRequestBehavior.AllowGet);
            }
        }

        
        //public JsonResult Logout()
        //{
        //    Session.Remove("User_Session");
        //    return Json(null, JsonRequestBehavior.AllowGet);
        //}
    }
}