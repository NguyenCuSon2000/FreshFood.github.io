using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteFreshFood.Bussiness;
using WebsiteFreshFood.Models;

namespace WebsiteFreshFood.Areas.Admin.Controllers
{
    public class QLKhachHangController : BaseController
    {
        QLKhachHangBus qlkh = new QLKhachHangBus();
        // GET: Admin/QLKhachHang
        public ActionResult Index()
        {
            return View("Index");
        }

        [HttpGet]
        public JsonResult GetKhachHang()
        {
            List<KhachHang> lsp = qlkh.LayAllKhachHang();
            return Json(lsp, JsonRequestBehavior.AllowGet);
        }
     
        public JsonResult Search(string tenkh)
        {
            if (tenkh == "")
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            else
            {
                List<KhachHang> lkh = qlkh.TimKiemKhachHang(tenkh);
                return Json(lkh, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult Insert(KhachHang k)
        {
            string res = qlkh.ThemKhachHang(k);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Update(KhachHang k)
        {
            string res = qlkh.SuaKhachHang(k);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Delete(string id)
        {
            string st = qlkh.XoaKhachHang(id);
            return Json(st, JsonRequestBehavior.AllowGet);
        }
    }
}