using Microsoft.AspNetCore.Http;
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
                var citylist = from c in hello.TCityContrasts select c.FCityName;
                var districtlist = from c in hello.TCityContrasts select c.FDistrictName;
                ViewBag.City = new SelectList(citylist, "fPostCode", "fCityName",company.FDistrictCode);
                ViewBag.District = new SelectList(districtlist, "fPostCode", "fDistrictName",company.FDistrictCode);
                if (company != null) 
                {
                    ViewBag.picture = company.FLogo;
                    return View(new CCompanyBasicViewModel() { com = company });
                }
            }
            return View(Url.Content("~/CMemberCenter/Index"));
        }
    }
}
