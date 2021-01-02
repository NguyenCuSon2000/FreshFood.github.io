using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteFreshFood.Models;
using WebsiteFreshFood.Bussiness;

namespace WebsiteFreshFood.Controllers
{
    public class CTSanPhamController : Controller
    {
        QLSanPhamBus spbus = new QLSanPhamBus();
        // GET: CTSanPham
        public ActionResult Index(int masp)
        {
            Session.Add("masp", masp);
            return View();
        }

        public JsonResult GetCTSanPham()
        {
            List<SanPham> sp = spbus.LaySPTheoMa(Convert.ToInt32(Session["masp"].ToString()));
            return Json(sp, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetLoaiSanPham()
        {
            QLLoaiSanPhamBus bl = new QLLoaiSanPhamBus();
            List<LoaiSanPham> ll = bl.LayLoaiSanPham();
            return Json(ll, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSanPhamNoiBat()
        {
            List<SanPham> lnb = spbus.SanPhamNoiBat();
            return Json(lnb, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSanPhamMoiNhat()
        {
            List<SanPham> lnb = spbus.SanPhamMoiNhat();
            return Json(lnb, JsonRequestBehavior.AllowGet);
        }

    }
}