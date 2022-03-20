using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSITTeam1.Models;
using MSITTeam1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSITTeam1.ViewComponent
{
    [Microsoft.AspNetCore.Mvc.ViewComponent]
    public class CompanyBasicViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly helloContext hello;

        public CompanyBasicViewComponent(helloContext _hello)
        {
            hello = _hello;
        }
        public IViewComponentResult Invoke()
        {
            string account = HttpContext.Session.GetString(CDictionary.SK_LOGINED_USER_ACCOUNT);
            ViewBag.Account = account;
            IEnumerable<TCompanyBasic> com = null;
            com = hello.TCompanyBasics.Where(t => t.FAccount == account);
            List<CCompanyBasicViewModel> list = new List<CCompanyBasicViewModel>();
            foreach (TCompanyBasic t in com)
            {
                list.Add(new CCompanyBasicViewModel() { com = t });
            }
            ViewBag.Name = CDictionary.username;
            return View(list);
        }
    }
}
