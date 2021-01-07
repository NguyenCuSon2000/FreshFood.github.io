using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteFreshFood.Models;
using WebsiteFreshFood.DataAccess;
using WebsiteFreshFood.Bussiness;

namespace WebsiteFreshFood.Controllers
{
    public class GioiThieuController : Controller
    {
        // GET: GioiThieu
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetLoaiSanPham()
        {
            QLLoaiSanPhamBus bl = new QLLoaiSanPhamBus();
            List<LoaiSanPham> ll = bl.LayLoaiSanPham();
            return Json(ll, JsonRequestBehavior.AllowGet);
        }
    }
}