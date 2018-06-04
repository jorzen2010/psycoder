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
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.ServiceModel.Web;
using psycoderDal;
using psycoderEntity;
using Common;
using AliyunVideo;
using psycoder.WechatXiaochengxu;

namespace psycoder.Controllers
{
    public class APIController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        ////第一种方式测试成功
        //public ActionResult Test(int? page)
        //{


        //    Pager pager = new Pager();
        //    pager.table = "XCXSucai";
        //    pager.strwhere = "1=1";
        //    pager.PageSize = 1;
        //    pager.PageNo = page ?? 1;
        //    pager.FieldKey = "Id";
        //    pager.FiledOrder = "Id desc";


        //    pager = CommonDal.GetPager(pager);
        //    IList<XCXSucai> List = DataConvertHelper<XCXSucai>.ConvertToModel(pager.EntityDataTable);

        //    System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
        //    string json = js.Serialize(new { pagecount = pager.Amount, xcxsucai = List });//将对象序列化成JSON字符串。匿名类。向浏览器返回多个JSON对象。 

        //    //string jsonname = "xcxsucai";
        //    //string json = JsonHelper.ListToJson<XCXSucai>(List, jsonname);
        //    return Content(json);

        //}
        ////第一种方式测试失败
        //public JsonResult Test2(int? page)
        //{


        //    Pager pager = new Pager();
        //    pager.table = "XCXSucai";
        //    pager.strwhere = "1=1";
        //    pager.PageSize = 2;
        //    pager.PageNo = page ?? 1;
        //    pager.FieldKey = "Id";
        //    pager.FiledOrder = "Id desc";


        //    pager = CommonDal.GetPager(pager);
            
        //    IList<XCXSucai> List = DataConvertHelper<XCXSucai>.ConvertToModel(pager.EntityDataTable);

        //    System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
        //    string json = js.Serialize(new { pagecount = pager.Amount, xcxsucai = List });//将对象序列化成JSON字符串。匿名类。向浏览器返回多个JSON对象。  


        //    //string jsonname = "xcxsucai";
        //    //string json = JsonHelper.ListToJson<XCXSucai>(List, jsonname);
        //    return Json(json, JsonRequestBehavior.AllowGet);


        //}

        public ActionResult GetPsyUser(int pid)
        {


            ZixunshiUser psyUser = new ZixunshiUser();
            psyUser = unitOfWork.zixunshiUsersRepository.GetByID(pid);

           // string jsonname = "zixunshi";
           // string json = JsonHelper.ListToJson<XCXSucai>(List, jsonname);
            string json = JsonHelper.JsonSerializerBySingleData(psyUser);
            return Content(json);

        }

        public ActionResult GetQuestionById(int qid)
        {
            Question question = new Question();
            question = unitOfWork.questionRepository.GetByID(qid);
            string json = JsonHelper.JsonSerializerBySingleData(question);
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
            pager.strwhere = "(SucaiType='shipin' or SucaiType='yinpin') and Zixunshi=" + pid + " and Status=1";
            pager.PageSize = 2;
            pager.PageNo = page ?? 1;
            pager.FieldKey = "Id";
            pager.FiledOrder = "UpdateTime desc";


            pager = CommonDal.GetPager(pager);
            IList<XCXSucaiSelected> List = DataConvertHelper<XCXSucaiSelected>.ConvertToModel(pager.EntityDataTable);

            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            string json = js.Serialize(new { pagecount = pager.PageCount, selectsucai = List });//将对象序列化成JSON字符串。匿名类。向浏览器返回多个JSON对象。 

            //string jsonname = "xcxsucai";
            //string json = JsonHelper.ListToJson<XCXSucai>(List, jsonname);
            return Content(json);

        }

        public ActionResult GetSelectedTuwenXCXSucaiList(int? page, int pid)
        {


            Pager pager = new Pager();
            pager.table = "XCXSucaiSelected";
            pager.strwhere = "(SucaiType='tuwen') and Zixunshi=" + pid + " and Status=1";
            pager.PageSize = 2;
            pager.PageNo = page ?? 1;
            pager.FieldKey = "Id";
            pager.FiledOrder = "UpdateTime desc";


            pager = CommonDal.GetPager(pager);
            IList<XCXSucaiSelected> List = DataConvertHelper<XCXSucaiSelected>.ConvertToModel(pager.EntityDataTable);

            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            string json = js.Serialize(new { pagecount = pager.PageCount, selectsucai = List });//将对象序列化成JSON字符串。匿名类。向浏览器返回多个JSON对象。 

            //string jsonname = "xcxsucai";
            //string json = JsonHelper.ListToJson<XCXSucai>(List, jsonname);
            return Content(json);

        }

