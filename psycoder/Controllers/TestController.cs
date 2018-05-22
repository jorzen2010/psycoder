using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using Common;
using psycoderDal;
using psycoderEntity;

namespace psycoder.Controllers
{
    public class TestController : Controller
    {

        public ActionResult Test(int? page, string qrname)
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
            string jsonname = "testname";
            string json = JsonHelper.ListToJson<XCXSucai>(List, jsonname);
            return Content(json);

        }

        public JsonResult Test2(int? page, string qrname)
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
            string jsonname = "testname";
            string json = JsonHelper.ListToJson<XCXSucai>(List, jsonname);
            return Json(json, JsonRequestBehavior.AllowGet);


        }
    }
}

