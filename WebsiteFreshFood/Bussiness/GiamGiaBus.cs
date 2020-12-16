using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteFreshFood.Models;
using WebsiteFreshFood.DataAccess;

namespace WebsiteFreshFood.Bussiness
{
    public class GiamGiaBus
    {
        GiamGiaDAL GiamGiaDAL = new GiamGiaDAL();

        public List<GiamGia> GetSPKhuyenMai()
        {
            return GiamGiaDAL.LaySPKhuyenMai();
        }
    }
}