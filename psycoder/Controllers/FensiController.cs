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
    public class FensiController : PsyBaseController
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private int psyId = int.Parse(System.Web.HttpContext.Current.Session["pid"].ToString());
        public ActionResult FensiIndex(int? page)
        {
            Pager pager = new Pager();
            pager.table = "FensiUser";
            pager.strwhere = "Zixunshi=" + psyId;
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
            Pager pager = new Pager();
            pager.table = "FensiOrders";
            pager.strwhere = "Seller=" + psyId;
            pager.PageSize = 2;
            pager.PageNo = page ?? 1;
            pager.FieldKey = "Id";
            pager.FiledOrder = "Id desc";
            ViewBag.pid = psyId;
            pager = CommonDal.GetPager(pager);
            IList<FensiOrders> dataList = DataConvertHelper<FensiOrders>.ConvertToModel(pager.EntityDataTable);
            var PageList = new StaticPagedList<FensiOrders>(dataList, pager.PageNo, pager.PageSize, pager.Amount);
            return View(PageList);
        }

        public ActionResult OrderListByCustomer(int? page,int cid)
        {
            Pager pager = new Pager();
            pager.table = "FensiOrders";
            pager.strwhere = "Seller=" + psyId+" and Customer="+cid;
            pager.PageSize = 2;
            pager.PageNo = page ?? 1;
            pager.FieldKey = "Id";
            pager.FiledOrder = "Id desc";
            ViewBag.pid = psyId;
            pager = CommonDal.GetPager(pager);
            IList<FensiOrders> dataList = DataConvertHelper<FensiOrders>.ConvertToModel(pager.EntityDataTable);
            var PageList = new StaticPagedList<FensiOrders>(dataList, pager.PageNo, pager.PageSize, pager.Amount);
            return View(PageList);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateVIPPrice(Product product)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.productsRepository.Insert(product);
                unitOfWork.Save();
                return RedirectToAction("OrderIndex", "Fensi");
            }
            ViewBag.pid = psyId;
            ViewBag.acmethod = "CreateVIPPrice";
         //  return RedirectToAction("OrderPriceSetting", "Fensi", new { pid = product.Zixunshi });
           return View("OrderPriceSetting", product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditVIPPrice(Product product)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.productsRepository.Update(product);
                unitOfWork.Save();
                return RedirectToAction("OrderIndex", "Fensi");
            }
            ViewBag.pid = psyId;
            ViewBag.acmethod = "EditVIPPrice";
           // return RedirectToAction("OrderPriceSetting", "Fensi", new { pid = product.Zixunshi });
            return View("OrderPriceSetting", product);
        }

        public ActionResult OrderPriceSetting()
        {
            Product product = new Product();
            var products = unitOfWork.productsRepository.Get(filter: u => u.Zixunshi == psyId);
            if (products.Count() > 0)
            {
                ViewBag.acmethod = "EditVIPPrice";
                ViewBag.pid = psyId;
                product = products.First();
                return View(product);
            }
            else
            {
                ViewBag.acmethod = "CreateVIPPrice";
                ViewBag.pid = psyId;
                return View();
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OrderPriceSetting(Product product)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.productsRepository.Insert(product);
                unitOfWork.Save();
                return RedirectToAction("OrderIndex", "Fensi");
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult UpdateOrderStatus(int oid, string status)
        {
            Message msg = new Message();
            string sql = "update FensiOrders set Status='" + status + "' where Id=" + oid;
            try
            {
                unitOfWork.fensiOrdersRepository.UpdateWithRawSql(sql);
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


    }
}