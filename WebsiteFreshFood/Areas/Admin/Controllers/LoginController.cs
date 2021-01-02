using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteFreshFood.Bussiness;
using WebsiteFreshFood.Models;
using System.Web.Security;

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

        [HttpPost]
        public JsonResult Logout()
        {
            //Session.Remove("User_Session");
            FormsAuthentication.SignOut();
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DangNhap(string us, string pw)
        {
            LoginBus lb = new LoginBus();
            Users u = lb.checkUser(us, pw);
            if (u == null) //Tài khoản không đúng
            {
                return Json(u, JsonRequestBehavior.AllowGet);
            }
            else  //Tài khoản đúng
            {
                //b1 tạo cook lưu thông tin về User name
                HttpCookie ck = new HttpCookie("un", u.UserName);
                //b2 thiết lập thời gian tồn tại
                ck.Expires = DateTime.Now.AddDays(2);
                //b3 ghi biến cook về brower
                Response.Cookies.Add(ck);

                //b1 tạo cook lưu thông tin về trạng thái login
                HttpCookie ckl = new HttpCookie("login", "1");
                //b2 thiết lập thời gian tồn tại
                ck.Expires = DateTime.Now.AddDays(2);
                //b3 ghi biến cook về brower
                Response.Cookies.Add(ckl);
               
                Session.Add("User_Session", u);
                //FormsAuthentication.SetAuthCookie(us, false);
                return Json(u, JsonRequestBehavior.AllowGet);
                // return RedirectToAction("index", "Home");
            }
        }
    }
}