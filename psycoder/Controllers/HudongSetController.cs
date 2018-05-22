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
    public class HudongSetController : PsyBaseController
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private int psyId = 1;

        public ActionResult QuestionList(int? page)
        {

            Pager pager = new Pager();
            pager.table = "Question";
            pager.strwhere = "QuestionStatus=1";
            pager.PageSize = 2;
            pager.PageNo = page ?? 1;
            pager.FieldKey = "Id";
            pager.FiledOrder = "Id desc";

            pager = CommonDal.GetPager(pager);
            IList<Question> dataList = DataConvertHelper<Question>.ConvertToModel(pager.EntityDataTable);
            var PageList = new StaticPagedList<Question>(dataList, pager.PageNo, pager.PageSize, pager.Amount);
            return View(PageList);
        }

        public ActionResult HudongSet(string type = "Ziyoushuxie")
        {
            
            var questionList = unitOfWork.questionRepository.Get();
            if (type == "ZiyoushuxieReplyList")
            {
                ViewBag.Title = "自由书写";
            }
            else if (type == "QuestionReplyList")
            {
                ViewBag.Title = "问题引导";
                ViewData["question"] = questionList;
            }
            else if (type == "ZixunReplyList")
            {
                ViewBag.Title = "留言咨询";
            }
            else
            {
                type = "ZiyoushuxieReplyList";
                ViewBag.Title = "自由书写";
            }

            ViewBag.type = type;

            var hudongSettings = unitOfWork.hudongSettingRepository.Get(filter: u => u.PsyUser == psyId, orderBy: q => q.OrderByDescending(u => u.Id));
            HudongSetting setting = new HudongSetting();
            if (hudongSettings.Count() == 0)
            {

                DefaultHudongSetting defaultHudongSet = unitOfWork.defalutHudongSettingRepository.GetByID(1);
                setting.Id = 0;
                setting.PsyUser = psyId;
                setting.ZiyoushuxiePre = defaultHudongSet.ZiyoushuxiePre;
                setting.ZiyoushuxiePost = defaultHudongSet.ZiyoushuxiePost;
                setting.ZixunPre = defaultHudongSet.ZixunPre;
                setting.ZixunPost = defaultHudongSet.ZixunPost;
                setting.QuestionPre = defaultHudongSet.QuestionPre;
                setting.QuestionPost = defaultHudongSet.QuestionPost;
                setting.QuestionSelected = defaultHudongSet.QuestionSelected;
                setting.CreateTime = DateTime.Now;

            }
            else
            {
                setting = hudongSettings.First();
            }
            return View(setting);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(HudongSetting setting)
        {
            string type = Request.Form["type"].ToString();
            if (setting.Id == 0)
            {
                unitOfWork.hudongSettingRepository.Insert(setting);
                unitOfWork.Save();
                return RedirectToAction(type, "HudongSet");
            }
            else if (ModelState.IsValid)
            {
                setting.CreateTime = DateTime.Now;
                unitOfWork.hudongSettingRepository.Insert(setting);
                unitOfWork.Save();
                return RedirectToAction(type, "HudongSet");
            }
            else
            {
                return View(setting);
            }
            
        }



        public ActionResult ZiyoushuxieReplyList(int? page)
        {
            

            Pager pager = new Pager();
            pager.table = "ZiyoushuxieReply";
            pager.strwhere = "PsyUser="+psyId;
            pager.PageSize = 2;
            pager.PageNo = page ?? 1;
            pager.FieldKey = "Id";
            pager.FiledOrder = "Id desc";

            pager = CommonDal.GetPager(pager);
            IList<ZiyoushuxieReply> dataList = DataConvertHelper<ZiyoushuxieReply>.ConvertToModel(pager.EntityDataTable);
            var PageList = new StaticPagedList<ZiyoushuxieReply>(dataList, pager.PageNo, pager.PageSize, pager.Amount);
            return View(PageList);
        }
        public ActionResult QuestionReplyList(int? page)
        {
            
            Pager pager = new Pager();
            pager.table = "QuestionReply";
            pager.strwhere = "PsyUser=" + psyId;
            pager.PageSize = 2;
            pager.PageNo = page ?? 1;
            pager.FieldKey = "Id";
            pager.FiledOrder = "Id desc";

            pager = CommonDal.GetPager(pager);
            IList<QuestionReply> dataList = DataConvertHelper<QuestionReply>.ConvertToModel(pager.EntityDataTable);
            var PageList = new StaticPagedList<QuestionReply>(dataList, pager.PageNo, pager.PageSize, pager.Amount);
            return View(PageList);
        }

        public ActionResult ZixunReplyList(int? page)
        {
            
            Pager pager = new Pager();
            pager.table = "ZixunReply";
            pager.strwhere = "PsyUser=" + psyId;
            pager.PageSize = 2;
            pager.PageNo = page ?? 1;
            pager.FieldKey = "Id";
            pager.FiledOrder = "Id desc";

            pager = CommonDal.GetPager(pager);
            IList<ZixunReply> dataList = DataConvertHelper<ZixunReply>.ConvertToModel(pager.EntityDataTable);
            var PageList = new StaticPagedList<ZixunReply>(dataList, pager.PageNo, pager.PageSize, pager.Amount);
            return View(PageList);
        }

        public ActionResult GuanggaoSet()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult GuanggaoSet(GuanggaoSetting setting)
        {

            if (ModelState.IsValid)
            {
                unitOfWork.guanggaoSettingRepository.Insert(setting);
                unitOfWork.Save();
                return RedirectToAction("GuanggaoList", "HudongSet");
            }
            return View(setting);
        }

        public ActionResult GuanggaoList(int? page)
        {
            Pager pager = new Pager();
            pager.table = "GuanggaoSetting";
            pager.strwhere = "PsyUser="+psyId;
            pager.PageSize = 2;
            pager.PageNo = page ?? 1;
            pager.FieldKey = "Id";
            pager.FiledOrder = "Id desc";

            pager = CommonDal.GetPager(pager);
            IList<GuanggaoSetting> dataList = DataConvertHelper<GuanggaoSetting>.ConvertToModel(pager.EntityDataTable);
            var PageList = new StaticPagedList<GuanggaoSetting>(dataList, pager.PageNo, pager.PageSize, pager.Amount);
            return View(PageList);
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
            GuanggaoSetting guanggaoSet = unitOfWork.guanggaoSettingRepository.GetByID(id);
            guanggaoSet.GuanggaoStatus = status;
            if (ModelState.IsValid)
            {
                unitOfWork.guanggaoSettingRepository.Update(guanggaoSet);
                unitOfWork.Save();
                msg.MessageStatus = "true";
                msg.MessageInfo = "已经更改为" + guanggaoSet.GuanggaoStatus.ToString();
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

                unitOfWork.guanggaoSettingRepository.Delete(id);
                unitOfWork.Save();

                msg.MessageStatus = "true";
                msg.MessageInfo = "删除成功";
            }

            return Json(msg, JsonRequestBehavior.AllowGet);
        }


        public ActionResult CreateQuestionReply()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult CreateQuestionReply(QuestionReply reply)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.questionReplyRepository.Insert(reply);
                unitOfWork.Save();
                return RedirectToAction("QuestionReplyList", "HudongSet");
            }
            return View(reply);
        }
        public ActionResult CreateZiyoushuxieReply()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult CreateZiyoushuxieReply(ZiyoushuxieReply reply)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.ziyoushuxieReplyRepository.Insert(reply);
                unitOfWork.Save();
                return RedirectToAction("ZiyoushuxieReplyList", "HudongSet");
            }
            return View(reply);
        }
        public ActionResult CreateZixunReply()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult CreateZixunReply(ZixunReply reply)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.zixunReplyRepository.Insert(reply);
                unitOfWork.Save();
                return RedirectToAction("ZixunReplyList", "HudongSet");
            }
            return View(reply);
        }

	}
}