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
    public class JobListNameSelectorViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly helloContext hello;
        public JobListNameSelectorViewComponent(helloContext _hello)
        {
            hello = _hello;
        }
        public IViewComponentResult Invoke(string joblistid = "")
        {
            if (joblistid != "")
            {
                var n = from p in hello.TJobDirects where p.JobListId.ToString() == joblistid select p.FJobDirect;
                string jobname = "";
                foreach (var i in n)
                {
                    jobname = i;
                }
                ViewBag.Jobname = jobname;
            }
            ViewBag.fJoblistID = SetDropDown1();
            return View();
        }
        List<SelectListItem> GetSelectItem(bool dvalue = true)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            if (dvalue) { items.Insert(0, new SelectListItem { Text = "--請選擇--", Value = "0" }); }
            return items;
        }

        private List<SelectListItem> SetDropDown1()
        {
            var joblistname = from p in hello.TJobDirects select p;
            List<SelectListItem> items = GetSelectItem(true);
            foreach(var a in joblistname)
            {
                items.Add(new SelectListItem()
                {
                    Text = a.FJobDirect,
                    Value = a.JobListId.ToString()
                });
            }
            //items.AddRange(new SelectList(joblistname));
            return items;
        }
    }
}
