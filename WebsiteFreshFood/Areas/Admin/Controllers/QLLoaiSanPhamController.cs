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
    public class QLLoaiSanPhamController : Controller
    {
        QLLoaiSanPhamBus qllsp = new QLLoaiSanPhamBus();
        // GET: Admin/QLLoaiSanPham
        public ActionResult Index()
        {
            return View("Index");
        }

        public JsonResult GetAllLoaiSP()
        {
            List <LoaiSanPham> list = qllsp.LayLoaiSanPham();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Search(string tenLoai)
        {
            if (tenLoai == "")
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            else
            {
                List<LoaiSanPham> lsp = qllsp.TimKiemLoaiSanPham(tenLoai);
                return Json(lsp, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult Insert(LoaiSanPham l)
        {
            string res = qllsp.ThemLoaiSanPham(l);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Update(LoaiSanPham l)
        {
            string res = qllsp.SuaLoaiSanPham(l);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Delete(string id)
        {
            string st = qllsp.XoaLoaiSanPham(id);
            return Json(st, JsonRequestBehavior.AllowGet);
        }
      
    }
}