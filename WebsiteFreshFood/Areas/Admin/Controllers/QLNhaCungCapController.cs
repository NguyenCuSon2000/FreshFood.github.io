using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteFreshFood.Models;
using WebsiteFreshFood.Bussiness;

namespace WebsiteFreshFood.Areas.Admin.Controllers
{
    public class QLNhaCungCapController : Controller
    {
        QLNhaCungCapBus qlncc = new QLNhaCungCapBus();
        // GET: Admin/QLNhaCungCap
        public ActionResult Index()
        {
            return View("Index");
        }

        [HttpGet]
        public JsonResult GetNhaCungCap()
        {
            List<NhaCungCap> lsp = qlncc.LayAllNhaCungCap();
            return Json(lsp, JsonRequestBehavior.AllowGet);
        }
    }
}