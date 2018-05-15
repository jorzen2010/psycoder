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
    public class AdminNoticeController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        //
        // GET: /JkSucai/
        public ActionResult Index(int? page)
        {
           
            Pager pager = new Pager();
            pager.table = "Notice";
            pager.strwhere = "1=1";
            pager.PageSize = 2;
            pager.PageNo = page ?? 1;
            pager.FieldKey = "Id";
            pager.FiledOrder = "Id desc";

            pager = CommonDal.GetPager(pager);
            IList<Notice> dataList = DataConvertHelper<Notice>.ConvertToModel(pager.EntityDataTable);
            var PageList = new StaticPagedList<Notice>(dataList, pager.PageNo, pager.PageSize, pager.Amount);
            return View(PageList);
        }

        public ActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(Notice notice)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.noticesRepository.Insert(notice);
                unitOfWork.Save();
                return RedirectToAction("Index", "AdminNotice");
            }
            return View(notice);
        }

        public ActionResult Edit(int id)
        {

            Notice notice = unitOfWork.noticesRepository.GetByID(id);

            if (notice == null)
            {
                return HttpNotFound();
            }
            return View(notice);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Notice notice)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.noticesRepository.Update(notice);
                unitOfWork.Save();
                return RedirectToAction("Index", "AdminNotice");
            }
            return View(notice);
        }

        //彻底删除
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

                unitOfWork.noticesRepository.Delete(id);
                unitOfWork.Save();

                msg.MessageStatus = "true";
                msg.MessageInfo = "删除成功";
            }

            return Json(msg, JsonRequestBehavior.AllowGet);
        }


	}
}