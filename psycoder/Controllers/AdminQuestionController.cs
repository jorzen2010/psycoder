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
    public class AdminQuestionController : AdminBaseController
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(Question question)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.questionRepository.Insert(question);
                unitOfWork.Save();
                return RedirectToAction("Index", "AdminQuestion");
            }
            return View(question);
        }

        public ActionResult Index(int? page)
        {

            Pager pager = new Pager();
            pager.table = "Question";
            pager.strwhere = "1=1";
            pager.PageSize = 2;
            pager.PageNo = page ?? 1;
            pager.FieldKey = "Id";
            pager.FiledOrder = "Id desc";

            pager = CommonDal.GetPager(pager);
            IList<Question> dataList = DataConvertHelper<Question>.ConvertToModel(pager.EntityDataTable);
            var PageList = new StaticPagedList<Question>(dataList, pager.PageNo, pager.PageSize, pager.Amount);
            return View(PageList);
        }

        public ActionResult Edit(int id)
        {

            Question question = unitOfWork.questionRepository.GetByID(id);

            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Question question)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.questionRepository.Update(question);
                unitOfWork.Save();
                return RedirectToAction("Index", "AdminQuestion");
            }
            return View(question);
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
            Question question = unitOfWork.questionRepository.GetByID(id);
            question.QuestionStatus = status;
            if (ModelState.IsValid)
            {

                unitOfWork.questionRepository.Update(question);
                unitOfWork.Save();
                msg.MessageStatus = "true";
                msg.MessageInfo = "已经更改为" + question.QuestionStatus.ToString();
            }
            return Json(msg, JsonRequestBehavior.AllowGet);
        }


	}
}