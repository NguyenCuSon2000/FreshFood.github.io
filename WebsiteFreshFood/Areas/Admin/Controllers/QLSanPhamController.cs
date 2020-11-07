using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteFreshFood.Bussiness;
using WebsiteFreshFood.Models;
using System.IO;

namespace WebsiteFreshFood.Areas.Admin.Controllers
{
    public class QLSanPhamController : Controller
    {
        QLSanPhamBus qlsp = new QLSanPhamBus();
        // GET: Admin/QLSanPham
        public ActionResult Index()
        {
            return View("Index");
        }

        [HttpGet]
        public JsonResult GetSanPham()
        {
            List<SanPham> lsp = qlsp.LayAllSanPham();
            return Json(lsp, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSanPhamPT(int pageIndex, int pageSize, string productName)
        {
            if (Session["maloai"] == null)
            {
                Session.Add("maloai", "Rau");
            }
            SanPhamList spl = qlsp.LaySanPhamPT(Session["maloai"].ToString(), pageIndex, pageSize, productName);
            return Json(spl, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Insert(SanPham s)
        {
            string res = qlsp.ThemSanPham(s);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(SanPham s)
        {
            string res = qlsp.SuaSanPham(s);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(string id)
        {
            string st = qlsp.XoaSanPham(id);
            return Json(st, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Upload(string maloai)
        {
            List<string> l = new List<string>();
            string path = Server.MapPath("~/img/" + maloai + "/");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            foreach(string key in Request.Files)
            {
                HttpPostedFileBase pf = Request.Files[key];
                pf.SaveAs(path + pf.FileName);
                l.Add(pf.FileName);
            }
            return Json(l, JsonRequestBehavior.AllowGet);
        }
    }
}