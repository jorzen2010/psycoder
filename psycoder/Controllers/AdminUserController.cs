using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace psycoder.Controllers
{
    public class AdminUserController : Controller
    {
        //
        // GET: /AdminUser/
        public ActionResult PsyUser()
        {
            return View();
        }
        public ActionResult FensiUser()
        {
            return View();
        }
	}
}