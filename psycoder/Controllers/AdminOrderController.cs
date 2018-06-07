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
    public class AdminOrderController : AdminBaseController
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        // GET: /Notice/
        public ActionResult OrderList(int? page)
        {

            Pager pager = new Pager();
            pager.table = "Orders";
            pager.strwhere = "1=1";
            pager.PageSize = 20;
            pager.PageNo = page ?? 1;
            pager.FieldKey = "Id";
            pager.FiledOrder = "Id desc";

            pager = CommonDal.GetPager(pager);
            IList<FensiOrders> dataList = DataConvertHelper<FensiOrders>.ConvertToModel(pager.EntityDataTable);
            var PageList = new StaticPagedList<FensiOrders>(dataList, pager.PageNo, pager.PageSize, pager.Amount);
            return View(PageList);

        }

        public ActionResult PsyOrderList(int? page)
        {
            Pager pager = new Pager();
            pager.table = "PsyOrders";
            pager.strwhere = "1=1";
            pager.PageSize = 20;
            pager.PageNo = page ?? 1;
            pager.FieldKey = "Id";
            pager.FiledOrder = "Id desc";

            pager = CommonDal.GetPager(pager);
            IList<PsyOrders> dataList = DataConvertHelper<PsyOrders>.ConvertToModel(pager.EntityDataTable);
            var PageList = new StaticPagedList<PsyOrders>(dataList, pager.PageNo, pager.PageSize, pager.Amount);
            return View(PageList);
        }
        public ActionResult CreatePsyOrder(int pid) 
        {

            return View();      
        }
        [HttpPost]
        public ActionResult CreatePsyOrder(PsyOrders orders) 
        {
            unitOfWork.psyOrdersRepository.Insert(orders);
            unitOfWork.Save();
            return RedirectToAction("OrderList","AdminOrder");


        }

        public ActionResult CreateFensiOrder(int pid)
        {
            FensiOrders order = new FensiOrders();

            order.Product = 0;
            order.Seller = 0;
            order.Customer = pid;
            order.CreateTime = DateTime.Now;
            order.ExpiryTime = DateTime.Now.AddYears(1).AddMonths(1);
            order.Status = "未付款";
            order.Beizhu = "粉丝申请创建";
            unitOfWork.fensiOrdersRepository.Insert(order);
            unitOfWork.Save();
            return RedirectToAction("OrderList", "AdminOrder");


        }
	}
}