using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteFreshFood.Models;
using WebsiteFreshFood.Bussiness;
using System.IO;

namespace WebsiteFreshFood.Areas.Admin.Controllers
{
    public class QLTinTucController : Controller
    {
        TinTucBus TinTucBus = new TinTucBus();
        // GET: Admin/QLTinTuc
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

        [HttpPost]
        public JsonResult Insert(TinTuc t)
        {
            string res = TinTucBus.ThemTinTuc(t);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Update(TinTuc t)
        {
            string res = TinTucBus.SuaTinTuc(t);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Delete(string id)
        {
            string st = TinTucBus.XoaTinTuc(id);
            return Json(st, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Upload()
        {
            List<string> l = new List<string>();
            string path = Server.MapPath("~/img/TinTuc");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            foreach (string key in Request.Files)
            {
                HttpPostedFileBase pf = Request.Files[key];
                pf.SaveAs(path + pf.FileName);
                l.Add(pf.FileName);
            }
            return Json(l, JsonRequestBehavior.AllowGet);
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