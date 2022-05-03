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
    public class JobVacancyViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly helloContext hello;
        public JobVacancyViewComponent(helloContext _hello)
        {
            hello = _hello;
        }
        public IViewComponentResult Invoke()
        {
            string account = CDictionary.account;
            IEnumerable<CJobVacancyViewModel> job = null;
            //job = hello.TNewJobVacancies.Where(p => p.FCompanyTaxid == account);
            job = (from p in hello.TNewJobVacancies
                   from c in hello.TJobDirects
                   where p.FCompanyTaxid == account & c.JobListId == p.FJobListId
                   select new CJobVacancyViewModel()
                   {
                       job = p,
                       FJobListName = c.FJobDirect
                   }).ToList();
            return View(job);
        }
    }
}
