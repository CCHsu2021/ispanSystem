using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MSITTeam1.Models;
using MSITTeam1.ViewModels;

namespace MSITTeam1.Controllers
{
    public class CompanyPostMessageController : Controller
    {
        private readonly helloContext _context;

        public CompanyPostMessageController(helloContext context)
        {
            _context = context;
        }

        // GET: PostMessage
        public IActionResult Index()
        {
            //todo 目前這邊登入資料寫死
            string account = "222";
            ViewBag.account = account;
            var companyResumeReceive = from p in _context.TMemberResumeSends
                                       join t in _context.TCompanyBasics on p.CompanyTaxid equals t.CompanyTaxid into pt
                                       from combin in pt.DefaultIfEmpty()
                                       join s in _context.StudentBasics on p.MemberId equals s.MemberId into ps
                                       from combin2 in ps.DefaultIfEmpty()
                                       where p.CompanyTaxid.Equals(account)
                                       orderby p.CreatTime descending
                                       select new
                                       {
                                           p,
                                           combin.FName,
                                           combin2.Name
                                       };
            if(companyResumeReceive != null)
            {
                List<TCompanyResumeReceiveViewModel> list = new List<TCompanyResumeReceiveViewModel>();
                foreach (var item in companyResumeReceive)
                {
                    TCompanyResumeReceiveViewModel vModel = new TCompanyResumeReceiveViewModel();
                    vModel.memRS = item.p;
                    vModel.FCompanyName = item.FName;
                    vModel.FStudentName = item.Name;
                    list.Add(vModel);
                }
                return View(list);
            }
            return View();
        }
        public IActionResult StudentResumeDetail(string ResumeSendId)
        {
            
            var chooseOne = (from p in _context.TMemberResumeSends
                              where p.ResumeSendId == ResumeSendId
                              join t in _context.TCompanyBasics on p.CompanyTaxid equals t.CompanyTaxid into pt
                              from combin in pt.DefaultIfEmpty()
                              join s in _context.StudentBasics on p.MemberId equals s.MemberId into ps
                              from combin2 in ps.DefaultIfEmpty()
                              select new TCompanyResumeReceiveViewModel
                              {
                                  memRS = p,
                                  FCompanyName = combin.FName,
                                  FStudentName = combin2.Name
                              }).ToList().FirstOrDefault();

            var chooseResume = _context.TMemberResumeSends.FirstOrDefault(p=>p.ResumeSendId.Equals(ResumeSendId));
            chooseResume.ComReadOrNot = "已讀";
            _context.SaveChanges();

            return View(chooseOne);
            //todo 美化頁面
        }

        public IActionResult InterviewInvitation(TCompanyRespond companyRespond,string ddlstartTime,string InterviewTime)
        {
            string CRID = $"CR{companyRespond.ResumeSendId}";
            string interviewDate = Convert.ToDateTime(InterviewTime).ToString("yyyy年MM月dd日");
            string dateTimeNow = DateTime.Now.ToString();

            companyRespond.CompanyRespondId = CRID;
            companyRespond.InterviewTime = $"{interviewDate} {ddlstartTime}";
            companyRespond.CreatTime = dateTimeNow;
            companyRespond.ModifyTime = dateTimeNow;

            _context.Add(companyRespond);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult InterviewDecline(TCompanyRespond companyRespond)
        {
            string CRID = $"CR{companyRespond.ResumeSendId}";
            string dateTimeNow = DateTime.Now.ToString();

            companyRespond.CompanyRespondId = CRID;
            companyRespond.CreatTime = dateTimeNow;
            companyRespond.ModifyTime = dateTimeNow;

            _context.Add(companyRespond);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult InterviewConfirm()
        {
            //todo 目前這邊登入資料寫死
            string account = "222";
            ViewBag.account = account;
            var confirm = from p in _context.TCompanyResponds
                          join t in _context.TMemberResumeSends on p.ResumeSendId equals t.ResumeSendId
                          //join s in _context.TCompanyBasics on t.CompanyTaxid equals s.CompanyTaxid into ts
                          //from combin in ts.DefaultIfEmpty()
                          join c in _context.StudentBasics on t.MemberId equals c.MemberId into tc
                          from combin2 in tc.DefaultIfEmpty()
                          where (t.CompanyTaxid.Equals(account) && p.InterviewState == "接受")
                          orderby p.InterviewTime descending
                          select new
                          {
                              p,
                              t,
                              combin2.Name
                          };
            if(confirm != null)
            {
                List<ResumeSendAndCompanyRespondViewModel> list = new List<ResumeSendAndCompanyRespondViewModel>();
                foreach (var item in confirm)
                {
                    ResumeSendAndCompanyRespondViewModel vModel = new ResumeSendAndCompanyRespondViewModel();
                    vModel.comR = item.p;
                    vModel.memRS = item.t;
                    vModel.StudentName = item.Name;
                    list.Add(vModel);
                }

                return View(list);
            }
            return View();
        }

        public IActionResult ConfirmInfo(string CompanyRespondId)
        {
            var confirmDetail = (from p in _context.TCompanyResponds
                                 where p.CompanyRespondId == CompanyRespondId
                                 join t in _context.TMemberResumeSends on p.ResumeSendId equals t.ResumeSendId
                                 //join s in _context.TCompanyBasics on t.CompanyTaxid equals s.CompanyTaxid into ts
                                 //from combin in ts.DefaultIfEmpty()
                                 join c in _context.StudentBasics on t.MemberId equals c.MemberId into tc
                                 from combin2 in tc.DefaultIfEmpty()
                                 select new ResumeSendAndCompanyRespondViewModel
                                 {
                                     comR = p,
                                     memRS = t,
                                     StudentName = combin2.Name
                                 }).ToList().FirstOrDefault();

            return View(confirmDetail);
            //todo 美化頁面
        }

        public IActionResult InterviewInfoEdit(TCompanyRespond companyRespond, string ddlstartTime, string InterviewTime)
        {
            var companyRespondToEdit = _context.TCompanyResponds.FirstOrDefault(p => p.CompanyRespondId == companyRespond.CompanyRespondId);
            string interviewDate = Convert.ToDateTime(InterviewTime).ToString("yyyy年MM月dd日");
            string dateTimeNow = DateTime.Now.ToString();

            companyRespondToEdit = companyRespond;
            companyRespondToEdit.InterviewTime = $"{interviewDate} {ddlstartTime}";
            companyRespondToEdit.ModifyTime = dateTimeNow;

            _context.SaveChanges();

            return RedirectToAction("InterviewConfirm");

        }
    }
}
