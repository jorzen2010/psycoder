using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
using PagedList;
using PagedList.Mvc;
using Common;
using psycoderDal;
using psycoderEntity;
using psycoderService;
using AliyunVideo;

namespace psycoder.Controllers
{
    public class HomeController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        public ActionResult Index()
        {
            var  notices = unitOfWork.noticesRepository.Get(orderBy: q =>q.OrderByDescending(u=>u.Id));
            Notice notice = new Notice();
            if (notices.Count() > 0)
            {
                notice = notices.First();
            }
            else
            {
                notice.Title = "暂无公告";
            }

            ViewData["IndexNotice"] = notice;

            return View();
        }

        public ActionResult Reg()
        {
            var notices = unitOfWork.noticesRepository.Get(orderBy: q => q.OrderByDescending(u => u.Id));
            Notice notice = new Notice();
            if (notices.Count() > 0)
            {
                notice = notices.First();
            }
            else
            {
                notice.Title = "暂无公告";
            }

            ViewData["IndexNotice"] = notice;
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterAction()
        {
            return View();
        }

         public ActionResult Setting()
        {
            return View();
        }

         public ActionResult SafeCenter()
         {
             return View();
         }

         public ActionResult ZhuceInfo()
         {
             return View();
         }
    }
}