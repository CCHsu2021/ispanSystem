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
    public class MemberPostMessageController : Controller
    {
        private readonly helloContext _context;

        public MemberPostMessageController(helloContext context)
        {
            _context = context;
        }

        public IActionResult OutboxIndex()
        {
            ViewBag.account = CDictionary.account;
            ViewBag.type = CDictionary.memtype;
            ViewBag.name = CDictionary.username;
            var companyResumeReceive = from p in _context.TMemberResumeSends
                                       join t in _context.TCompanyBasics on p.CompanyTaxid equals t.CompanyTaxid into pt
                                       from combin in pt.DefaultIfEmpty()
                                       join s in _context.StudentBasics on p.MemberId equals s.MemberId into ps
                                       from combin2 in ps.DefaultIfEmpty()
                                       where p.MemberId.Equals(CDictionary.account)
                                       orderby p.CreatTime descending
                                       select new
                                       {
                                           p,
                                           combin.FName,
                                           combin2.Name
                                       };
            if (companyResumeReceive != null)
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
            ViewBag.account = CDictionary.account;
            ViewBag.type = CDictionary.memtype;
            ViewBag.name = CDictionary.username;
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
            return View(chooseOne);
            //todo 美化頁面
        }

        public IActionResult InboxIndex()
        {
            ViewBag.account = CDictionary.account;
            ViewBag.type = CDictionary.memtype;
            ViewBag.name = CDictionary.username;
            var companyRespond = from p in _context.TCompanyResponds
                                 join t in _context.TMemberResumeSends on p.ResumeSendId equals t.ResumeSendId
                                 join s in _context.TCompanyBasics on t.CompanyTaxid equals s.CompanyTaxid into ps
                                 from combin in ps.DefaultIfEmpty()
                                 select new 
                                 {
                                     p,
                                     t,
                                     combin.FName
                                 };
            List<ResumeSendAndCompanyRespondViewModel> list = new List<ResumeSendAndCompanyRespondViewModel>();
            foreach(var item in companyRespond)
            {
                ResumeSendAndCompanyRespondViewModel vModel = new ResumeSendAndCompanyRespondViewModel();
                vModel.comR = item.p;
                vModel.memRS = item.t;
                vModel.CompanyName = item.FName;
                list.Add(vModel);
            }

            return View(list);
        }
        

        public IActionResult CompanyRespondDetail(string CompanyRespondId)
        {
            ViewBag.account = CDictionary.account;
            ViewBag.type = CDictionary.memtype;
            ViewBag.name = CDictionary.username;
            var companyRespond = (from p in _context.TCompanyResponds
                                 where p.CompanyRespondId == CompanyRespondId
                                 join t in _context.TMemberResumeSends on p.ResumeSendId equals t.ResumeSendId
                                 join s in _context.TCompanyBasics on t.CompanyTaxid equals s.CompanyTaxid into ps
                                 from combin in ps.DefaultIfEmpty()
                                 select new ResumeSendAndCompanyRespondViewModel
                                 {
                                     comR = p,
                                     memRS = t,
                                     CompanyName = combin.FName
                                 }).ToList().FirstOrDefault();
            companyRespond.InterviewState = "已讀";
            _context.SaveChanges();

            return View(companyRespond);
        }
        public IActionResult AcceptInterview(string CompanyRespondId)
        {
            ViewBag.account = CDictionary.account;
            ViewBag.type = CDictionary.memtype;
            ViewBag.name = CDictionary.username;
            var CR = _context.TCompanyResponds.FirstOrDefault(p => p.CompanyRespondId == CompanyRespondId);
            CR.InterviewState = "接受";

            var memRS = _context.TMemberResumeSends.FirstOrDefault(p => p.ResumeSendId == CR.ResumeSendId);
            memRS.ComReadOrNot = "接受";

            _context.SaveChanges();

            return RedirectToAction("InboxIndex");
        }


        public IActionResult InterviewDecline(string CompanyRespondId)
        {
            ViewBag.account = CDictionary.account;
            ViewBag.type = CDictionary.memtype;
            ViewBag.name = CDictionary.username;
            var CR = _context.TCompanyResponds.FirstOrDefault(p => p.CompanyRespondId == CompanyRespondId);
            CR.InterviewState = "婉拒";

            var memRS = _context.TMemberResumeSends.FirstOrDefault(p => p.ResumeSendId == CR.ResumeSendId);
            memRS.ComReadOrNot = "婉拒";

            _context.SaveChanges();

            return RedirectToAction("InboxIndex");
        }


        //public IActionResult InterviewConfirm()
        //{
        //    //todo 目前這邊登入資料寫死
        //    string account = "222";
        //    ViewBag.account = account;
        //    var confirm = from p in _context.TCompanyResponds
        //                  join t in _context.TMemberResumeSends on p.ResumeSendId equals t.ResumeSendId
        //                  //join s in _context.TCompanyBasics on t.CompanyTaxid equals s.CompanyTaxid into ts
        //                  //from combin in ts.DefaultIfEmpty()
        //                  join c in _context.StudentBasics on t.MemberId equals c.MemberId into tc
        //                  from combin2 in tc.DefaultIfEmpty()
        //                  where (t.CompanyTaxid.Equals(account) && p.InterviewState == "接受")
        //                  orderby p.InterviewTime descending
        //                  select new
        //                  {
        //                      p,
        //                      t,
        //                      combin2.Name
        //                  };
        //    if (confirm != null)
        //    {
        //        List<ResumeSendAndCompanyRespondViewModel> list = new List<ResumeSendAndCompanyRespondViewModel>();
        //        foreach (var item in confirm)
        //        {
        //            ResumeSendAndCompanyRespondViewModel vModel = new ResumeSendAndCompanyRespondViewModel();
        //            vModel.comR = item.p;
        //            vModel.memRS = item.t;
        //            vModel.StudentName = item.Name;
        //            list.Add(vModel);
        //        }

        //        return View(list);
        //    }
        //    return View();
        //}

        //public IActionResult ConfirmInfo(string CompanyRespondId)
        //{
        //    var confirmDetail = (from p in _context.TCompanyResponds
        //                         where p.CompanyRespondId == CompanyRespondId
        //                         join t in _context.TMemberResumeSends on p.ResumeSendId equals t.ResumeSendId
        //                         //join s in _context.TCompanyBasics on t.CompanyTaxid equals s.CompanyTaxid into ts
        //                         //from combin in ts.DefaultIfEmpty()
        //                         join c in _context.StudentBasics on t.MemberId equals c.MemberId into tc
        //                         from combin2 in tc.DefaultIfEmpty()
        //                         select new ResumeSendAndCompanyRespondViewModel
        //                         {
        //                             comR = p,
        //                             memRS = t,
        //                             StudentName = combin2.Name
        //                         }).ToList().FirstOrDefault();

        //    return View(confirmDetail);
        //    //todo 美化頁面
        //}

        //public IActionResult InterviewInfoEdit(TCompanyRespond companyRespond, string ddlstartTime, string InterviewTime)
        //{
        //    var companyRespondToEdit = _context.TCompanyResponds.FirstOrDefault(p => p.CompanyRespondId == companyRespond.CompanyRespondId);
        //    string interviewDate = Convert.ToDateTime(InterviewTime).ToString("yyyy年MM月dd日");
        //    string dateTimeNow = DateTime.Now.ToString();

        //    companyRespondToEdit = companyRespond;
        //    companyRespondToEdit.InterviewTime = $"{interviewDate} {ddlstartTime}";
        //    companyRespondToEdit.ModifyTime = dateTimeNow;

        //    _context.SaveChanges();

        //    return RedirectToAction("InterviewConfirm");

        //}
    }
}
