using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace psycoder.Controllers
{
    public class AdminBaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (Session["uname"] == null)
            {
                //filterContext.HttpContext.Response.Redirect("/User/Login");
                filterContext.Result = Redirect("/AdminAccount/Login");
            }
        }
	}
}