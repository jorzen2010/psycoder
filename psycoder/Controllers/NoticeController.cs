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
    public class NoticeController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        // GET: /Notice/
        public ActionResult Index(int? page)
        {

            Pager pager = new Pager();
            pager.table = "Notice";
            pager.strwhere = "1=1";
            pager.PageSize = 2;
            pager.PageNo = page ?? 1;
            pager.FieldKey = "Id";
            pager.FiledOrder = "Id desc";

            pager = CommonDal.GetPager(pager);
            IList<Notice> dataList = DataConvertHelper<Notice>.ConvertToModel(pager.EntityDataTable);
            var PageList = new StaticPagedList<Notice>(dataList, pager.PageNo, pager.PageSize, pager.Amount);
            return View(PageList);
        }
        public ActionResult NoticeView(int id)
        {

            Notice notice = unitOfWork.noticesRepository.GetByID(id);

            if (notice == null)
            {
                return HttpNotFound();
            }
            return View(notice);
        }
	}
}