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
    public class SanPhamController : Controller
    {
        QLSanPhamBus spbus = new QLSanPhamBus();
        SanPhamDAL spd = new SanPhamDAL();
        // GET: SanPham
        public ActionResult Index(string maloai)
        {
            Session.Add("maloai", maloai);
            return View();
        }

        public JsonResult GetSanPham()
        {
            List<SanPham> lsp = spbus.LaySP(Session["maloai"].ToString());
            //List<SanPham> lsp = spbus.LaySP("Lẩu");
            return Json(lsp, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetSanPhamPTLoai(int pageIndex, int pageSize, string productName)
        {
            if (Session["maloai"] == null)
            {
                Session.Add("maloai", "Rau");
            }
            SanPhamList spl = spbus.LaySanPhamPT(Session["maloai"].ToString(), pageIndex, pageSize, productName);
            return Json(spl, JsonRequestBehavior.AllowGet);
        }

        //public JsonResult GetSanPhamPTLoai(string maloai, int pageIndex, int pageSize, string productName)
        //{
        //    SanPhamList spl = new SanPhamList();
        //    spl = spbus.LaySanPhamPT(maloai, pageIndex, pageSize, productName);
        //    return Json(spl, JsonRequestBehavior.AllowGet);
        //}
    }
}