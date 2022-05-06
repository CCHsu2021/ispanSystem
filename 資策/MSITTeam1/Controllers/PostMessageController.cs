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
    public class PostMessageController : Controller
    {
        private readonly helloContext _context;

        public PostMessageController(helloContext context)
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
                                       where (p.CompanyTaxid.Equals(account) && p.ComReadOrNot == "未讀")
                                       orderby p.CreatTime descending
                                       select new
                                       {
                                           p,
                                           combin.FName,
                                           combin2.Name
                                       };
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
            DateTime interviewDate = Convert.ToDateTime(InterviewTime);
            string dateTimeNow = DateTime.Now.ToString();

            companyRespond.CompanyRespondId = CRID;
            companyRespond.InterviewTime = $"{interviewDate.Year}年{interviewDate.Month}月{interviewDate.Day}日 {ddlstartTime}";
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
    }
}
