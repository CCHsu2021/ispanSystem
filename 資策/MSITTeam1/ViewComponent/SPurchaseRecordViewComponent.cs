using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using MSITTeam1.Models;
using MSITTeam1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSITTeam1.ViewComponent
{
    [Microsoft.AspNetCore.Mvc.ViewComponent]
    public class SPurchaseRecordViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly helloContext hello;
        public SPurchaseRecordViewComponent(helloContext _hello)
        {
            hello = _hello;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.Name = CDictionary.username;
            ViewBag.Type = CDictionary.memtype;
            ViewBag.account = CDictionary.account;
            IEnumerable<TProductOrder> Odatas = null;
            Odatas = hello.TProductOrders.Where(p => p.MemberId == CDictionary.account);
            var OdatasD = from d in hello.TProductOrderDetails
                          join o in hello.TProductOrders on d.OrderId equals o.OrderId
                          select d;
            if (Odatas != null)
            {
                OrderAndOrderDetailViewModel list = new OrderAndOrderDetailViewModel();
                foreach (TProductOrder t in Odatas)
                {   
                    list.Order.Add(new CheckOutViewModel { order = t });
                }
                foreach (TProductOrderDetail t in OdatasD)
                {
                    list.OrderDetail.Add(new OrderDetailViewModel { orderDetail = t });
                }
                return View(list);
            }
            return Content("沒東西");
            //return new HtmlContentViewComponentResult(new HtmlString("<tbody>< tr>< th ></ th >< td colspan='4'></ td ></ tr ></ tbody >"));

        }
    }
}
