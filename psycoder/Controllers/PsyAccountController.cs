using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System.Data;
using System.Collections;
using Common;
using psycoderDal;
using psycoderEntity;
using psycoderService;

namespace psycoder.Controllers
{
    public class PsyAccountController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        public ActionResult Login()
        {

            var notices = unitOfWork.noticesRepository.Get(orderBy: q => q.OrderByDescending(u => u.Id));
            Notice notice = new Notice();
            if (notices.Count() > 0)
            {
                notice = notices.First();
            }
            else
            {
                notice.Title = "暂无公告";
            }

            ViewData["IndexNotice"] = notice;
            ViewBag.msg = "";
            FormsAuthentication.SignOut();
            if (!string.IsNullOrEmpty(Request["returnUrl"]))
            {

                ViewBag.returnUrl = Request["returnUrl"].ToString();
                ViewBag.msg = "对不起，您尚未登陆不允许访问！";

            }
            
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Response.Cookies["psyname"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["psyid"].Expires = DateTime.Now.AddDays(-1);
            System.Web.HttpContext.Current.Session["psyid"] = null;
            System.Web.HttpContext.Current.Session["psyname"] = null;
            return RedirectToAction("Index","Home");
           // return View("Login");
        }
        [HttpPost]
        public ActionResult Login(FormCollection fc)
        {
            System.Web.HttpContext.Current.Session["psyname"] = "";
            string username = fc["UserName"];
            string password = CommonTools.ToMd5(fc["Password"].ToString());
            string reurnUrl = fc["ReturnUrl"];




            var psyUsers = unitOfWork.zixunshiUsersRepository.Get(filter: u => u.PsyUserEmail == username && u.PsyPassword == password);
            if (psyUsers.Count() > 0)
            {
                if (psyUsers.First().PsyStatus)
                {
                    HttpCookie cookie = new HttpCookie("psyname");
                    cookie.Value = username;
                    System.Web.HttpContext.Current.Response.Cookies.Add(cookie);

                    HttpCookie cookieid = new HttpCookie("psyid");
                    cookieid.Value = psyUsers.First().Id.ToString();
                    System.Web.HttpContext.Current.Response.Cookies.Add(cookieid);

                    System.Web.HttpContext.Current.Session["psyid"] = psyUsers.First().PsyUserEmail.ToString();
                    System.Web.HttpContext.Current.Session["psyname"] = username;
                    System.Web.HttpContext.Current.Session["pid"] = psyUsers.First().Id.ToString();

                    FormsAuthentication.SetAuthCookie(username, true);

                    if (string.IsNullOrEmpty(reurnUrl))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.msg = "没有权限";
                        return Redirect(reurnUrl);
                    }

                }

                else
                {
                    var notices = unitOfWork.noticesRepository.Get(orderBy: q => q.OrderByDescending(u => u.Id));
                    Notice notice = new Notice();
                    if (notices.Count() > 0)
                    {
                        notice = notices.First();
                    }
                    else
                    {
                        notice.Title = "暂无公告";
                    }

                    ViewData["IndexNotice"] = notice;
                    ViewBag.msg = "此账号已经尚未开通或被禁用，请联系管理员";
                    return View();

                }

            }
            else
            {
                var notices = unitOfWork.noticesRepository.Get(orderBy: q => q.OrderByDescending(u => u.Id));
                Notice notice = new Notice();
                if (notices.Count() > 0)
                {
                    notice = notices.First();
                }
                else
                {
                    notice.Title = "暂无公告";
                }

                ViewData["IndexNotice"] = notice;
                ViewBag.msg = "用户名或密码错误了";
                return View();

            }


        }

	}
}