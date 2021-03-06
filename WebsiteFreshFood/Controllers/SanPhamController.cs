﻿using System;
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

        public ActionResult Search()
        {
            return View();
        }

        public JsonResult GetSanPham()
        {
            List<SanPham> lsp = spbus.LaySP(Session["maloai"].ToString());
            return Json(lsp, JsonRequestBehavior.AllowGet);
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

        /// <summary>
        /// Paging and searching
        /// </summary>
        /// <param name="pageIndex"> current page</param>
        /// <param name="pageSize"></param>
        /// <param name="productName"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetSanPhamPTLoai(int pageIndex, int pageSize)
        {
            if (Session["maloai"] == null)
            {
                Session.Add("maloai", "Rau");
            }
            SanPhamList spl = spbus.LaySanPhamPTLoai(Session["maloai"].ToString(), pageIndex, pageSize);
            return Json(spl, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SearchName(string tensp)
        {
            if (tensp == "")
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            else
            {
                List<SanPham> lsp = spbus.SearchNameSP(tensp);
                return Json(lsp, JsonRequestBehavior.AllowGet);
            }
        }

      
    }
}