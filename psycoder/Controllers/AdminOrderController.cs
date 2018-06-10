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
        public ActionResult FensiOrderList(int? page)
        {

            Pager pager = new Pager();
            pager.table = "FensiOrders";
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
            ViewBag.pid = pid;
            return View();      
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult CreatePsyOrder(PsyOrders orders) 
        {
            if (ModelState.IsValid)
            {
                unitOfWork.psyOrdersRepository.Insert(orders);
                unitOfWork.Save();
                return RedirectToAction("PsyOrderList", "AdminOrder");
            }
            return View(orders);


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
            return RedirectToAction("FensiOrderList", "AdminOrder");


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult UpdateOrderStatus(int oid, string status)
        {
            Message msg = new Message();
            string sql = "update PsyOrders set Status='" + status + "' where Id=" + oid;
            try
            {
                unitOfWork.zixunshiUsersRepository.UpdateWithRawSql(sql);
                msg.MessageStatus = "true";
                msg.MessageInfo = "更新成功";
            }
            catch (Exception ex)
            {
                msg.MessageStatus = "false";
                msg.MessageInfo = "更新失败" + ex.ToString();
            }

            return Json(msg, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PsyUserOrderList(int? page,int pid)
        {
            Pager pager = new Pager();
            pager.table = "PsyOrders";
            pager.strwhere = "Customer="+pid;
            pager.PageSize = 20;
            pager.PageNo = page ?? 1;
            pager.FieldKey = "Id";
            pager.FiledOrder = "Id desc";

            pager = CommonDal.GetPager(pager);
            IList<PsyOrders> dataList = DataConvertHelper<PsyOrders>.ConvertToModel(pager.EntityDataTable);
            var PageList = new StaticPagedList<PsyOrders>(dataList, pager.PageNo, pager.PageSize, pager.Amount);
            return View(PageList);
        }
	}
}