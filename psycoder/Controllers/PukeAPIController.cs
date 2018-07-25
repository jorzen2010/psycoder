using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Text;
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
using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Dysmsapi.Model.V20170525;
using AliyunMsg;

namespace psycoder.Controllers
{
    public class PukeAPIController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        public ActionResult WechatLogin(string appid,string appsecrect, string js_code)
        {
            string json = string.Empty;
            string grant_type = "authorization_code";
            json = XiaochengxuAPI.GetOpenidByWxlogin(appid, appsecrect, js_code, grant_type);
            return Content(json);

        }

        public ActionResult GetFensiUserByopenid(string openid)
        {
            CeshiFensiUser user = new CeshiFensiUser();
            var users = unitOfWork.ceshiFensiUsersRepository.Get(filter: u => u.openid == openid);
            if (users.Count() > 0)
            {
                Message msg = new Message();
                msg.MessageInfo = "have user";
                msg.MessageStatus = "true";
                msg.MessageUrl = "";
                user = users.First();
                System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
                string json = js.Serialize(new { openid = openid, userinfo = user, message = msg });
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

        public ActionResult CreateFensiUser(string openid, int shareuser, string userinfo)
        {

            XCXUserInfo xcxuserinfo = new XCXUserInfo();
            xcxuserinfo = JsonTools.JsonToObject(userinfo, xcxuserinfo) as XCXUserInfo;


            CeshiFensiUser user = new CeshiFensiUser();
            user.openid = openid;
            user.SharePerson = shareuser;
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
            unitOfWork.ceshiFensiUsersRepository.Insert(user);
            unitOfWork.Save();
            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            string json = js.Serialize(new { CeshiFensiUser = user });
            return Content(json);

        }

        public ActionResult CreateResult(int uid, string rid)
        {
            CeshiResult result = new CeshiResult();
            result.ceshiUser = uid;
            result.result = rid;
            result.CreateTime = DateTime.Now;
            unitOfWork.ceshiResultsRepository.Insert(result);
            unitOfWork.Save();

            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            string json = js.Serialize(new { CeshiResult = result });
            return Content(json);
 
        }

        public ActionResult GetPaihang(string type)
        {
            StringBuilder sql = new StringBuilder();
            if (type == "nuli")
            {
                
                sql.Append(" SELECT top(10) CeshiResult.ceshiuser,COUNT(CeshiResult.Id) as paihang,CeshiFensiUser.nickName,CeshiFensiUser.avatarUrl ");
                sql.Append(" from CeshiResult "); 
                sql.Append(" left join CeshiFensiUser on(CeshiResult.ceshiUser=CeshiFensiUser.Id) ");
                sql.Append(" where CeshiResult.ceshiuser>0 ");
                sql.Append(" group by CeshiResult.ceshiUser ,CeshiFensiUser.nickName,CeshiFensiUser.avatarUrl ");
                sql.Append(" order by paihang desc ");
            }
            else if (type == "shili")
            {

                sql.Append(" SELECT top(10) CeshiResult.ceshiuser,COUNT(distinct CeshiResult.result) as paihang,CeshiFensiUser.nickName,CeshiFensiUser.avatarUrl ");
                sql.Append(" from CeshiResult ");
                sql.Append(" left join CeshiFensiUser on(CeshiResult.ceshiUser=CeshiFensiUser.Id) ");
                sql.Append(" where CeshiResult.ceshiuser>0 ");
                sql.Append(" group by CeshiResult.ceshiUser ,CeshiFensiUser.nickName,CeshiFensiUser.avatarUrl ");
                sql.Append(" order by paihang desc ");
            }

            else if (type == "yunqi")
            {
                sql.Append(" SELECT top(10) CeshiResult.ceshiuser,round((convert(float,COUNT(distinct CeshiResult.result))/convert(float,COUNT(CeshiResult.Id)))*100,0) as paihang,CeshiFensiUser.nickName,CeshiFensiUser.avatarUrl ");
                sql.Append(" from CeshiResult ");
                sql.Append(" left join CeshiFensiUser on(CeshiResult.ceshiUser=CeshiFensiUser.Id) ");
                sql.Append(" where CeshiResult.ceshiuser>0 ");
                sql.Append(" group by CeshiResult.ceshiUser ,CeshiFensiUser.nickName,CeshiFensiUser.avatarUrl ");
                sql.Append(" order by paihang desc ");
            }
            else if (string.IsNullOrEmpty(type))
            {
                sql.Append(" SELECT top(10) CeshiResult.ceshiuser,COUNT(CeshiResult.Id) as paihang,CeshiFensiUser.nickName,CeshiFensiUser.avatarUrl ");
                sql.Append(" from CeshiResult ");
                sql.Append(" left join CeshiFensiUser on(CeshiResult.ceshiUser=CeshiFensiUser.Id) ");
                sql.Append(" where CeshiResult.ceshiuser>0 ");
                sql.Append(" group by CeshiResult.ceshiUser ,CeshiFensiUser.nickName,CeshiFensiUser.avatarUrl ");
                sql.Append(" order by paihang desc ");
 
            }

            DataTable dt = CommonDal.GetSomeBySql(sql.ToString());

            IList<paihangbang> List = DataConvertHelper<paihangbang>.ConvertToModel(dt);

            string jsonname = "paihang";

            string json = JsonHelper.ListToJson(List, jsonname);
            return Content(json);

        }

         public ActionResult GetZhanji(string ceshiuser)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT CeshiResult.ceshiuser,round((convert(float,COUNT(distinct CeshiResult.result))/convert(float,COUNT(CeshiResult.Id)))*100,0) as yunqi,COUNT(CeshiResult.Id) as nuli,COUNT(distinct CeshiResult.result) as shili,CeshiFensiUser.nickName,CeshiFensiUser.avatarUrl ");
            sql.Append(" from CeshiResult ");
            sql.Append(" left join CeshiFensiUser on(CeshiResult.ceshiUser=CeshiFensiUser.Id) ");
            sql.Append(" where CeshiResult.ceshiuser=" + ceshiuser);
            sql.Append(" group by CeshiResult.ceshiUser ,CeshiFensiUser.nickName,CeshiFensiUser.avatarUrl ");
            sql.Append(" order by shili desc ");

            DataTable dt = CommonDal.GetSomeBySql(sql.ToString());

            IList<zhanji> List = DataConvertHelper<zhanji>.ConvertToModel(dt);
            zhanji zj = List[0];

            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            string json = js.Serialize(new { zhanji = zj });
            return Content(json);
         }



	}





    public class paihangbang
    {
        public int ceshiuser { get; set; }
        public Double paihang { get; set; }
        public string nickName { get; set; }
        public string avatarUrl { get; set; }
    }

    public class zhanji
    {
        public int ceshiuser { get; set; }
        public Double nuli { get; set; }
        public Double shili { get; set; }
        public Double yunqi { get; set; }
        public string nickName { get; set; }
        public string avatarUrl { get; set; }
    }

}