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
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        public JsonResult Login(string us, string pass)
        {
            LoginBus lb = new LoginBus();
            lb.checkUser(us, pass);
            if (us != null)
            {
                return Json(us, JsonRequestBehavior.AllowGet);
            }
            else
            {
                Session.Add("User_Session", us);
                return Json(us, JsonRequestBehavior.AllowGet);
            }
        }
    }
}