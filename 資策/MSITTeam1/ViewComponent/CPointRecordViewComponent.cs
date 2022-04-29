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
            TCompanyBasic cb = new TCompanyBasic();
            TCompanyPoint datas = hello.TCompanyPoints.FirstOrDefault(p => p.CompanyTaxid == CDictionary.account);
            TMemberLevel title = hello.TMemberLevels.FirstOrDefault(t => t.FLevel == cb.FLevel);
            if (datas != null)
            {
                List<CPointRecordViewModel> list = new List<CPointRecordViewModel>();
                CPointRecordViewModel item = new CPointRecordViewModel()
                {
                    pointUsageId = datas.PointUsageId,
                    PointDate = datas.PointDate,
                    PointType = datas.PointType,
                    PointDes = datas.PointDescription,
                    PointRecord = datas.PointRecord,
                    TitleName = title.Title
                };
                list.Add(item);
                ViewBag.title = title.Title;
                return View(list);
            }
            return Content("沒東西");
            //return new HtmlContentViewComponentResult(new HtmlString("<tbody>< tr>< th ></ th >< td colspan='4'></ td ></ tr ></ tbody >"));
         
        }
    }
}
