using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
using Common;
using AliyunVideo;

namespace psycoder.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Reg()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterAction()
        {
            return View();
        }


        public ActionResult TuwenList()
        {
            return View();
        }
        public ActionResult AudioList()
        {
            string ApiUrl = AliyunCommonParaConfig.ApiUrl;
            // 注意这里需要使用UTC时间，比北京时间少8小时。
            string Timestamp = DateTime.Now.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ", DateTimeFormatInfo.InvariantInfo);
            string Action = "GetVideoPlayAuth";
            string SignatureNonce = CommonTools.EncryptToSHA1(CommonTools.GenerateRandomNumber(8));


            string VideoId = "c80b87bcb00d44c6883950605d798070";
            ViewBag.VideoId = VideoId;

            ViewBag.PlayAuth = AliyunVideoServices.GetVideoInfo(ApiUrl, VideoId, Timestamp, Action, SignatureNonce).PlayAuth;


            return View();
        }
        public ActionResult VideoList()
        {
            string ApiUrl = AliyunCommonParaConfig.ApiUrl;
            // 注意这里需要使用UTC时间，比北京时间少8小时。
            string Timestamp = DateTime.Now.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ", DateTimeFormatInfo.InvariantInfo);
            string Action = "GetVideoPlayAuth";
            string SignatureNonce = CommonTools.EncryptToSHA1(CommonTools.GenerateRandomNumber(8));


            string VideoId = "6ccf973fe06741e49ab849d4cec017e0";
            ViewBag.VideoId = VideoId;

            ViewBag.PlayAuth = AliyunVideoServices.GetVideoInfo(ApiUrl, VideoId, Timestamp, Action, SignatureNonce).PlayAuth;
            return View();
        }
        public ActionResult ZiyouList()
        {
            return View();
        }
        public ActionResult HudongSet()
        {
            return View();
        }
        public ActionResult WentiList()
        {
            return View();
        }
        public ActionResult ZixunList()
        {
            return View();
        }

        public ActionResult ScAnli()
        {
            return View();
        }

        public ActionResult ScTupian()
        {
            return View();
        }

        public ActionResult ScAudio()
        {
            return View();
        }

        public ActionResult ScVideo()
        {
            return View();
        }

         public ActionResult Setting()
        {
            return View();
        }

         public ActionResult SafeCenter()
         {
             return View();
         }

         public ActionResult ZhuceInfo()
         {
             return View();
         }
    }
}