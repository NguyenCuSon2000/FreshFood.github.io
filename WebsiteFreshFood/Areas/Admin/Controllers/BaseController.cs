using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteFreshFood.Models;

namespace WebsiteFreshFood.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        // GET: Admin/Base
        protected override void OnActionExecuting(ActionExecutingContext filtercontext)
        {
            var usec = (Users)Session["User_Session"];
            if (usec == null)
            {
                filtercontext.Result = new RedirectToRouteResult
                (new System.Web.Routing.RouteValueDictionary
                (new { Controller = "Login", action = "Index", Area = "Admin" }));
            }
            base.OnActionExecuting(filtercontext);
        }
    }
}