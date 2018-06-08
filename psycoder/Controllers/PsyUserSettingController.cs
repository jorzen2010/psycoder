using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using Common;
using psycoderDal;
using psycoderEntity;

namespace psycoder.Controllers
{
    public class PsyUserSettingController : PsyBaseController
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private int psyId = int.Parse(System.Web.HttpContext.Current.Session["pid"].ToString());

        public ActionResult XCXSetting()
        {
            ZixunshiUser psyUser = unitOfWork.zixunshiUsersRepository.GetByID(psyId);
            return View(psyUser);
        }

        public ActionResult RenzhengInfo()
        {
          
            ZixunshiUser psyUser = unitOfWork.zixunshiUsersRepository.GetByID(psyId);
            return View(psyUser);
        }

        public ActionResult Setting()
        {
           
            ZixunshiUser psyUser = unitOfWork.zixunshiUsersRepository.GetByID(psyId);
            return View(psyUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult UpdateOpt(int Id, string optName, string optVal)
        {
            Message msg = new Message();
            string sql = "update ZixunshiUser set " + optName + "='" + optVal + "' where Id=" + Id;
            try
            {
                unitOfWork.zixunshiUsersRepository.UpdateWithRawSql(sql);
                msg.MessageStatus = "true";
                msg.MessageInfo = "更新成功";
            }
            catch (Exception ex)
            {
                msg.MessageStatus = "false";
                msg.MessageInfo = "更新失败" + ex.ToString();
            }

            return Json(msg, JsonRequestBehavior.AllowGet);
        }

       

	}
}