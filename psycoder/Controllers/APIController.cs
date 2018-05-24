using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using System.Globalization;
using System.Data;
using System.Collections;
using psycoderDal;
using psycoderEntity;
using Common;
using AliyunVideo;

namespace psycoder.Controllers
{
    public class APIController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        //第一种方式测试成功
        public ActionResult Test(int? page)
        {


            Pager pager = new Pager();
            pager.table = "XCXSucai";
            pager.strwhere = "1=1";
            pager.PageSize = 1;
            pager.PageNo = page ?? 1;
            pager.FieldKey = "Id";
            pager.FiledOrder = "Id desc";


            pager = CommonDal.GetPager(pager);
            IList<XCXSucai> List = DataConvertHelper<XCXSucai>.ConvertToModel(pager.EntityDataTable);

            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            string json = js.Serialize(new { pagecount = pager.Amount, xcxsucai = List });//将对象序列化成JSON字符串。匿名类。向浏览器返回多个JSON对象。 

            //string jsonname = "xcxsucai";
            //string json = JsonHelper.ListToJson<XCXSucai>(List, jsonname);
            return Content(json);

        }
        //第一种方式测试失败
        public JsonResult Test2(int? page)
        {


            Pager pager = new Pager();
            pager.table = "XCXSucai";
            pager.strwhere = "1=1";
            pager.PageSize = 2;
            pager.PageNo = page ?? 1;
            pager.FieldKey = "Id";
            pager.FiledOrder = "Id desc";


            pager = CommonDal.GetPager(pager);
            
            IList<XCXSucai> List = DataConvertHelper<XCXSucai>.ConvertToModel(pager.EntityDataTable);

            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            string json = js.Serialize(new { pagecount = pager.Amount, xcxsucai = List });//将对象序列化成JSON字符串。匿名类。向浏览器返回多个JSON对象。  


            //string jsonname = "xcxsucai";
            //string json = JsonHelper.ListToJson<XCXSucai>(List, jsonname);
            return Json(json, JsonRequestBehavior.AllowGet);


        }

        public ActionResult GetPsyUser(int pid)
        {


            ZixunshiUser psyUser = new ZixunshiUser();
            psyUser = unitOfWork.zixunshiUsersRepository.GetByID(pid);

           // string jsonname = "zixunshi";
           // string json = JsonHelper.ListToJson<XCXSucai>(List, jsonname);
            string json = JsonHelper.JsonSerializerBySingleData(psyUser);
            return Content(json);

        }


        public ActionResult GetXCXSucai(int cid)
        {
            XCXSucai sucai = new XCXSucai();
            sucai = unitOfWork.xcxSucaiRepository.GetByID(cid);
            string json = JsonHelper.JsonSerializerBySingleData(sucai);
            return Content(json);

        }

        public JsonResult GetXCXSucaiJson(int cid)
        {
            XCXSucai sucai = new XCXSucai();
            sucai = unitOfWork.xcxSucaiRepository.GetByID(cid);
            string json = JsonHelper.JsonSerializerBySingleData(sucai);
            return Json(json, JsonRequestBehavior.AllowGet);
        //    return Content(json);

        }
        public ActionResult GetXCXVideoSucai(int cid)
        {
            XCXSucai sucai = unitOfWork.xcxSucaiRepository.GetByID(cid);


            string ApiUrl = AliyunCommonParaConfig.ApiUrl;
            // 注意这里需要使用UTC时间，比北京时间少8小时。
            string Timestamp = DateTime.Now.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ", DateTimeFormatInfo.InvariantInfo);
            string Action = "GetPlayInfo";
            string SignatureNonce = CommonTools.EncryptToSHA1(CommonTools.GenerateRandomNumber(8));


            string VideoId = sucai.Content;
            ViewBag.VideoId = VideoId;
            VideoUrlInfo videoUrlfo = new VideoUrlInfo();
            videoUrlfo = AliyunVideoServices.VideoUrlInfo(ApiUrl, VideoId, Timestamp, Action, SignatureNonce);

            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            string strjson = js.Serialize(new { sucai = sucai, videoUrlfo = videoUrlfo });//将对象序列化成JSON字符串。匿名类。向浏览器返回多个JSON对象。  

          //  string json = JsonHelper.JsonSerializerBySingleData(videoUrlfo);
            return Content(strjson);
        }

        public ActionResult GetSelectedXCXSucaiList(int? page,int pid)
        {


            Pager pager = new Pager();
            pager.table = "XCXSucaiSelected";
            pager.strwhere = "(SucaiType='shipin' or SucaiType='yinpin') and Zixunshi=" + pid;
            pager.PageSize = 2;
            pager.PageNo = page ?? 1;
            pager.FieldKey = "Id";
            pager.FiledOrder = "Id desc";


            pager = CommonDal.GetPager(pager);
            IList<XCXSucaiSelected> List = DataConvertHelper<XCXSucaiSelected>.ConvertToModel(pager.EntityDataTable);

            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            string json = js.Serialize(new { pagecount = pager.Amount, selectsucai = List });//将对象序列化成JSON字符串。匿名类。向浏览器返回多个JSON对象。 

            //string jsonname = "xcxsucai";
            //string json = JsonHelper.ListToJson<XCXSucai>(List, jsonname);
            return Content(json);

        }
       
	}
}