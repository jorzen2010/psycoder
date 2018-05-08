using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace psycoder.Controllers
{
    public class AdminTuwenController : Controller
    {
        //
        // GET: /AdminTuwen/
        public ActionResult Index(int tag)
        {
           
            ViewBag.tag = tag;
         
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
    
        public ActionResult Edit()
        {
            return View();
        }
       
	}
}