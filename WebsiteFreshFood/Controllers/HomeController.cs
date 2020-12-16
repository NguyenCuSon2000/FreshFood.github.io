using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteFreshFood.Bussiness;
using WebsiteFreshFood.Models;

namespace WebsiteFreshFood.Controllers
{
    public class HomeController : Controller
    {
        QLSanPhamBus spbus = new QLSanPhamBus();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Header_Search()
        {
            return PartialView("Header_Search");
        }

        public PartialViewResult TopMenu()
        {
            return PartialView("TopMenu");
        }

        public PartialViewResult SlideShow()
        {
            return PartialView("SlideShow");
        }
        
        public PartialViewResult GioHang()
        {
            return PartialView("GioHang");
        }

        public JsonResult GetLoaiSanPham()
        {
            QLLoaiSanPhamBus bl = new QLLoaiSanPhamBus();
            List<LoaiSanPham> ll = bl.LayLoaiSanPham();
            return Json(ll, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSanPhamNoiBat()
        {
            List<SanPham> list = spbus.SPNoiBatHome();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSanPhamMoiNhat()
        {
            List<SanPham> lnb = spbus.SanPhamMoiNhat();
            return Json(lnb, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSanPhamKhuyenMai()
        {
            GiamGiaBus ggbus = new GiamGiaBus();
            List<GiamGia> lgg = ggbus.GetSPKhuyenMai();
            return Json(lgg, JsonRequestBehavior.AllowGet);
        }
    }
}