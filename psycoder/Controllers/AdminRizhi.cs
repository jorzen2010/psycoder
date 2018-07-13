using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using psycoderDal;
using psycoderEntity;
using Common;

namespace psycoder.Controllers
{
    public class AdminRizhiController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        // GET: /Notice/
        public ActionResult JksucaiChakanTongji(int? page)
        {

            Pager pager = new Pager();
            pager.table = "JksucaiChakanTongji";
            pager.strwhere = "1=1";
            pager.PageSize = 20;
            pager.PageNo = page ?? 1;
            pager.FieldKey = "Id";
            pager.FiledOrder = "Id desc";

            pager = CommonDal.GetPager(pager);
            IList<JksucaiChakanTongji> dataList = DataConvertHelper<JksucaiChakanTongji>.ConvertToModel(pager.EntityDataTable);
            var PageList = new StaticPagedList<JksucaiChakanTongji>(dataList, pager.PageNo, pager.PageSize, pager.Amount);
            return View(PageList);
        }

        public ActionResult JksucaiShoucangTongji(int? page)
        {

            Pager pager = new Pager();
            pager.table = "JksucaiShoucangTongji";
            pager.strwhere = "1=1";
            pager.PageSize = 20;
            pager.PageNo = page ?? 1;
            pager.FieldKey = "Id";
            pager.FiledOrder = "Id desc";

            pager = CommonDal.GetPager(pager);
            IList<JksucaiShoucangTongji> dataList = DataConvertHelper<JksucaiShoucangTongji>.ConvertToModel(pager.EntityDataTable);
            var PageList = new StaticPagedList<JksucaiShoucangTongji>(dataList, pager.PageNo, pager.PageSize, pager.Amount);
            return View(PageList);
        }

        public ActionResult JksucaiXihuanTongji(int? page)
        {

            Pager pager = new Pager();
            pager.table = "JksucaiXihuanTongji";
            pager.strwhere = "1=1";
            pager.PageSize = 20;
            pager.PageNo = page ?? 1;
            pager.FieldKey = "Id";
            pager.FiledOrder = "Id desc";

            pager = CommonDal.GetPager(pager);
            IList<JksucaiXihuanTongji> dataList = DataConvertHelper<JksucaiXihuanTongji>.ConvertToModel(pager.EntityDataTable);
            var PageList = new StaticPagedList<JksucaiXihuanTongji>(dataList, pager.PageNo, pager.PageSize, pager.Amount);
            return View(PageList);
        }

        public ActionResult JksucaiXiazaiTongji(int? page)
        {

            Pager pager = new Pager();
            pager.table = "JksucaiXiazaiTongji";
            pager.strwhere = "1=1";
            pager.PageSize = 20;
            pager.PageNo = page ?? 1;
            pager.FieldKey = "Id";
            pager.FiledOrder = "Id desc";

            pager = CommonDal.GetPager(pager);
            IList<JksucaiXiazaiTongji> dataList = DataConvertHelper<JksucaiXiazaiTongji>.ConvertToModel(pager.EntityDataTable);
            var PageList = new StaticPagedList<JksucaiXiazaiTongji>(dataList, pager.PageNo, pager.PageSize, pager.Amount);
            return View(PageList);
        }
       
	}
}