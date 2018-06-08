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
    public class FensiController : Controller
    {
        public ActionResult FensiIndex(int? page)
        {
            int PsyId = 1;
            Pager pager = new Pager();
            pager.table = "FensiUser";
            pager.strwhere = "Zixunshi="+PsyId;
            pager.PageSize = 2;
            pager.PageNo = page ?? 1;
            pager.FieldKey = "Id";
            pager.FiledOrder = "Id desc";

            pager = CommonDal.GetPager(pager);
            IList<FensiUser> dataList = DataConvertHelper<FensiUser>.ConvertToModel(pager.EntityDataTable);
            var PageList = new StaticPagedList<FensiUser>(dataList, pager.PageNo, pager.PageSize, pager.Amount);
            return View(PageList);
        }

        public ActionResult OrderIndex(int? page)
        {
            int PsyId = 1;
            Pager pager = new Pager();
            pager.table = "FensiOrders";
            pager.strwhere = "Seller=" + PsyId;
            pager.PageSize = 2;
            pager.PageNo = page ?? 1;
            pager.FieldKey = "Id";
            pager.FiledOrder = "Id desc";

            pager = CommonDal.GetPager(pager);
            IList<FensiOrders> dataList = DataConvertHelper<FensiOrders>.ConvertToModel(pager.EntityDataTable);
            var PageList = new StaticPagedList<FensiOrders>(dataList, pager.PageNo, pager.PageSize, pager.Amount);
            return View(PageList);
        }

        public ActionResult OrderPriceSetting()
        {
            return View();
        }
	}
}