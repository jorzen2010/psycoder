using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace psycoder.Controllers
{
    public class PsyBaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (Session["psyname"] == null)
            {
                //filterContext.HttpContext.Response.Redirect("/User/Login");
                filterContext.Result = Redirect("/PsyAccount/Login");
            }
        }
	}
}