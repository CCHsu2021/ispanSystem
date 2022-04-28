using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MSITTeam1.Models;
using MSITTeam1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace MSITTeam1.ViewComponent
{
    [Microsoft.AspNetCore.Mvc.ViewComponent]
    public class JobApplyViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly helloContext _context;
        public JobApplyViewComponent(helloContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke(string jobName,string companyTaxid)
        {
            CDictionary.account = "111";
            TMemberResumeSendViewModel memberResumeSend = new TMemberResumeSendViewModel();
            var contactOne =_context.StudentBasics.FirstOrDefault(p => p.FAccount == CDictionary.account);

            var jobApply = _context.TMemberResumeSends.Max(p => p.ResumeSendId);
            string dateNow = DateTime.Now.ToString("yyyyMMdd");
            string addNewRS = $"RS{dateNow}00001";

            if (jobApply != null)
            {
                string lastDate = jobApply.Substring(2, 9);
                if (lastDate != dateNow)
                {
                    memberResumeSend.ResumeSendId = addNewRS;
                }
                else
                {
                    int num = int.Parse(jobApply.Substring(10, 14)) + 1;
                    memberResumeSend.ResumeSendId = $"RS{lastDate + num:00000}";
                }
            }
            else
            {
                memberResumeSend.ResumeSendId = addNewRS;
            }

            memberResumeSend.MemberId = CDictionary.account;  //這邊帶入登入帳號，之後記得打開
            memberResumeSend.JobName = jobName;
            memberResumeSend.CompanyTaxid = companyTaxid;
            memberResumeSend.ContactPhone = contactOne.Phone;
            memberResumeSend.ContactEmail = contactOne.Email;

            return View(memberResumeSend);
        }
    }
}
