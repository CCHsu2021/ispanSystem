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
    public class CompanyBasicEditViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly helloContext hello;
        public CompanyBasicEditViewComponent(helloContext _hello)
        {
            hello = _hello;
        }
        
        public IViewComponentResult Invoke(string id) 
        {
            if (!string.IsNullOrEmpty(id))
            {
                var company = hello.TCompanyBasics.FirstOrDefault(p => p.CompanyTaxid == id);
                if (company != null)
                    return View(new CCompanyBasicViewModel() { com = company });
            }
            return View(Url.Content("~/CMemberCenter/Index"));
        }
    }
}
