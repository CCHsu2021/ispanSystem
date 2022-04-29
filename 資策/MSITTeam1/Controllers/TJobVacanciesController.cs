using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MSITTeam1.Models;
using MSITTeam1.ViewModels;

namespace MSITTeam1.Controllers
{
    public class TJobVacanciesController : Controller
    {
        private readonly helloContext _context;
        //private readonly TJobVacanciesViewModel _jobVacancyVM;

        public TJobVacanciesController(helloContext context)
        {
            _context = context;
        }

        // GET: TJobVacancies
        public IActionResult Index(JobVacanciesSearchBarViewModel vModel)
        {
            ViewBag.Account = CDictionary.account;

            IEnumerable<TJobVacanciesViewModel> data = GetLeftJoinJobVacancies();
            List<TJobVacanciesViewModel> list = new List<TJobVacanciesViewModel>();
            if (vModel.txtSearchText != null)
            {
                string lowerSearchText = vModel.txtSearchText.ToLower();
                data = data.Where(p => p.FJobName.ToLower().Contains(lowerSearchText)
                    || p.FJobDirect.ToLower().Contains(lowerSearchText)
                    || p.FCompanyName.ToLower().Contains(lowerSearchText)
                    || p.FOther.ToLower().Contains(lowerSearchText));
            }

            if (vModel.ddlJobListId != null)
            {
                data = data.Where(p => p.FJobListId.Equals(vModel.ddlJobListId));
            }

            if (vModel.ddlCity != null)
            {
                data = data.Where(p => p.FCity.Contains(vModel.ddlCity));
            }

            foreach (var item in data)
            {
                list.Add(item);
            }

            return View(list);

        }

        public IEnumerable<TJobVacanciesViewModel> GetLeftJoinJobVacancies()
        {
            IEnumerable<TJobVacanciesViewModel> data = null;
            //LINQ，TNewJobVacancies left join TCompanyBasics left join TJobDirects
            data = from p in _context.TNewJobVacancies
                   join t in _context.TCompanyBasics on p.FCompanyTaxid equals t.CompanyTaxid into pt
                   from combin in pt.DefaultIfEmpty()
                   join s in _context.TJobDirects on p.FJobListId equals s.JobListId into ps
                   from combin2 in ps.DefaultIfEmpty()
                   select new TJobVacanciesViewModel()
                   {
                       jobV = p,
                       FCompanyName = combin.FName,
                       FCompanyLogo = combin.FLogo,
                       FJobDirect = combin2.FJobDirect
                   };
            return data;
        }

        public IActionResult Detail(JobInfoViewModel vModel)
        {
            ViewBag.Account = CDictionary.account;

            var chooseOne = GetLeftJoinJobVacancies().FirstOrDefault(p=>
            p.FJobName.Equals(vModel.txtJobName) && p.FCompanyTaxid.Equals(vModel.txtCompanyTaxid));
            
            return View(chooseOne);
        }

        public IActionResult JobDirectDropDownList()
        {
            var jobDirects = from p in _context.TJobDirects
                             select p;
            return Json(jobDirects);
        }

        public IActionResult CityDropDownList()
        {
            var city = from p in _context.TCityContrasts
                       select p.FCityName;
            var citys = city.Distinct();
                       
            return Json(citys);
        }
        public IActionResult ResumeDropDownList()
        {
            var studentResumes = from p in _context.StudentResumes
                       where p.MemberId == CDictionary.account
                       select p;
            return Json(studentResumes);
        }
    }
}
