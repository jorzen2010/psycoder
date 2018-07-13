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
using psycoderService;
using Common;
using AliyunVideo;

namespace psycoder.Controllers
{
    public class AdminJkSucaiController : AdminBaseController
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        //
        // GET: /JkSucai/
        public ActionResult Index(int? page,string type="anli")
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
            pager.strwhere = "type='"+type+"' and IfDelete=0";
            pager.PageSize = 2;
            pager.PageNo = page ?? 1;
            pager.FieldKey = "Id";
            pager.FiledOrder = "Id desc";

            pager = CommonDal.GetPager(pager);
            IList<JkSucai> dataList = DataConvertHelper<JkSucai>.ConvertToModel(pager.EntityDataTable);
            var PageList = new StaticPagedList<JkSucai>(dataList, pager.PageNo, pager.PageSize, pager.Amount);
            return View(PageList);
        }

        public ActionResult deleteList(int? page, string type = "tuwen")
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
            pager.strwhere = "type='" + type + "' and IfDelete=1";
            pager.PageSize = 2;
            pager.PageNo = page ?? 1;
            pager.FieldKey = "Id";
            pager.FiledOrder = "Id desc";

            pager = CommonDal.GetPager(pager);
            IList<JkSucai> dataList = DataConvertHelper<JkSucai>.ConvertToModel(pager.EntityDataTable);
            var PageList = new StaticPagedList<JkSucai>(dataList, pager.PageNo, pager.PageSize, pager.Amount);
            return View(PageList);
        }

        public ActionResult Create(string type="tuwen")
        {
            CategoryService cate = new CategoryService();
            
            if (type == "anli")
            {
                ViewBag.title = "案例素材";
                ViewData["Categorylist"] = cate.GetCategorySelectList(10);
            }
            else if (type == "yinpin")
            {
                ViewBag.title = "音频素材";
                ViewData["Categorylist"] = cate.GetCategorySelectList(11);
            }
            else if (type == "shipin")
            {
                ViewBag.title = "视频素材";
                ViewData["Categorylist"] = cate.GetCategorySelectList(12);

            }
            else if (type == "tupian")
            {
                ViewBag.title = "图片素材";
                ViewData["Categorylist"] = cate.GetCategorySelectList(13);

            }
            else
            {
                type = "anli";
                ViewBag.title = "案例素材";
                ViewData["Categorylist"] = cate.GetCategorySelectList(10);
            }
            ViewBag.type = type;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(JkSucai jkSucai)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.jkSucaiRepository.Insert(jkSucai);
                unitOfWork.Save();
                return RedirectToAction("Index", "AdminJkSucai", new { type = jkSucai.type });
            }
            return View(jkSucai);
        }

        public ActionResult Edit(int id,string type)
        {
            CategoryService cate = new CategoryService();
            if (type == "anli")
            {
                ViewBag.title = "案例素材";
                ViewData["Categorylist"] = cate.GetCategorySelectList(10);
            }
            else if (type == "yinpin")
            {
                ViewBag.title = "音频素材";
                ViewData["Categorylist"] = cate.GetCategorySelectList(11);
            }
            else if (type == "shipin")
            {
                ViewBag.title = "视频素材";
                ViewData["Categorylist"] = cate.GetCategorySelectList(12);

            }
            else if (type == "tupian")
            {
                ViewBag.title = "图片素材";
                ViewData["Categorylist"] = cate.GetCategorySelectList(13);

            }
            else
            {
                type = "anli";
                ViewBag.title = "案例素材";
                ViewData["Categorylist"] = cate.GetCategorySelectList(10);
            }
            ViewBag.type = type;
            JkSucai sucai = unitOfWork.jkSucaiRepository.GetByID(id);

            if (sucai == null)
            {
                return HttpNotFound();
            }
            return View(sucai);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(JkSucai jkSucai)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.jkSucaiRepository.Update(jkSucai);
                unitOfWork.Save();
                return RedirectToAction("Index", "AdminJkSucai", new { type = jkSucai.type });
            }
            return View(jkSucai);
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
                ViewBag.title = "图片素材";

            }
            else
            {
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


            //string VideoId = "c80b87bcb00d44c6883950605d798070";
            string VideoId = sucai.Content;
            ViewBag.VideoId = VideoId;

            ViewBag.PlayAuth = AliyunVideoServices.GetVideoInfo(ApiUrl, VideoId, Timestamp, Action, SignatureNonce).PlayAuth;
            ViewBag.title = "音频素材";

            return View(sucai);
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
            JkSucai jkSucai = unitOfWork.jkSucaiRepository.GetByID(id);
            jkSucai.Qanxian = status;
            if (ModelState.IsValid)
            {

                unitOfWork.jkSucaiRepository.Update(jkSucai);
                unitOfWork.Save();
                msg.MessageStatus = "true";
                msg.MessageInfo = "已经更改为" + jkSucai.Qanxian.ToString();
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
            JkSucai jkSucai = unitOfWork.jkSucaiRepository.GetByID(id);
            jkSucai.IfDelete = status;
            if (ModelState.IsValid)
            {

                unitOfWork.jkSucaiRepository.Update(jkSucai);
                unitOfWork.Save();
                msg.MessageStatus = "true";
                msg.MessageInfo = "已经更改删除标识为：" + jkSucai.IfDelete.ToString();
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

                unitOfWork.jkSucaiRepository.Delete(id);
                unitOfWork.Save();

                msg.MessageStatus = "true";
                msg.MessageInfo = "删除成功";
            }

            return Json(msg, JsonRequestBehavior.AllowGet);
        }

	}
}