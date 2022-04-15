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

        List<SelectListItem> GetSelectItem(bool dvalue = true)
        {
            List <SelectListItem> items = new List<SelectListItem> ();
            if (dvalue) { items.Insert(0, new SelectListItem { Text = "--請選擇--", Value = "0" }); }
            return items;
        }
        private List<SelectListItem> SetDropDown1(string cityname)
        {
            List <SelectListItem> items = GetSelectItem(false);
            var citylist = from c in hello.TCityContrasts group c by c.FCityName into a select a.Key;
            items.AddRange(new SelectList(citylist,cityname));
            return items;
        }
        private List<SelectListItem> SetDropDown2(string cityname,string districtname)
        {
            List <SelectListItem> items = GetSelectItem(false);
            var districtlist = from c in hello.TCityContrasts where c.FCityName == cityname select c.FDistrictName;
            items.AddRange(new SelectList(districtlist,districtname));
            return items;
        }
        public IViewComponentResult Invoke(string id) 
        {
            if (!string.IsNullOrEmpty(id))
            {
                var company = hello.TCompanyBasics.FirstOrDefault(p => p.CompanyTaxid == id);
                //var citylist = from c in hello.TCityContrasts group c by c.FCityName into a select a.Key;
                //var districtlist = from c in hello.TCityContrasts select c.FDistrictName;
                ViewBag.City = SetDropDown1(company.FCity);
                ViewBag.District = SetDropDown2(company.FCity,company.FDistrict);
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
