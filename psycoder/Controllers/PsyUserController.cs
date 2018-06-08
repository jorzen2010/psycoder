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

        public ActionResult CheckPsyUserEmail(string PsyUserEmail)
        {
            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
             var psyUsers = unitOfWork.zixunshiUsersRepository.Get(filter: u => u.PsyUserEmail == PsyUserEmail);
             string json = string.Empty;
             if (psyUsers.Count() > 0)
             {
                 json = js.Serialize(new { valid = false });
             }
             else
             {
                 json = js.Serialize(new { valid = true });
             }
            return Content(json);;
 
        }

        public ActionResult CheckPsyUserNubmer(string PsyNumber)
        {
            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            string json = string.Empty;
            bool result = false;
            result = CommonTools.Verify(PsyNumber);
            if (result)
            {
                json = js.Serialize(new { valid = true });
            }
            else
            {
                json = js.Serialize(new { valid = false });
            }
            
            return Content(json); ;

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult RegisterJibenxinxi( string PsyUserEmail, string PsyPassword, string PsyAvatar, bool PsyStatus)
        {
            Message msg = new Message();
            ZixunshiUser psyUser = new ZixunshiUser();
            var psyUsers = unitOfWork.zixunshiUsersRepository.Get(filter: u => u.PsyUserEmail == PsyUserEmail);
            if (psyUsers.Count()>0)
            {
                psyUser = psyUsers.First();
                psyUser.PsyPassword = Common.CommonTools.ToMd5(PsyPassword);
                psyUser.CreateTime = DateTime.Now;
                
                try
                {
                    unitOfWork.zixunshiUsersRepository.Update(psyUser);
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
                psyUser.PsyUserEmail = PsyUserEmail;
                psyUser.PsyPassword = Common.CommonTools.ToMd5(PsyPassword);
                psyUser.PsyStatus = PsyStatus;
                psyUser.CreateTime = DateTime.Now;
                psyUser.PsyAvatar = PsyAvatar;
                try
                {
                    unitOfWork.zixunshiUsersRepository.Insert(psyUser);
                    unitOfWork.Save();
                    msg.MessageStatus = "true";
                    msg.MessageInfo = "插入成功";
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
        public JsonResult RegisterShenfen(string UserEmail, string PsyRealName, string PsyNumber, string PsyZhengshuNumber)
        {
            Message msg = new Message();
            ZixunshiUser psyUser = new ZixunshiUser();
            var psyUsers = unitOfWork.zixunshiUsersRepository.Get(filter: u => u.PsyUserEmail == UserEmail);
            if (psyUsers.Count()>0)
            {
               
                psyUser = psyUsers.First();
                psyUser.PsyRealName = PsyRealName;
                psyUser.PsyNickName = PsyRealName;
                psyUser.PsyNumber = PsyNumber;
                psyUser.PsyZhengshuNumber = PsyZhengshuNumber;
                try
                {
                    unitOfWork.zixunshiUsersRepository.Update(psyUser);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult RegisterLianxi(string UserEmail, string Email, string QQ, string Wechat, string Telephone)
        {
            Message msg = new Message();
            ZixunshiUser psyUser = new ZixunshiUser();
            var psyUsers = unitOfWork.zixunshiUsersRepository.Get(filter: u => u.PsyUserEmail == UserEmail);
            if (psyUsers.Count() > 0)
            {

                psyUser = psyUsers.First();
                psyUser.PsyEmail = Email;
                psyUser.PsyQQ = QQ;
                psyUser.PsyTelephone = Telephone;
                psyUser.PsyWechat = Wechat;
                try
                {
                    unitOfWork.zixunshiUsersRepository.Update(psyUser);
                    unitOfWork.Save();
                    msg.MessageStatus = "true";
                    msg.MessageInfo = "联系方式修改成功";
                }

                catch (Exception ex)
                {
                    msg.MessageStatus = "false";
                    msg.MessageInfo = "联系方式修改失败" + ex.Message;
                }


            }
            else
            {

                msg.MessageStatus = "false";
                msg.MessageInfo = "联系方式失败：记录没找到";
            }

            return Json(msg, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult RegisterPinpai(string UserEmail, string PsyTitle, string PsyInfo, string PsyContent, string PsyShanchang)
        {
            Message msg = new Message();
            ZixunshiUser psyUser = new ZixunshiUser();
            var psyUsers = unitOfWork.zixunshiUsersRepository.Get(filter: u => u.PsyUserEmail == UserEmail);
            if (psyUsers.Count() > 0)
            {

                psyUser = psyUsers.First();
                psyUser.PsyTitle = PsyTitle;
                psyUser.PsyInfo = PsyInfo;
                psyUser.PsyContent = PsyContent;
                psyUser.PsyShanchang = PsyShanchang;
                try
                {
                    unitOfWork.zixunshiUsersRepository.Update(psyUser);
                    unitOfWork.Save();
                    msg.MessageStatus = "true";
                    msg.MessageInfo = "个人品牌修改成功";
                }

                catch (Exception ex)
                {
                    msg.MessageStatus = "false";
                    msg.MessageInfo = "个人品牌修改失败" + ex.Message;
                }


            }
            else
            {

                msg.MessageStatus = "false";
                msg.MessageInfo = "个人品牌失败：记录没找到";
            }

            return Json(msg, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult SendEmail(string Tomail)
        {
           // string EmailSendCode = "123456";
            string EmailSendCode = Common.CommonTools.getRandomNumber(100000, 999999);
            Message msg = new Message();
            EmailServer emailServer=new EmailServer();
            emailServer.SMTPClient=EmailConfig.SMTPClient;
            emailServer.EmailAddress=EmailConfig.EmailAddress;
            emailServer.EmailPassword=EmailConfig.EmailPassword;
            EmailEntity entity = new EmailEntity();
            entity.ToMail = Tomail;
            entity.FromMail = emailServer.EmailAddress;
            entity.DisplayName = "心理咨询师讲师公众平台官方团队";
            entity.MailTitle = "验证码";
            entity.MailContent = "你的验证码为" + EmailSendCode;
           
            try
            {

                EmailServices.SendEmail(emailServer,entity);
                
                msg.MessageStatus = "true";
                msg.MessageInfo = EmailSendCode;
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