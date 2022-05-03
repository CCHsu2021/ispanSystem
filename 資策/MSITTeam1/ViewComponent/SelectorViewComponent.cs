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
                List<SelectListItem> items = GetSelectItem(true);
                foreach(var i in citylist)
                {
                    items.Add(new SelectListItem
                    {
                        Text = i,
                        Value = i
                    });
                }
                return items;
            }else
            {
                List<SelectListItem> items = GetSelectItem(false);
                
                foreach (var i in citylist)
                {
                    items.Add(new SelectListItem
                    {
                        Text = i,
                        Value = i
                    });
                }
                items.Where(p => p.Value == cityname).First().Selected = true;
                return items;
            }
        }
        private List<SelectListItem> SetDropDown2(string cityname = "", string districtname = "")
        {
            var districtlist = from c in hello.TCityContrasts where c.FCityName == cityname select c;

            List<SelectListItem> items = GetSelectItem(false);
            foreach (var i in districtlist)
            {
                items.Add(new SelectListItem
                {
                    Text = i.FDistrictName,
                    Value = i.FPostCode.ToString(),
                });
            }
            if(districtname != "")
            {
                items.Where(p => p.Text == districtname).First().Selected = true;
            }
            return items;


        }
    }
}
