using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System.Data;
using System.Collections;
using psycoderDal;
using psycoderEntity;
using Common;

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
            pager.PageSize = 2;
            pager.PageNo = page ?? 1;
            pager.FieldKey = "Id";
            pager.FiledOrder = "Id desc";


            pager = CommonDal.GetPager(pager);
            IList<XCXSucai> List = DataConvertHelper<XCXSucai>.ConvertToModel(pager.EntityDataTable);
            string jsonname = "xcxsucai";
            string json = JsonHelper.ListToJson<XCXSucai>(List, jsonname);
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
            string jsonname = "xcxsucai";
            string json = JsonHelper.ListToJson<XCXSucai>(List, jsonname);
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
	}
}