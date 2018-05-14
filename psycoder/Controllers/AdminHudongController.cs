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
    public class AdminHudongController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        //
        // GET: /AdminHudong/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Ziyoushuxie()
        {
            return View();
        }
        public ActionResult QuestionList()
        {
            return View();
        }
        public ActionResult ZixunList()
        {
            return View();
        }
        
        public ActionResult HudongSet(string type = "Ziyoushuxie")
        {
            if (type == "Ziyoushuxie")
            {
                ViewBag.Title = "自由书写";
            }
            else if (type == "QuestionList")
            {
                ViewBag.Title = "问题引导";
            }
            else if (type == "ZixunList")
            {
                ViewBag.Title = "留言咨询";
            }

            ViewBag.type = type;
            int id = 1;
            DefaultHudongSetting setting = unitOfWork.defalutHudongSettingRepository.GetByID(id);
            if (setting == null)
            {
                return HttpNotFound();
               
            }
            return View(setting);
        }

        public ActionResult AdvertList(int? page)
        {
            Pager pager = new Pager();
            pager.table = "DefaultGuanggaoSetting";
            pager.strwhere = "1=1";
            pager.PageSize = 2;
            pager.PageNo = page ?? 1;
            pager.FieldKey = "Id";
            pager.FiledOrder = "Id desc";

            pager = CommonDal.GetPager(pager);
            IList<DefaultGuanggaoSetting> dataList = DataConvertHelper<DefaultGuanggaoSetting>.ConvertToModel(pager.EntityDataTable);
            var PageList = new StaticPagedList<DefaultGuanggaoSetting>(dataList, pager.PageNo, pager.PageSize, pager.Amount);
            return View(PageList);
        }

        public ActionResult GuanggaoSet()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult GuanggaoSet(DefaultGuanggaoSetting setting)
        {

            if (ModelState.IsValid)
            {
                unitOfWork.defaultGuanggaoSettingRepository.Insert(setting);
                unitOfWork.Save();
                return RedirectToAction("GuanggaoSet", "AdminHudong");
            }
            return View(setting);
        }

       

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(DefaultHudongSetting setting)
        {
            string type = Request.Form["type"].ToString();
            if (ModelState.IsValid)
            {
                unitOfWork.defalutHudongSettingRepository.Update(setting);
                unitOfWork.Save();
                return RedirectToAction(type, "AdminHudong");
            }
            return View(setting);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult UpdateStatus(int? id, bool status)
        {
            Message msg = new Message();
            if (id == null)
            {
                msg.MessageStatus = "false";
                msg.MessageInfo = "找不到ID";
            }
            DefaultGuanggaoSetting  defaultGuanggao = unitOfWork.defaultGuanggaoSettingRepository.GetByID(id);
            defaultGuanggao.GuanggaoStatus = status;
            if (ModelState.IsValid)
            {

                unitOfWork.defaultGuanggaoSettingRepository.Update(defaultGuanggao);
                unitOfWork.Save();
                msg.MessageStatus = "true";
                msg.MessageInfo = "已经更改为" + defaultGuanggao.GuanggaoStatus.ToString();
            }
            return Json(msg, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult DeleteConfirmed(int? id)
        {
            Message msg = new Message();
            if (id == null)
            {
                msg.MessageStatus = "false";
                msg.MessageInfo = "找不到ID";
            }
            else
            {

                unitOfWork.defaultGuanggaoSettingRepository.Delete(id);
                unitOfWork.Save();

                msg.MessageStatus = "true";
                msg.MessageInfo = "删除成功";
            }

            return Json(msg, JsonRequestBehavior.AllowGet);
        }

	}
}