        public ActionResult OnLogin(string js_code)
        {
            string json=string.Empty;
            //这几个值都应该从数据库中获取。
            string  appid = "wxee5a6a13000ac564";
            string secret = "e52e4925d508339ca6c2d76a5262032a";
            string grant_type="authorization_code";


            json = XiaochengxuAPI.GetOpenidByWxlogin(appid, secret, js_code, grant_type);

            return Content(json);  

        }


        public ActionResult GetTopSelectedXCXSucaiList(int pid,int size,string type)
        {
            string sql = string.Empty;
            sql = "select Top "+size+" * from XCXSucaiSelected where Zixunshi=" + pid + " and Status=1 and SucaiType='"+type+"'";
            IList<XCXSucaiSelected> List = unitOfWork.xcxSucaiSelectedsRepository.GetWithRawSql(sql) as IList<XCXSucaiSelected>;

            string jsonname = "xcxsucai";

            string json = JsonHelper.ListToJson(List, jsonname);
            return Content(json);

        }



        public ActionResult GetFensiUserByopenid(string openid,int pid)
        {
            FensiUser user = new FensiUser();
            var users = unitOfWork.fensiUsersRepository.Get(filter: u => u.openid == openid && u.Zixunshi==pid);
            if (users.Count() > 0)
            {
                Message msg = new Message();
                msg.MessageInfo = "have user";
                msg.MessageStatus = "true";
                msg.MessageUrl = "";
                user = users.First();
                System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
                string json = js.Serialize(new { openid = openid, userinfo = user,message=msg });
                return Content(json);
            }
            else
            {
                Message msg = new Message();
                msg.MessageInfo = "have no user";
                msg.MessageStatus = "false";
                msg.MessageUrl = "";
                System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
                string json = js.Serialize(new { openid = openid, message = msg });
                return Content(json);
 
            }
            

        }


        //public ActionResult CreateFensiUser(string openid, int pid,object userinfo)
        //{
        //    XCXUserInfo xcxuserinfo = userinfo as XCXUserInfo;
        //    FensiUser user = new FensiUser();
        //    user.openid = openid;
        //    user.Zixunshi = pid;
        //    user.nickName = xcxuserinfo.nickName;
        //    user.avatarUrl = xcxuserinfo.avatarUrl;
        //    user.country = xcxuserinfo.country;
        //    user.province = xcxuserinfo.province;
        //    user.city = xcxuserinfo.city;
        //    user.language = xcxuserinfo.language;
        //    user.gender = xcxuserinfo.gender;
        //    user.CreateTime = DateTime.Now;
        //    user.FensiTelephone="";
        //    user.FensiStatus=true;
        //    unitOfWork.fensiUsersRepository.Insert(user);
        //    unitOfWork.Save();
        //    string json = JsonHelper.JsonSerializerBySingleData(user);
        //    return Content(json);

        //}

        public ActionResult CreateFensiUser(string openid, int pid,string userinfo)
        {

            XCXUserInfo xcxuserinfo =new XCXUserInfo();
            xcxuserinfo = JsonTools.JsonToObject(userinfo, xcxuserinfo) as XCXUserInfo;


            FensiUser user = new FensiUser();
            user.openid = openid;
            user.Zixunshi = pid;
            user.nickName = xcxuserinfo.nickName;
            user.avatarUrl = xcxuserinfo.avatarUrl;
            user.country = xcxuserinfo.country;
            user.province = xcxuserinfo.province;
            user.city = xcxuserinfo.city;
            user.language = xcxuserinfo.language;
            user.gender = xcxuserinfo.gender;
            user.CreateTime = DateTime.Now;
            user.FensiTelephone = "";
            user.FensiStatus = true;
            unitOfWork.fensiUsersRepository.Insert(user);
            unitOfWork.Save();
            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            string json = js.Serialize(new { openid = openid, datamsg = xcxuserinfo, pid = pid });
            return Content(json);

        }

        public ActionResult CreateZiyoushuxieReply(int fid, int pid, string ReplyContent)
        {
            ZiyoushuxieReply ziyoushuxie = new ZiyoushuxieReply();

            ziyoushuxie.FensiUser = fid;
            ziyoushuxie.PsyUser = pid;
            ziyoushuxie.ReplyContent = ReplyContent;
            ziyoushuxie.CreateTime = DateTime.Now;
            unitOfWork.ziyoushuxieReplyRepository.Insert(ziyoushuxie);
            unitOfWork.Save();
            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            string json = js.Serialize(new { fensiuser = fid, ziyoushuxie = ziyoushuxie, psyuser = pid });
            return Content(json);

        }

