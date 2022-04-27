using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MSITTeam1.Models;
using MSITTeam1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSITTeam1.ViewComponent
{
    [Microsoft.AspNetCore.Mvc.ViewComponent]
    public class SPointRecordViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly helloContext hello;
        public SPointRecordViewComponent(helloContext _hello)
        {
            hello = _hello;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.Name = CDictionary.username;
            ViewBag.Type = CDictionary.memtype;
            ViewBag.account = CDictionary.account;
            IEnumerable<TStudentPoint> datas = null;
            datas = hello.TStudentPoints.Where(p => p.MemberId == CDictionary.account);
            List<SPointRecordViewModel> list = new List<SPointRecordViewModel>();
           foreach(TStudentPoint t in datas)
            {
                list.Add(new SPointRecordViewModel { stPoint = t });
            }
            return View(list);
        }
    }
}
