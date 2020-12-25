using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteFreshFood.Models;
using WebsiteFreshFood.Bussiness;

namespace WebsiteFreshFood.Areas.Admin.Controllers
{
    public class ThongKeController : Controller
    {
        // GET: Admin/ThongKe
        public ActionResult Index()
        {
            return View("Index");
        }


        [HttpGet]
        public JsonResult GetThongKe(string maloai)
        {
            QLSanPhamBus qlsp = new QLSanPhamBus();
            ThongKeSLSP tk = qlsp.ThongKeSoLuongSP(maloai);
            return Json(tk, JsonRequestBehavior.AllowGet);
        }
    }
}