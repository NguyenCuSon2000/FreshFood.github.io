using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteFreshFood.Models;

namespace WebsiteFreshFood.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public JsonResult AddCart(SanPham s)
        {
            if(Session["giohang"] == null)
            {
                Session["giohang"] = new List<CTDonHang>();
            }
            List<CTDonHang> giohang = Session["giohang"] as List<CTDonHang>;
            CTDonHang d = null;
            //Kiểm tra xem sản phẩm khách đang chọn đã có trong giỏ hàng chưa
            if (giohang.Find(m => m.MaSP == s.MaSP) == null)
            {
                d = new CTDonHang();
                d.MaSP = s.MaSP;
                d.DonGia = s.DonGia;
                d.SoLuong = 1;
                giohang.Add(d);
            }
            else
            {
                giohang.Find(m => m.MaSP == s.MaSP).SoLuong = giohang.Find(m => m.MaSP == s.MaSP).SoLuong + 1;
            }
            float soluong = 0;
            foreach(CTDonHang c in giohang)
            {
                soluong = soluong + c.SoLuong;
            }
            return Json(new { ctdon = d, sl = soluong }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCarts()
        {
            float sl = 0;
            Double thanhtien = 0;
            List<CTDonHang> ds = new List<CTDonHang>();
            if (Session["giohang"] == null)
            {
                Session["giohang"] = new List<CTDonHang>();
                sl = 0;
                thanhtien = 0;
            }
            else
            {
                ds = Session["giohang"] as List<CTDonHang>;
                thanhtien = Convert.ToDouble(ds.Sum(s => s.DonGia * s.SoLuong));
                sl = ds.Sum(s => s.SoLuong);
            }
            return Json(new { DSDonHang = ds, soluong = sl, ThanhTien = thanhtien }, JsonRequestBehavior.AllowGet);
        }
    }
}