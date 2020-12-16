using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteFreshFood.Models;
using WebsiteFreshFood.DataAccess;

namespace WebsiteFreshFood.Bussiness
{
    public class TinTucBus
    {
        TinTucDAL TinTucDAL = new TinTucDAL();
        public List<TinTuc> LayAllTinTuc()
        {
            return TinTucDAL.GetAllTinTuc();
        }

        public List<TinTuc> LayTinTucMoiNhat()
        {
            return TinTucDAL.GetTinTucMoiNhat();
        }

        public string ThemTinTuc(TinTuc t)
        {
            return TinTucDAL.ThemTinTuc(t);
        }
        public string XoaTinTuc(string id)
        {
            return TinTucDAL.XoaTinTuc(id);
        }
        public string SuaTinTuc(TinTuc t)
        {
            return TinTucDAL.SuaTinTuc(t);
        }
    }
}