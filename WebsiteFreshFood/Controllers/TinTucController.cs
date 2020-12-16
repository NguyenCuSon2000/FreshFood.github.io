using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteFreshFood.Models;
using WebsiteFreshFood.Bussiness;

namespace WebsiteFreshFood.Controllers
{
    public class TinTucController : Controller
    {
        TinTucBus TinTucBus = new TinTucBus();
        // GET: TinTuc
        public ActionResult Index()
        {
            return View("Index");
        }

        [HttpGet]
        public JsonResult GetTinTuc()
        {
            List<TinTuc> ltt = TinTucBus.LayAllTinTuc();
            return Json(ltt, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetTinTucMoiNhat()
        {
            List<TinTuc> ltt = TinTucBus.LayTinTucMoiNhat();
            return Json(ltt, JsonRequestBehavior.AllowGet);
        }
    }
}