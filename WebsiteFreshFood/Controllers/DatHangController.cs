using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteFreshFood.Models;
using WebsiteFreshFood.Bussiness;
using Newtonsoft.Json;

namespace WebsiteFreshFood.Controllers
{
    public class DatHangController : Controller
    {
        // GET: DatHang
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult DatHang(DonDatHang ddh)
        {
            DonHang d = new DonHang();
            d.MaKH = ddh.Khach.MaKH;
            d.DiaChiNhan = ddh.Khach.DiaChi;
            d.SDTNhan = ddh.Khach.SDT;
            d.TinhTrang = 0;
            d.ThanhTien = ddh.TongTien;
            d.NgayDat = DateTime.Now;
            DatHangBus db = new DatHangBus();
            db.DatHang(ddh.Khach, d, ddh.LCTDonHang);
            return Json(0, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ReadAccount()
        {
            string l = "0";
            try
            {
                l = Request.Cookies["login"].Value;
            }
            catch(Exception ex)
            {
               
            }
            KhachHang k = null;
            string p = "";
            if (l == "1")
            {
                p = Request.Cookies["Khach"].Value;
                k = JsonConvert.DeserializeObject(p) as KhachHang;
            }
            Console.Write(p);
            return Json(new { login = l, Khach = k }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Login(string us, string pw, bool rp)
        {
            DatHangBus lb = new DatHangBus();
            Users u = lb.KiemTraDangNhap(us, pw);
            if (u == null) //Tài khoản không đúng
            {
                return Json(u, JsonRequestBehavior.AllowGet);
            }
            else //Tài khoản đúng
            { //Nếu không nhớ password thì xóa password
                if (!rp) { u.Pass = ""; }

                //Chuyển đối tượng
                string output = JsonConvert.SerializeObject(u);
                //b1 tạo cookie lưu thông tin về khách hàng
                HttpCookie ck = new HttpCookie("Khach", output);
                //b2 thiết lập thời gian tồn tại
                ck.Expires = DateTime.Now.AddDays(2);
                //b3 ghi biến cookie về brower
                Response.Cookies.Add(ck);


                //b1 tạo cookie lưu thông tin về trạng thái login
                HttpCookie ckl = new HttpCookie("login", "1");
                //b2 thiết lập thời gian tồn tại
                ck.Expires = DateTime.Now.AddDays(2);
                //b3 ghi biến cookie về brower
                Response.Cookies.Add(ckl);

                return Json(u, JsonRequestBehavior.AllowGet);
            }
        }
    }
}