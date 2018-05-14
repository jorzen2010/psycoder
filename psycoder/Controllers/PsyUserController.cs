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
    public class PsyUserController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult RegisterJibenxinxi(string PsyUserEmail, string PsyPassword, bool PsyStatus)
        {
            Message msg = new Message();



            PsyUser psyUser = new PsyUser();

            psyUser.PsyUserEmail = PsyUserEmail;
            psyUser.PsyPassword = PsyPassword;
            psyUser.PsyStatus = PsyStatus;
            try
            {
                unitOfWork.psyUsersRepository.Insert(psyUser);
                unitOfWork.Save();
                msg.MessageStatus = "true";
                msg.MessageInfo = "插入成功";
            }
            catch
            {
                msg.MessageStatus = "false";
                msg.MessageInfo = "插入失败";
            }
            
                return Json(msg, JsonRequestBehavior.AllowGet);
           


        }

	}
}