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

        public IActionResult Detail(int txtJobId)
        {
            ViewBag.Account = CDictionary.account;

            var chooseOne = GetLeftJoinJobVacancies().FirstOrDefault(p=>p.Fid.Equals(txtJobId));
            
            return View(chooseOne);     //todo 尚未將View調整為專案檢視格式。需時一天
        }

        public IActionResult ResumeSend(TMemberResumeSend vModel,string ddlstartTime,string ddlendTime,long ddlResume)
        {
            
            var jobApply = _context.TMemberResumeSends.Max(p => p.ResumeSendId);
            DateTime dateTimeNow = DateTime.Now;
            string dateNow = dateTimeNow.ToString("yyyyMMdd");
            string addNewRS = $"RS{dateNow}00001";

            if (jobApply != null)
            {
                string lastDate = jobApply.Substring(2, 8);
                if (lastDate != dateNow)
                {
                    vModel.ResumeSendId = addNewRS;
                }
                else
                {
                    int num = int.Parse(jobApply.Substring(10, 5)) + 1;
                    vModel.ResumeSendId = $"RS{lastDate + num.ToString("00000")}";
                }
            }
            else
            {
                vModel.ResumeSendId = addNewRS;
            }

            string contactTime = $"{ddlstartTime}~{ddlendTime}";

            vModel.ComReadOrNot = "未讀";
            vModel.TimeToContact = contactTime;
            vModel.ResumeId = ddlResume;
            vModel.CreatTime = dateTimeNow.ToString();
            vModel.ModifyTime = dateTimeNow.ToString();

            _context.Add(vModel);
            _context.SaveChanges();

            return RedirectToAction("Index");
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
