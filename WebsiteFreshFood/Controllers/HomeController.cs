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
    }
}