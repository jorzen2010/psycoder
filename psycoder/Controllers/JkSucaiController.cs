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
using AliyunVideo;

namespace psycoder.Controllers
{
    public class JkSucaiController : PsyBaseController
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        //
        // GET: /JkSucai/
        public ActionResult Index(int? page, string type = "anli")
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

        public ActionResult View(int id, string type)
        {
            JkSucai sucai = unitOfWork.jkSucaiRepository.GetByID(id);

            if (sucai == null)
            {
                return HttpNotFound();
            }
            if (type == "anli")
            {
                ViewBag.title = "案例素材";
            }
            else if (type == "shipin")
            {
                string ApiUrl = AliyunCommonParaConfig.ApiUrl;
                // 注意这里需要使用UTC时间，比北京时间少8小时。
                string Timestamp = DateTime.Now.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ", DateTimeFormatInfo.InvariantInfo);
                string Action = "GetVideoPlayAuth";
                string SignatureNonce = CommonTools.EncryptToSHA1(CommonTools.GenerateRandomNumber(8));

                //  string VideoId = "6ccf973fe06741e49ab849d4cec017e0";

                string VideoId = sucai.Content;
                ViewBag.VideoId = VideoId;

                ViewBag.PlayAuth = AliyunVideoServices.GetVideoInfo(ApiUrl, VideoId, Timestamp, Action, SignatureNonce).PlayAuth;
                ViewBag.title = "视频素材";

            }

            else if (type == "tupian")
            {
                type = "tupian";
                ViewBag.title = "图片素材";
            }
            else {
                type = "anli";
                ViewBag.title = "案例素材";
            }
            ViewBag.type = type;

            return View(sucai);
        }

        public ActionResult AudioView(int id)
        {
            JkSucai sucai = unitOfWork.jkSucaiRepository.GetByID(id);


            string ApiUrl = AliyunCommonParaConfig.ApiUrl;
            // 注意这里需要使用UTC时间，比北京时间少8小时。
            string Timestamp = DateTime.Now.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ", DateTimeFormatInfo.InvariantInfo);
            string Action = "GetVideoPlayAuth";
            string SignatureNonce = CommonTools.EncryptToSHA1(CommonTools.GenerateRandomNumber(8));

            string VideoId = sucai.Content;
            ViewBag.VideoId = VideoId;

            ViewBag.PlayAuth = AliyunVideoServices.GetVideoInfo(ApiUrl, VideoId, Timestamp, Action, SignatureNonce).PlayAuth;
            ViewBag.title = "音频素材";

            return View(sucai);
        }
	}
}