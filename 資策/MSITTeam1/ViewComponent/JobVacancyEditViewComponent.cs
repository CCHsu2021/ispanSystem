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
        public IViewComponentResult Invoke(string id = null, string jobname = null)
        {
            TNewJobVacancy job = hello.TNewJobVacancies.FirstOrDefault(p => p.FCompanyTaxid == id & p.FJobName == jobname);

            CJobVacancyViewModel c = new CJobVacancyViewModel() { job = job };
            
            return View(c);
        }
    }
}
