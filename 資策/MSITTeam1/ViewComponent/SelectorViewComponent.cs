using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MSITTeam1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSITTeam1.ViewComponent
{
    [Microsoft.AspNetCore.Mvc.ViewComponent]
    public class SelectorViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly helloContext hello;
        public SelectorViewComponent(helloContext _hello)
        {
            hello = _hello;
        }
        public IViewComponentResult Invoke(string city,string district)
        {
            ViewBag.ID = Guid.NewGuid();
            ViewBag.FCity = SetDropDown1(city);
            ViewBag.FDistrict = SetDropDown2(city, district);        
            return View();
        }
        List<SelectListItem> GetSelectItem(bool dvalue = true)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            if (dvalue) { items.Insert(0, new SelectListItem { Text = "--請選擇--", Value = "0" }); }
            return items;
        }
        private List<SelectListItem> SetDropDown1(string cityname = "")
        {
            var citylist = from c in hello.TCityContrasts group c by c.FCityName into a select a.Key;
            if (cityname == "")
            {
                List<SelectListItem> items = GetSelectItem(false);
                ViewBag.Cityname = "--請選擇--";
                items.AddRange(new SelectList(citylist));
                return items;
            }else
            {
                List<SelectListItem> items = GetSelectItem(false);
                ViewBag.Cityname = cityname;
                items.AddRange(new SelectList(citylist));
                return items;
            }
        }
        private List<SelectListItem> SetDropDown2(string cityname = "", string districtname = "")
        {
            var districtlist = from c in hello.TCityContrasts where c.FCityName == cityname select c.FDistrictName;

            List<SelectListItem> items = GetSelectItem(false);
            items.AddRange(new SelectList(districtlist, districtname));
            return items;


        }
    }
}
