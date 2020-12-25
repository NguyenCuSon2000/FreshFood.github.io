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

        /// <summary>
        /// Paging and searching
        /// </summary>
        /// <param name="pageIndex"> current page</param>
        /// <param name="pageSize"></param>
        /// <param name="productName"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetTinTucPT(int pageIndex, int pageSize)
        {
            TinTucList spl = TinTucBus.LayTinTucPT(pageIndex, pageSize);
            return Json(spl, JsonRequestBehavior.AllowGet);
        }
    }
}