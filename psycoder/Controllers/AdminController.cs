using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace psycoder.Controllers
{
    public class AdminController : AdminBaseController
    {
        //
        // GET: /Admin/
        public ActionResult Index()
        {
            return View();
        }
	}
}