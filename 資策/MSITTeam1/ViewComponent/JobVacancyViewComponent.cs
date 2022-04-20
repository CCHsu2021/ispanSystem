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
            ViewBag.Account = account;
            IEnumerable<TNewJobVacancy> job = null;
            job = hello.TNewJobVacancies.Where(p=>p.FCompanyTaxid==account);
            List < CJobVacancyViewModel > list = new List<CJobVacancyViewModel>();
            foreach (TNewJobVacancy j in job)
            {
                list.Add(new CJobVacancyViewModel() { job = j });
            }
            return View(list);
        }
    }
}
