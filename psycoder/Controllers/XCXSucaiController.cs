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
    public class XCXSucaiController : PsyBaseController
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private int psyId = int.Parse(System.Web.HttpContext.Current.Session["pid"].ToString());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult UpdateSelect(int psyId,int sucaiId,bool status,string type)
        {
            Message msg = new Message();
            XCXSucaiSelected sucaiSelect = null;
            var sucaiSelecteds = unitOfWork.xcxSucaiSelectedsRepository.Get(filter: u => u.Zixunshi == psyId && u.Sucai == sucaiId);
            if (sucaiSelecteds.Count() == 0)
            {
                sucaiSelect = new XCXSucaiSelected();
                sucaiSelect.Zixunshi = psyId;
                sucaiSelect.Paixu = 0;
                sucaiSelect.Status = status;
                sucaiSelect.Sucai = sucaiId;
                sucaiSelect.SucaiType = type;
                sucaiSelect.CreateTime = DateTime.Now;
                sucaiSelect.UpdateTime = DateTime.Now;
                unitOfWork.xcxSucaiSelectedsRepository.Insert(sucaiSelect);
                unitOfWork.Save();
                msg.MessageStatus = "true";
                msg.MessageInfo = "新增选择成功，状态为" + sucaiSelect.Status.ToString();
            }
            else if (sucaiSelecteds.Count() > 0)
            {
                sucaiSelect = sucaiSelecteds.First();
                sucaiSelect.UpdateTime = DateTime.Now;
                sucaiSelect.Status = status;
                unitOfWork.xcxSucaiSelectedsRepository.Update(sucaiSelect);
                unitOfWork.Save();
                msg.MessageStatus = "true";
                msg.MessageInfo = "重新选择或取消选择成功，状态为" + sucaiSelect.Status.ToString();
            }



            return Json(msg, JsonRequestBehavior.AllowGet);
        }

        public ActionResult XCXSucaiSelected(int? page, string type = "tuwen")
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
            pager.table = "XCXSucaiSelected";
            pager.strwhere = "SucaiType='" + type + "' and Zixunshi="+psyId+" and Status=1";
            pager.PageSize = 2;
            pager.PageNo = page ?? 1;
            pager.FieldKey = "Id";
            pager.FiledOrder = "UpdateTime desc";

            pager = CommonDal.GetPager(pager);
            IList<XCXSucaiSelected> dataList = DataConvertHelper<XCXSucaiSelected>.ConvertToModel(pager.EntityDataTable);
            var PageList = new StaticPagedList<XCXSucaiSelected>(dataList, pager.PageNo, pager.PageSize, pager.Amount);
            ViewBag.PsyId = psyId;
            return View(PageList);
        }

        public ActionResult XCXSucaiAll(int? page, string type = "tuwen")
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
            ViewBag.PsyId = psyId;
            return View(PageList);
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



          
            return View(sucai);
        }


       
	}
}