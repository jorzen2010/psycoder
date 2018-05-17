using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
using PagedList;
using PagedList.Mvc;
using Common;
using psycoderDal;
using psycoderEntity;
using psycoderService;
using AliyunVideo;

namespace psycoder.Controllers
{
    public class HomeController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        public ActionResult Index()
        {
            var  notices = unitOfWork.noticesRepository.Get(orderBy: q =>q.OrderByDescending(u=>u.Id));
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

            return View();
        }

        public ActionResult Reg()
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

        public ActionResult XCXSucai(int? page, string type = "tuwen")
        {
            if (type == "tuwen")
            {
                ViewBag.title = "图文素材";
            }
            else if (type == "yinpin")
            {
                ViewBag.title = "音频素材";
            }
            else if (type == "shipin")
            {
                ViewBag.title = "视频素材";

            }
            else
            {
                type = "tuwen";
                ViewBag.title = "图文素材";
            }

            ViewBag.type = type;
            Pager pager = new Pager();
            pager.table = "XCXSucai";
            pager.strwhere = "type='" + type + "' and IfDelete=0 and Qanxian=1";
            pager.PageSize = 2;
            pager.PageNo = page ?? 1;
            pager.FieldKey = "Id";
            pager.FiledOrder = "Id desc";

            pager = CommonDal.GetPager(pager);
            IList<XCXSucai> dataList = DataConvertHelper<XCXSucai>.ConvertToModel(pager.EntityDataTable);
            var PageList = new StaticPagedList<XCXSucai>(dataList, pager.PageNo, pager.PageSize, pager.Amount);
            return View(PageList);
        }

        public ActionResult JkSucai(int? page, string type = "anli")
        {
            if (type == "anli")
            {
                ViewBag.title = "案例素材";
            }
            else if (type == "yinpin")
            {
                ViewBag.title = "音频素材";
            }
            else if (type == "shipin")
            {
                ViewBag.title = "视频素材";

            }
            else if (type == "tupian")
            {
                ViewBag.title = "图片素材";

            }
            else
            {
                type = "anli";
                ViewBag.title = "案例素材";
            }

            ViewBag.type = type;
            Pager pager = new Pager();
            pager.table = "JkSucai";
            pager.strwhere = "type='" + type + "' and IfDelete=0";
            pager.PageSize = 2;
            pager.PageNo = page ?? 1;
            pager.FieldKey = "Id";
            pager.FiledOrder = "Id desc";

            pager = CommonDal.GetPager(pager);
            IList<JkSucai> dataList = DataConvertHelper<JkSucai>.ConvertToModel(pager.EntityDataTable);
            var PageList = new StaticPagedList<JkSucai>(dataList, pager.PageNo, pager.PageSize, pager.Amount);
            return View(PageList);
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