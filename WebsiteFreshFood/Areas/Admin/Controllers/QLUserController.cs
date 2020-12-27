using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteFreshFood.Models;
using WebsiteFreshFood.Bussiness;

namespace WebsiteFreshFood.Areas.Admin.Controllers
{
    public class QLUserController : Controller
    {
        QLUserBus qlus = new QLUserBus();
        // GET: Admin/QLUser
        public ActionResult Index()
        {
            return View("Index");
        }

        [HttpGet]
        public JsonResult GetUsers()
        {
            List<Users> lsp = qlus.LayAllUser();
            return Json(lsp, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Delete(string id)
        {
            string st = qlus.XoaUser(id);
            return Json(st, JsonRequestBehavior.AllowGet);
        }
    }
}