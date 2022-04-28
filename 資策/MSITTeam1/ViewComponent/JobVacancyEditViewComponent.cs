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
    public class JobVacancyEditViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly helloContext hello;
        public JobVacancyEditViewComponent(helloContext _hello)
        {
            hello = _hello;
        }
        public IViewComponentResult Invoke(string id, string jobname)
        {
            var job = from p in hello.TNewJobVacancies 
                      where (p.FCompanyTaxid == id & p.FJobName == jobname) 
                      select p;
            List<CJobVacancyViewModel> list = new List<CJobVacancyViewModel>();
            foreach (var i in job)
            {
                list.Add(new CJobVacancyViewModel() { job = i }); 
            }
            return View(list);
        }
    }
}
