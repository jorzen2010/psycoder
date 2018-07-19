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
using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Dysmsapi.Model.V20170525;
using AliyunMsg;

namespace psycoder.Controllers
{
    public class SucaiAPIController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        public ActionResult GetJkSucaiById(int sid)
        {
            JkSucai sucai = new JkSucai();
            sucai = unitOfWork.jkSucaiRepository.GetByID(sid);
            string tag=string.Empty;
            string[] sArray=sucai.Tags.Split(',');
            sucai.Tags = sArray[0].ToString();
            //把category作为tags使用也可以，。
            string json = JsonHelper.JsonSerializerBySingleData(sucai);
            return Content(json);
        }

        public ActionResult GetJkSucaiByIdTags(int sid)
        {
            JkSucai sucai = new JkSucai();
            sucai = unitOfWork.jkSucaiRepository.GetByID(sid);
            sucai.Tags = unitOfWork.categorysRepository.GetByID(sucai.Category).CategoryName.ToString();
            string json = JsonHelper.JsonSerializerBySingleData(sucai);
            return Content(json);
        }

        public ActionResult GetJKSucaiList(int? page)
        {

            Pager pager = new Pager();
            pager.table = "JKSucai";
            pager.strwhere = "1=1";
            pager.PageSize = 2;
            pager.PageNo = page ?? 1;
            pager.FieldKey = "Id";
            pager.FiledOrder = "Id desc";

            pager = CommonDal.GetPager(pager);
            IList<JkSucai> List = DataConvertHelper<JkSucai>.ConvertToModel(pager.EntityDataTable);

            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            string json = js.Serialize(new { pagecount = pager.PageCount, jksucai = List });//将对象序列化成JSON字符串。匿名类。向浏览器返回多个JSON对象。 

            return Content(json);

        }


        public ActionResult GetJKSucaiListTags(int? page,string keys)
        {

            Pager pager = new Pager();
            pager.table = "JKSucai";
            pager.strwhere = "CONTAINS(Tags,'"+keys+"')";
            pager.PageSize = 2;
            pager.PageNo = page ?? 1;
            pager.FieldKey = "Id";
            pager.FiledOrder = "Id desc";

            pager = CommonDal.GetPager(pager);
            IList<JkSucai> List = DataConvertHelper<JkSucai>.ConvertToModel(pager.EntityDataTable);

            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            string json = js.Serialize(new { pagecount = pager.PageCount, jksucai = List });//将对象序列化成JSON字符串。匿名类。向浏览器返回多个JSON对象。 

            return Content(json);

        }

        public ActionResult GetJKSucaiListByCate(int? page,int cate)
        {

            Pager pager = new Pager();
            pager.table = "JKSucai";
            if (cate == 0)
            {
                pager.strwhere = "1=1";
            }
            else
            {
                pager.strwhere = "Category=" + cate + "";
            }
            pager.PageSize = 2;
            pager.PageNo = page ?? 1;
            pager.FieldKey = "Id";
            pager.FiledOrder = "Id desc";

            pager = CommonDal.GetPager(pager);
            IList<JkSucai> List = DataConvertHelper<JkSucai>.ConvertToModel(pager.EntityDataTable);

            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            string json = js.Serialize(new { pagecount = pager.PageCount, jksucai = List });//将对象序列化成JSON字符串。匿名类。向浏览器返回多个JSON对象。 

            return Content(json);

        }

        
       
	}
}