        public ActionResult CreateZixunReply(int fid, int pid, string ReplyContent)
        {
            ZixunReply zixunReply = new ZixunReply();

            zixunReply.FensiUser = fid;
            zixunReply.PsyUser = pid;
            zixunReply.ReplyContent = ReplyContent;
            zixunReply.CreateTime = DateTime.Now;
            unitOfWork.zixunReplyRepository.Insert(zixunReply);
            unitOfWork.Save();
            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            string json = js.Serialize(new { fensiuser = fid, zixunReply = zixunReply, psyuser = pid });
            return Content(json);

        }


        public ActionResult hudongset(int pid)
        {
            
            var hudongs = unitOfWork.hudongSettingRepository.Get(filter:u => u.PsyUser==pid);
            if (hudongs.Count() > 0)
            {
                HudongSetting hudong = new HudongSetting();
                hudong = hudongs.First();
                string json = JsonHelper.JsonSerializerBySingleData(hudong);
                return Content(json);
            }
            else
            {
                DefaultHudongSetting hudong = new DefaultHudongSetting();
                var defaluthudongsets = unitOfWork.defalutHudongSettingRepository.Get();
                hudong = defaluthudongsets.First();
                string json = JsonHelper.JsonSerializerBySingleData(hudong);
                return Content(json);
            }

        }

        public ActionResult GetZiyoushuxieCount(int pid,int fid)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            int ZiyoushuxieCount = 0;
            var Ziyoushuxie = unitOfWork.ziyoushuxieReplyRepository.Get(filter:u =>u.PsyUser==pid && u.FensiUser==fid);
            ZiyoushuxieCount = Ziyoushuxie.Count();
            string json = JsonHelper.JsonSerializerBySingleData(ZiyoushuxieCount);
            return Content(json);
        }
        public ActionResult GetZixunCount(int pid,int fid)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            int ZixunCount = 0;
            var Zixuns = unitOfWork.zixunReplyRepository.Get(filter: u => u.PsyUser == pid && u.FensiUser == fid);
            ZixunCount = Zixuns.Count();
            string json = JsonHelper.JsonSerializerBySingleData(ZixunCount);
            return Content(json);
        }
        public ActionResult GetQuestionReplyCount(int pid,int fid)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            int QuestionCount = 0;
            var questions = unitOfWork.questionReplyRepository.Get(filter: u => u.PsyUser == pid && u.FensiUser == fid);
            QuestionCount = questions.Count();
          //  string json = JsonHelper.JsonSerializerBySingleData(QuestionCount);
            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            string json = js.Serialize(new { pagecount = QuestionCount });
            return Content(json);
        }


        public ActionResult GetZiyouList(int? page,int pid, int fid)
        {
            Pager pager = new Pager();
            pager.table = "ZiyoushuxieReply";
            pager.strwhere = "PsyUser=" + pid + " and FensiUser="+fid;
            pager.PageSize = 2;
            pager.PageNo = page ?? 1;
            pager.FieldKey = "Id";
            pager.FiledOrder = "Id desc";


            pager = CommonDal.GetPager(pager);
            IList<ZiyoushuxieReply> List = DataConvertHelper<ZiyoushuxieReply>.ConvertToModel(pager.EntityDataTable);

            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            string json = js.Serialize(new { pagecount = pager.PageCount, ziyoulist = List });//将对象序列化成JSON字符串。匿名类。向浏览器返回多个JSON对象。 

            return Content(json);

        }

        public ActionResult GetZixunList(int? page, int pid, int fid)
        {
            Pager pager = new Pager();
            pager.table = "ZixunReply";
            pager.strwhere = "PsyUser=" + pid + " and FensiUser=" + fid;
            pager.PageSize = 2;
            pager.PageNo = page ?? 1;
            pager.FieldKey = "Id";
            pager.FiledOrder = "Id desc";


            pager = CommonDal.GetPager(pager);
            IList<ZixunReply> List = DataConvertHelper<ZixunReply>.ConvertToModel(pager.EntityDataTable);

            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            string json = js.Serialize(new { pagecount = pager.PageCount, ziyoulist = List });//将对象序列化成JSON字符串。匿名类。向浏览器返回多个JSON对象。 

            return Content(json);

        }

        public ActionResult GetQuestionReplyList(int? page, int pid, int fid)
        {
            Pager pager = new Pager();
            pager.table = "QuestionReply";
            pager.strwhere = "PsyUser=" + pid + " and FensiUser=" + fid;
            pager.PageSize = 2;
            pager.PageNo = page ?? 1;
            pager.FieldKey = "Id";
            pager.FiledOrder = "Id desc";


            pager = CommonDal.GetPager(pager);
            IList<QuestionReply> List = DataConvertHelper<QuestionReply>.ConvertToModel(pager.EntityDataTable);

            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            string json = js.Serialize(new { pagecount = pager.PageCount, ziyoulist = List });//将对象序列化成JSON字符串。匿名类。向浏览器返回多个JSON对象。 

            return Content(json);

        }




       
	}
}