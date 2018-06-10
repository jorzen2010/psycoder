using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using psycoderDal;
using psycoderEntity;
using Common;

namespace psycoderService
{
    public class OrderService
    {

        public static string GetOrderActionById(int oid)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            PsyOrders order = unitOfWork.psyOrdersRepository.GetByID(oid);
            string ac="jinyong";
            string btnname = "操作";
            string btnstyle = "success";
            switch(order.Status)
            {
                case "未付款":
                    ac = "fukuan";
                    btnname = "付款";
                    btnstyle = "success";
                    break;
                case "已付款":
                    ac = "guoqi";
                    btnname = "设置过期";
                    btnstyle = "danger";
                    break;
                case "已过期":
                    ac = "jinyong";
                    btnname = "禁用订单";
                    btnstyle = "primary";
                    break;
                case "已禁用":
                    ac = "close";
                    btnname = "关闭订单";
                    btnstyle = "warning";
                    break;
                case "已关闭":
                    ac = "jieshu";
                    btnname = "订单已关闭";
                    btnstyle = "info";
                    break;
            }

            string html = "<a class=\"btn btn-sm btn-" + btnstyle + "\" href=\"###\" onclick=\"setorderstatus('" + ac +"','"+oid +"')\">" + btnname + "</a>";
            return html;

        }
        public static DateTime GetOrderExpiryTimeByPid(int pid)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            DateTime ExpiryTime = DateTime.Now;
            var orders = unitOfWork.psyOrdersRepository.Get(filter: u => u.Customer == pid, orderBy: q => q.OrderByDescending(u => u.Id));
            if (orders.Count() > 0)
            {
                PsyOrders order = orders.First();
                ExpiryTime = order.ExpiryTime;

            }
            else
            {
                ExpiryTime = DateTime.Parse("1996-07-21 06:06:06");
            }
            return ExpiryTime;

        }

        
    }
}
