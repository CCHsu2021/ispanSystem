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
    public class CPurchaseRecordViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly helloContext hello;
        public CPurchaseRecordViewComponent(helloContext _hello)
        {
            hello = _hello;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.Name = CDictionary.username;
            ViewBag.Type = CDictionary.memtype;
            ViewBag.account = CDictionary.account;
            //IEnumerable<TProductOrder> Odatas = null;
            //IEnumerable<TClassOrder> Cdatas = null;
            //IEnumerable<TPointOrder> Pdatas = null;
            var Odatas = (hello.TProductOrders.Where(p => p.MemberId == CDictionary.account)).OrderByDescending(p=>p.Date).ToList();
            var Cdatas = (hello.TClassOrders.Where(p => p.MemberId == CDictionary.account)).OrderByDescending(p => p.Date).ToList();
            //var Pdatas = (hello.TPointOrders.Where(p => p.CompanyTaxid == CDictionary.account)).ToList();
            var pdatas = (from p in hello.TPointOrders
                          where p.CompanyTaxid == CDictionary.account
                          select p).OrderByDescending(p => p.OrderDate).ToList();
            var OdatasD =( from d in hello.TProductOrderDetails
                          join o in hello.TProductOrders on d.OrderId equals o.OrderId
                          select d).ToList();
            var CdatasD = (from d in hello.TClassOrderDetails
                           join o in hello.TClassOrders on d.OrderId equals o.OrderId
                           select d).ToList();
            var pro = (from p in hello.TProducts
                       join d in hello.TProductOrderDetails on p.ProductId equals d.ProductId
                       select p).OrderBy(c => c.ProductId).ToList();
            var classN = (from p in hello.TClassInfos
                       join d in hello.TClassOrderDetails on p.FClassExponent equals d.ClassExponent
                          select p).OrderBy(c => c.FClassExponent).ToList();
            if (Odatas != null|| CdatasD!=null|| pdatas != null)
            {
                OrderAndOrderDetailViewModel list = new OrderAndOrderDetailViewModel();
                List<CheckOutViewModel> temp = new List<CheckOutViewModel>();
                List<OrderDetailViewModel> tempDetail = new List<OrderDetailViewModel>();
                List<CProductViewModel> tempPro = new List<CProductViewModel>();
                List<ClassCheckOutViewModel> classTemp = new List<ClassCheckOutViewModel>();
                List<ClassOrderDetailViewModel> classTempDetail = new List<ClassOrderDetailViewModel>();
                List<CPointOrderViewModel> Ptemp = new List<CPointOrderViewModel>();
                //list.order = Odatas.ToList();
                //list.orderDetail = OdatasD.ToList();
                //若OrderAndOrderDetailViewModel裡面是包資料表可直接使用上面寫法

                foreach (TProductOrder t in Odatas)
                {
                    temp.Add(new CheckOutViewModel { order = t });
                }
                foreach (TProductOrderDetail t in OdatasD)
                {
                    tempDetail.Add(new OrderDetailViewModel { orderDetail = t });
                }
                foreach (TProduct t in pro)
                {
                    tempPro.Add(new CProductViewModel { prodcut = t });
                }
                foreach (TClassOrder t in Cdatas)
                {
                    classTemp.Add(new ClassCheckOutViewModel { classOrder = t });
                }
                foreach (TClassOrderDetail t in CdatasD)
                {
                    classTempDetail.Add(new ClassOrderDetailViewModel { classOrderDetail = t });
                }
                foreach (TPointOrder t in pdatas)
                {
                    Ptemp.Add(new CPointOrderViewModel { Porder = t });
                }
                list.order = temp;
                list.orderDetail = tempDetail;
                list.product = tempPro;
                list.classOrder = classTemp;
                list.classOrderDetail = classTempDetail;
                list.Porder = Ptemp;
                list.ClassInfo = classN.ToList();
                return View(list);

                //return new HtmlContentViewComponentResult(new HtmlString("<tbody>< tr>< th ></ th >< td colspan='4'></ td ></ tr ></ tbody >"));
            }
                return Content("沒東西");
        }
    }
}
