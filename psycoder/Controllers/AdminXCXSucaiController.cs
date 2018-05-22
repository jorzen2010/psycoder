using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
using PagedList;
using PagedList.Mvc;
using psycoderDal;
using psycoderEntity;
using Common;
using AliyunVideo;

namespace psycoder.Controllers
{
    public class AdminXCXSucaiController : AdminBaseController
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        //
        // GET: /XCXSucai/
        public ActionResult Index(int? page,string type="tuwen")
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
            pager.strwhere = "type='"+type+"' and IfDelete=0";
            pager.PageSize = 2;
            pager.PageNo = page ?? 1;
            pager.FieldKey = "Id";
            pager.FiledOrder = "Id desc";

            pager = CommonDal.GetPager(pager);
            IList<XCXSucai> dataList = DataConvertHelper<XCXSucai>.ConvertToModel(pager.EntityDataTable);
            var PageList = new StaticPagedList<XCXSucai>(dataList, pager.PageNo, pager.PageSize, pager.Amount);
            return View(PageList);
        }

        public ActionResult deleteList(int? page, string type = "tuwen")
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
            pager.strwhere = "type='"+type+"' and IfDelete=1";
            pager.PageSize = 2;
            pager.PageNo = page ?? 1;
            pager.FieldKey = "Id";
            pager.FiledOrder = "Id desc";

            pager = CommonDal.GetPager(pager);
            IList<XCXSucai> dataList = DataConvertHelper<XCXSucai>.ConvertToModel(pager.EntityDataTable);
            var PageList = new StaticPagedList<XCXSucai>(dataList, pager.PageNo, pager.PageSize, pager.Amount);
            return View(PageList);
        }

        public ActionResult Create(string type="tuwen")
        {
            if(type=="tuwen")
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
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(XCXSucai xcxsucai)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.xcxSucaiRepository.Insert(xcxsucai);
                unitOfWork.Save();
                return RedirectToAction("Index", "AdminXCXSucai", new { type=xcxsucai.type});
            }
            return View(xcxsucai);
        }

        public ActionResult Edit(int id,string type)
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
            XCXSucai sucai = unitOfWork.xcxSucaiRepository.GetByID(id);

            if (sucai == null)
            {
                return HttpNotFound();
            }
            return View(sucai);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(XCXSucai xcxsucai)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.xcxSucaiRepository.Update(xcxsucai);
                unitOfWork.Save();
                return RedirectToAction("Index", "AdminXCXSucai", new { type = xcxsucai.type });
            }
            return View(xcxsucai);
        }

        //权限更改

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult UpdateStatus(int? id, bool status)
        {
            Message msg = new Message();
            if (id == null)
            {
                msg.MessageStatus = "false";
                msg.MessageInfo = "找不到ID";
            }
            XCXSucai xcxsucai = unitOfWork.xcxSucaiRepository.GetByID(id);
            xcxsucai.Qanxian = status;
            if (ModelState.IsValid)
            {

                unitOfWork.xcxSucaiRepository.Update(xcxsucai);
                unitOfWork.Save();
                msg.MessageStatus = "true";
                msg.MessageInfo = "已经更改为" + xcxsucai.Qanxian.ToString();
            }
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
        //回收站恢复
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult UpdateDelete(int? id, bool status)
        {
            Message msg = new Message();
            if (id == null)
            {
                msg.MessageStatus = "false";
                msg.MessageInfo = "找不到ID";
            }
            XCXSucai xcxsucai = unitOfWork.xcxSucaiRepository.GetByID(id);
            xcxsucai.IfDelete = status;
            if (ModelState.IsValid)
            {

                unitOfWork.xcxSucaiRepository.Update(xcxsucai);
                unitOfWork.Save();
                msg.MessageStatus = "true";
                msg.MessageInfo = "已经更改删除标识为：" + xcxsucai.IfDelete.ToString();
            }
            return Json(msg, JsonRequestBehavior.AllowGet);
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

                unitOfWork.xcxSucaiRepository.Delete(id);
                unitOfWork.Save();

                msg.MessageStatus = "true";
                msg.MessageInfo = "删除成功";
            }

            return Json(msg, JsonRequestBehavior.AllowGet);
        }

        public ActionResult View(int id, string type)
        {
            XCXSucai sucai = unitOfWork.xcxSucaiRepository.GetByID(id);

            if (sucai == null)
            {
                return HttpNotFound();
            }
            if (type == "tuwen")
            {
                ViewBag.title = "图文素材";
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
          
            else
            {
                type = "tuwen";
                ViewBag.title = "图文素材";
            }
            ViewBag.type = type;

            return View(sucai);
        }

        public ActionResult AudioView(int id)
        {
            XCXSucai sucai = unitOfWork.xcxSucaiRepository.GetByID(id);


            string ApiUrl = AliyunCommonParaConfig.ApiUrl;
            // 注意这里需要使用UTC时间，比北京时间少8小时。
            string Timestamp = DateTime.Now.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ", DateTimeFormatInfo.InvariantInfo);
            string Action = "GetVideoPlayAuth";
            string SignatureNonce = CommonTools.EncryptToSHA1(CommonTools.GenerateRandomNumber(8));


            //string VideoId = "c80b87bcb00d44c6883950605d798070";
            string VideoId = sucai.Content;
            ViewBag.VideoId = VideoId;

            ViewBag.PlayAuth = AliyunVideoServices.GetVideoInfo(ApiUrl, VideoId, Timestamp, Action, SignatureNonce).PlayAuth;
            ViewBag.title = "音频素材";
            VideoUrlInfo videoUrlfo = new VideoUrlInfo();
            videoUrlfo = AliyunVideoServices.VideoUrlInfo(ApiUrl, VideoId, Timestamp, "GetPlayInfo", SignatureNonce);
            ViewData["xxx"] = videoUrlfo;

            return View(sucai);
        }

	}
}