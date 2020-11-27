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
        public ActionResult Index(string masp)
        {
            Session.Add("masp", masp);
            return View();
        }

        public JsonResult GetCTSanPham()
        {
            List<SanPham> lsp = spbus.LaySPTheoMa(Session["masp"].ToString());
            //List<SanPham> lsp = spbus.LaySP("Lẩu");
            return Json(lsp, JsonRequestBehavior.AllowGet);
        }
    }
}