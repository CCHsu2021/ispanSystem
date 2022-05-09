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
            ViewBag.account = CDictionary.account;
            ViewBag.type = CDictionary.memtype;
            ViewBag.name = CDictionary.username;
            
            var companyResumeReceive = from p in _context.TMemberResumeSends
                                       join t in _context.TCompanyBasics on p.CompanyTaxid equals t.CompanyTaxid into pt
                                       from combin in pt.DefaultIfEmpty()
                                       join s in _context.StudentBasics on p.MemberId equals s.MemberId into ps
                                       from combin2 in ps.DefaultIfEmpty()
                                       where p.CompanyTaxid.Equals(CDictionary.account)
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
            ViewBag.account = CDictionary.account;
            ViewBag.type = CDictionary.memtype;
            ViewBag.name = CDictionary.username;
            var jobOpen = _context.TNewJobVacancies.FirstOrDefault(t => t.Fid == (_context.TMemberResumeSends.FirstOrDefault(p => p.ResumeSendId == ResumeSendId).JobId));
            if (jobOpen == null)
            {
                return View();
            }

            var chooseOne = (from p in _context.TMemberResumeSends
                             where p.ResumeSendId == ResumeSendId
                             join t in _context.TCompanyBasics on p.CompanyTaxid equals t.CompanyTaxid into pt
                             from combin in pt.DefaultIfEmpty()
                             join s in _context.StudentBasics on p.MemberId equals s.MemberId into ps
                             from combin2 in ps.DefaultIfEmpty()
                             join c in _context.StudentResumes on p.ResumeId equals c.ResumeId into pc
                             from combin3 in pc.DefaultIfEmpty()
                             select new
                             {
                                 p,
                                 combin.FName,
                                 combin2.Name,
                             }).FirstOrDefault();
            var chooseResume = _context.TMemberResumeSends.FirstOrDefault(p => p.ResumeSendId.Equals(ResumeSendId));
            if (chooseResume.ComReadOrNot == "未讀")
            {
                chooseResume.ComReadOrNot = "已讀";
                _context.SaveChanges();
            }

            TCompanyResumeReceiveViewModel vModel = new TCompanyResumeReceiveViewModel();
            vModel.memRS = chooseOne.p;
            vModel.FCompanyName = chooseOne.FName;
            vModel.FStudentName = chooseOne.Name;
            var resumeImg = _context.StudentResumes.FirstOrDefault(p => p.ResumeId == chooseOne.p.ResumeId);
            if (resumeImg != null)
            {
                vModel.ResumeImage = Convert.ToBase64String(resumeImg.ResumeImage);
            }

            return View(vModel);
        }

        public IActionResult InterviewInvitation(TCompanyRespond companyRespond,string ddlstartTime,string InterviewTime)
        {
            ViewBag.account = CDictionary.account;
            ViewBag.type = CDictionary.memtype;
            ViewBag.name = CDictionary.username;
            string CRID = $"CR{companyRespond.ResumeSendId}";
            string interviewDate = Convert.ToDateTime(InterviewTime).ToString("yyyy年MM月dd日");
            string dateTimeNow = DateTime.Now.ToString();
            var overRespond = _context.TCompanyResponds.FirstOrDefault(p => p.CompanyRespondId == CRID);
            var resume = _context.TMemberResumeSends.FirstOrDefault(p => p.ResumeSendId == companyRespond.ResumeSendId);
            if (overRespond == null)
            {
                TCompanyRespond newData = new TCompanyRespond();
                newData.CompanyRespondId = CRID;
                newData.ResumeSendId = companyRespond.ResumeSendId;
                newData.ContactPerson = companyRespond.ContactPerson;
                newData.ContactPersonPhone = companyRespond.ContactPersonPhone;
                newData.ContactPersonEmail = companyRespond.ContactPersonEmail;
                newData.InterviewState = companyRespond.InterviewState;
                newData.InterviewTime = $"{interviewDate} {ddlstartTime}";
                newData.InterviewAddress = companyRespond.InterviewAddress;
                newData.StudentRespondTime = companyRespond.StudentRespondTime;
                newData.InterviewContent = companyRespond.InterviewContent;
                newData.CreatTime = dateTimeNow;
                newData.ModifyTime = dateTimeNow;

                _context.TCompanyResponds.Add(newData);

                //resume.ComReadOrNot = companyRespond.InterviewState;
            }
            else
            {
                overRespond.ResumeSendId = companyRespond.ResumeSendId;
                overRespond.ContactPerson = companyRespond.ContactPerson;
                overRespond.ContactPersonPhone = companyRespond.ContactPersonPhone;
                overRespond.ContactPersonEmail = companyRespond.ContactPersonEmail;
                overRespond.InterviewState = companyRespond.InterviewState;
                overRespond.InterviewTime = $"{interviewDate} {ddlstartTime}";
                overRespond.InterviewAddress = companyRespond.InterviewAddress;
                overRespond.StudentRespondTime = companyRespond.StudentRespondTime;
                overRespond.InterviewContent = companyRespond.InterviewContent;
                overRespond.ModifyTime = dateTimeNow;
                resume.ComReadOrNot = companyRespond.InterviewState;
            }
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult InterviewDecline(TCompanyRespond companyRespond)
        {
            ViewBag.account = CDictionary.account;
            ViewBag.type = CDictionary.memtype;
            ViewBag.name = CDictionary.username;
            string CRID = $"CR{companyRespond.ResumeSendId}";
            string dateTimeNow = DateTime.Now.ToString();
            var overRespond = _context.TCompanyResponds.FirstOrDefault(p => p.CompanyRespondId == CRID);
            var resume = _context.TMemberResumeSends.FirstOrDefault(p => p.ResumeSendId == companyRespond.ResumeSendId);
            if(overRespond == null)
            {
                TCompanyRespond newData = new TCompanyRespond();
                newData.CompanyRespondId = CRID;
                newData.ResumeSendId = companyRespond.ResumeSendId;
                newData.ContactPerson = companyRespond.ContactPerson;
                newData.ContactPersonEmail = companyRespond.ContactPersonEmail;
                newData.ContactPersonPhone = companyRespond.ContactPersonPhone;
                newData.InterviewContent = companyRespond.InterviewContent;
                newData.InterviewState = companyRespond.InterviewState;
                newData.InterviewTime = companyRespond.InterviewTime;
                newData.InterviewAddress = companyRespond.InterviewAddress;
                newData.StudentRespondTime = companyRespond.StudentRespondTime;
                newData.CreatTime = dateTimeNow;
                newData.ModifyTime = dateTimeNow;

                _context.TCompanyResponds.Add(newData);
                
                resume.ComReadOrNot = companyRespond.InterviewState;
            }
            else
            {
                overRespond.ResumeSendId = companyRespond.ResumeSendId;
                overRespond.ContactPerson = companyRespond.ContactPerson;
                overRespond.ContactPersonEmail = companyRespond.ContactPersonEmail;
                overRespond.ContactPersonPhone = companyRespond.ContactPersonPhone;
                overRespond.InterviewContent = companyRespond.InterviewContent;
                overRespond.InterviewState = companyRespond.InterviewState;
                overRespond.InterviewTime = companyRespond.InterviewTime;
                overRespond.InterviewAddress = companyRespond.InterviewAddress;
                overRespond.StudentRespondTime = companyRespond.StudentRespondTime;
                overRespond.ModifyTime = dateTimeNow;
                resume.ComReadOrNot = companyRespond.InterviewState;
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        //public IActionResult OutboxIndex()
        //{
        //    //todo 目前這邊登入資料寫死
        //    string account = "222";
        //    ViewBag.account = account;
        //    var companyRespond = from p in _context.TCompanyResponds
        //                         join t in _context.TMemberResumeSends on p.ResumeSendId equals t.ResumeSendId into pt
        //                         from combin in pt.DefaultIfEmpty()
        //                         join c in _context.StudentBasics on combin.MemberId equals c.MemberId into tc
        //                         from combin2 in tc.DefaultIfEmpty()
        //                         where (t.CompanyTaxid.Equals(account) && p.InterviewState == "接受")
        //                         orderby p.InterviewTime descending
        //                         select new
        //                         {
        //                             p,
        //                             t,
        //                             combin2.Name
        //                         };
        //    if (companyResumeReceive != null)
        //    {
        //        List<TCompanyResumeReceiveViewModel> list = new List<TCompanyResumeReceiveViewModel>();
        //        foreach (var item in companyResumeReceive)
        //        {
        //            TCompanyResumeReceiveViewModel vModel = new TCompanyResumeReceiveViewModel();
        //            vModel.memRS = item.p;
        //            vModel.FCompanyName = item.FName;
        //            vModel.FStudentName = item.Name;
        //            list.Add(vModel);
        //        }
        //        return View(list);
        //    }
        //    return View();
        //}



        public IActionResult InterviewConfirm()
        {
            ViewBag.account = CDictionary.account;
            ViewBag.type = CDictionary.memtype;
            ViewBag.name = CDictionary.username;
            var confirm = from p in _context.TCompanyResponds
                          join t in _context.TMemberResumeSends on p.ResumeSendId equals t.ResumeSendId
                          //join s in _context.TCompanyBasics on t.CompanyTaxid equals s.CompanyTaxid into ts
                          //from combin in ts.DefaultIfEmpty()
                          join c in _context.StudentBasics on t.MemberId equals c.MemberId into tc
                          from combin2 in tc.DefaultIfEmpty()
                          where (t.CompanyTaxid.Equals(CDictionary.account) && p.InterviewState == "接受")
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
            ViewBag.account = CDictionary.account;
            ViewBag.type = CDictionary.memtype;
            ViewBag.name = CDictionary.username;
            var confirmDetail = (from p in _context.TCompanyResponds
                                 where p.CompanyRespondId == CompanyRespondId
                                 join t in _context.TMemberResumeSends on p.ResumeSendId equals t.ResumeSendId
                                 //join s in _context.TCompanyBasics on t.CompanyTaxid equals s.CompanyTaxid into ts
                                 //from combin in ts.DefaultIfEmpty()
                                 join c in _context.StudentBasics on t.MemberId equals c.MemberId into tc
                                 from combin2 in tc.DefaultIfEmpty()
                                 select new 
                                 {
                                     p,
                                     t,
                                     combin2.Name
                                 }).ToList().FirstOrDefault();
            ResumeSendAndCompanyRespondViewModel vModel = new ResumeSendAndCompanyRespondViewModel();
            vModel.comR = confirmDetail.p;
            vModel.memRS = confirmDetail.t;
            vModel.StudentName = confirmDetail.Name;

            var resumeImg = _context.StudentResumes.FirstOrDefault(
                p => p.ResumeId == (_context.TMemberResumeSends.FirstOrDefault(
                    t => t.ResumeSendId == (_context.TCompanyResponds.FirstOrDefault(
                        s => s.CompanyRespondId == CompanyRespondId).ResumeSendId))).ResumeId);
            if (resumeImg != null)
            {
                vModel.ResumeImage = Convert.ToBase64String(resumeImg.ResumeImage);
            }

            return View(vModel);
            //todo 美化頁面
        }

        public IActionResult InterviewInfoEdit(TCompanyRespond companyRespond, string ddlstartTime, string InterviewTime)
        {
            ViewBag.account = CDictionary.account;
            ViewBag.type = CDictionary.memtype;
            ViewBag.name = CDictionary.username;
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
