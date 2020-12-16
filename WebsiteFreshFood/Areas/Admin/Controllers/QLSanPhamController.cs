using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using WebsiteFreshFood.Models;
using WebsiteFreshFood.Bussiness;

namespace WebsiteFreshFood.Areas.Admin.Controllers
{
    [Authorize]
    public class QLSanPhamController : BaseController
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

        public JsonResult GetLoaiSanPham()
        {
            QLLoaiSanPhamBus bl = new QLLoaiSanPhamBus();
            List<LoaiSanPham> ll = bl.LayLoaiSanPham();
            return Json(ll, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Paging and searching
        /// </summary>
        /// <param name="pageIndex"> current page</param>
        /// <param name="pageSize"></param>
        /// <param name="productName"></param>
        /// <returns></returns>
        //[HttpGet]
        //public JsonResult GetSanPhamPT(int pageIndex, int pageSize, string productName)
        //{
        //    SanPhamList spl = qlsp.LaySanPhamPT("", pageIndex, pageSize, productName);
        //    return Json(spl, JsonRequestBehavior.AllowGet);
        //}

        public JsonResult Search(string tensp)
        {
            if (tensp == "")
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            else
            {
                List<SanPham> lsp = qlsp.TimKiemSanPham(tensp);
                return Json(lsp, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult Insert(SanPham s)
        {
            string res = qlsp.ThemSanPham(s);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Update(SanPham s)
        {
            string res = qlsp.SuaSanPham(s);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Delete(string id)
        {
            string st = qlsp.XoaSanPham(id);
            return Json(st, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult Upload(string maloai)
        {
            List<string> l = new List<string>();
            string path = Server.MapPath("~/img/" + maloai + "/");
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
    }
}