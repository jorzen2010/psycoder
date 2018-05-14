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

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult RegisterJibenxinxi( string PsyUserEmail, string PsyPassword, bool PsyStatus)
        {
            Message msg = new Message();
            PsyUser psyUser = new PsyUser();
            var psyUsers = unitOfWork.psyUsersRepository.Get(filter: u => u.PsyUserEmail == PsyUserEmail);
           // PsyUser psyUser =  unitOfWork.psyUsersRepository.GetByID(PsyId);
            if (psyUsers.Count()>0)
            {
                psyUser = psyUsers.First();
                psyUser.PsyPassword = PsyPassword;
                try
                {
                    unitOfWork.psyUsersRepository.Update(psyUser);
                    unitOfWork.Save();
                    msg.MessageStatus = "true";
                    msg.MessageInfo = "更新密码成功";
                }

                catch (Exception ex)
                {
                    msg.MessageStatus = "false";
                    msg.MessageInfo = "更新密码失败" + ex.Message;
                }


            }
            else
            {
               // psyUser = new PsyUser();
                psyUser.PsyUserEmail = PsyUserEmail;
                psyUser.PsyPassword = PsyPassword;
                psyUser.PsyStatus = PsyStatus;


                try
                {
                    unitOfWork.psyUsersRepository.Insert(psyUser);
                    unitOfWork.Save();
                    msg.MessageStatus = "true";
                    msg.MessageInfo = "插入成功";
                   // msg.MessageUrl = psyUser.Id.ToString();
                }
                catch (Exception ex)
                {
                    msg.MessageStatus = "false";
                    msg.MessageInfo = "插入失败" + ex.Message;
                }
            }

                return Json(msg, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult RegisterShenfen(string PsyEmail, string PsyRealName, string PsyNumber, string PsyZhengshuNumber)
        {
            Message msg = new Message();
            PsyUser psyUser = new PsyUser();
            var psyUsers = unitOfWork.psyUsersRepository.Get(filter: u => u.PsyUserEmail == PsyEmail);
           // psyUser = unitOfWork.psyUsersRepository.GetByID(PsyId);
            if (psyUsers.Count()>0)
            {
               
                psyUser = psyUsers.First();
                psyUser.PsyRealName = PsyRealName;
                psyUser.PsyNumber = PsyNumber;
                psyUser.PsyZhengshuNumber = PsyZhengshuNumber;
                try
                {
                    unitOfWork.psyUsersRepository.Update(psyUser);
                    unitOfWork.Save();
                    msg.MessageStatus = "true";
                    msg.MessageInfo = "身份认证成功";
                }

                catch (Exception ex)
                {
                    msg.MessageStatus = "false";
                    msg.MessageInfo = "身份认证失败" + ex.Message;
                }


            }
            else
            {
                
                    msg.MessageStatus = "false";
                    msg.MessageInfo = "身份认证失败：记录没找到";
            }

            return Json(msg, JsonRequestBehavior.AllowGet);
        }

	}
}