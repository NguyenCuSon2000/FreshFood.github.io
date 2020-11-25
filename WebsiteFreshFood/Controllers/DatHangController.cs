using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteFreshFood.Models;
using WebsiteFreshFood.Bussiness;

namespace WebsiteFreshFood.Controllers
{
    public class DatHangController : Controller
    {
        // GET: DatHang
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult DatHang(KhachHang k, double tongtien, List<CTDonHang> ct)
        {
            DonHang d = new DonHang();
            d.MaKH = k.MaKH;
            d.DiaChiNhan = k.DiaChi;
            d.SDTNhan = k.SDT;
            d.TinhTrang = 0;
            d.ThanhTien = tongtien;
            d.NgayDat = DateTime.Now;
            DatHangBus db = new DatHangBus();
            db.DatHang(k, d, ct);
            return Json(0, JsonRequestBehavior.AllowGet);
        }
    }
}