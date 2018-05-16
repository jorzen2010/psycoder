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
    public class AdminUserController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();


     

        public ActionResult PsyUser(int? page)
        {
           
            Pager pager = new Pager();
            pager.table = "PsyUser";
            pager.strwhere = "1=1";
            pager.PageSize = 2;
            pager.PageNo = page ?? 1;
            pager.FieldKey = "Id";
            pager.FiledOrder = "Id desc";

            pager = CommonDal.GetPager(pager);
            IList<PsyUser> dataList = DataConvertHelper<PsyUser>.ConvertToModel(pager.EntityDataTable);
            var PageList = new StaticPagedList<PsyUser>(dataList, pager.PageNo, pager.PageSize, pager.Amount);
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
            PsyUser psyUser = unitOfWork.psyUsersRepository.GetByID(id);
            psyUser.PsyStatus = status;
            if (ModelState.IsValid)
            {

                unitOfWork.psyUsersRepository.Update(psyUser);
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
	}
}