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
    public class CPointRecordViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly helloContext hello;
        public CPointRecordViewComponent(helloContext _hello)
        {
            hello = _hello;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.Name = CDictionary.username;
            ViewBag.Type = CDictionary.memtype;
            ViewBag.account = CDictionary.account;
            ViewBag.Title = hello.TMemberLevels.FirstOrDefault(c => c.FLevel == hello.TCompanyBasics.FirstOrDefault(c => c.CompanyTaxid == CDictionary.account).FLevel).Title;
            var datas = (from b in hello.TCompanyPoints
                         join o in hello.TCompanyBasics on b.CompanyTaxid equals o.CompanyTaxid
                         join q in hello.TMemberLevels on o.FLevel equals q.FLevel
                         where b.CompanyTaxid == CDictionary.account
                         select new CPointRecordViewModel
                         {
                             pointUsageId = b.PointUsageId,
                             PointDate = b.PointDate,
                             PointType = b.PointType,
                             PointDes = b.PointDescription,
                             PointRecord = b.PointRecord,
                             OrderId = b.OrderId,
                         }).ToList();
                 return View(datas);
            }
           // return Content("沒東西");
            //return new HtmlContentViewComponentResult(new HtmlString("<tbody>< tr>< th ></ th >< td colspan='4'></ td ></ tr ></ tbody >"));
         
        }
    }
