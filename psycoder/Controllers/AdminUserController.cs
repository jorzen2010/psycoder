using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using psycoderDal;
using psycoderEntity;
using Common;

namespace psycoder.Controllers
{
    public class AdminUserController : AdminBaseController
    {
        private UnitOfWork unitOfWork = new UnitOfWork();


     

        public ActionResult PsyUser(int? page)
        {
           
            Pager pager = new Pager();
            pager.table = "ZixunshiUser";
            pager.strwhere = "1=1";
            pager.PageSize = 2;
            pager.PageNo = page ?? 1;
            pager.FieldKey = "Id";
            pager.FiledOrder = "Id desc";

            pager = CommonDal.GetPager(pager);
            IList<ZixunshiUser> dataList = DataConvertHelper<ZixunshiUser>.ConvertToModel(pager.EntityDataTable);
            var PageList = new StaticPagedList<ZixunshiUser>(dataList, pager.PageNo, pager.PageSize, pager.Amount);
            return View(PageList);
        }

        public ActionResult FensiUser(int? page)
        {

            Pager pager = new Pager();
            pager.table = "FensiUser";
            pager.strwhere = "1=1";
            pager.PageSize = 2;
            pager.PageNo = page ?? 1;
            pager.FieldKey = "Id";
            pager.FiledOrder = "Id desc";

            pager = CommonDal.GetPager(pager);
            IList<FensiUser> dataList = DataConvertHelper<FensiUser>.ConvertToModel(pager.EntityDataTable);
            var PageList = new StaticPagedList<FensiUser>(dataList, pager.PageNo, pager.PageSize, pager.Amount);
            return View(PageList);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult UpdatePsyUserStatus(int? id, bool status)
        {
            Message msg = new Message();
            if (id == null)
            {
                msg.MessageStatus = "false";
                msg.MessageInfo = "找不到ID";
            }
            ZixunshiUser psyUser = unitOfWork.zixunshiUsersRepository.GetByID(id);
            psyUser.PsyStatus = status;
            if (ModelState.IsValid)
            {

                unitOfWork.zixunshiUsersRepository.Update(psyUser);
                unitOfWork.Save();
                msg.MessageStatus = "true";
                msg.MessageInfo = "已经更改为" + psyUser.PsyStatus.ToString();
            }
            return Json(msg, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult UpdateFensiUserStatus(int? id, bool status)
        {
            Message msg = new Message();
            if (id == null)
            {
                msg.MessageStatus = "false";
                msg.MessageInfo = "找不到ID";
            }
            FensiUser fensiUser = unitOfWork.fensiUsersRepository.GetByID(id);
            fensiUser.FensiStatus = status;
            if (ModelState.IsValid)
            {

                unitOfWork.fensiUsersRepository.Update(fensiUser);
                unitOfWork.Save();
                msg.MessageStatus = "true";
                msg.MessageInfo = "已经更改为" + fensiUser.FensiStatus.ToString();
            }
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult CreateZixunshiApp(ZixunshiApp app)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.zixunshiAppsRepositoryRepository.Insert(app);
                unitOfWork.Save();
                return RedirectToAction("PsyUser", "AdminUser");
            }
            return RedirectToAction("ZixunshiApp", "AdminUser", new { pid=app.PsyUser});
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult EditZixunshiApp(ZixunshiApp app)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.zixunshiAppsRepositoryRepository.Update(app);
                unitOfWork.Save();
                return RedirectToAction("PsyUser", "AdminUser");
            }
            return RedirectToAction("ZixunshiApp", "AdminUser", new { pid = app.PsyUser });
        }

        public ActionResult ZixunshiApp(int pid)
        {
            ZixunshiApp app = new ZixunshiApp();
            var apps = unitOfWork.zixunshiAppsRepositoryRepository.Get(filter:u =>u.PsyUser==pid);
            if (apps.Count() > 0)
            {
                ViewBag.acmethod = "EditZixunshiApp";
                ViewBag.pid = pid;
                app = apps.First();
                return View(app);
            }
            else
            {
                ViewBag.acmethod = "CreateZixunshiApp";
                ViewBag.pid = pid;
                return View();
            }
            
        }
	}
}