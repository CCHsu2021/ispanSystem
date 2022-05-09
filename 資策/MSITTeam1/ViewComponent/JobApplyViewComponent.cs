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
        public IViewComponentResult Invoke(int jobId,string jobName,string companyTaxid,string rowCount)  
        {

            ViewBag.rowCount = rowCount;
            TMemberResumeSendViewModel memberResumeSend = new TMemberResumeSendViewModel();

            

            var contactOne =_context.StudentBasics.FirstOrDefault(p => p.FAccount == CDictionary.account);
            if(contactOne != null)
            {
                if (!string.IsNullOrEmpty(contactOne.Phone))
                {
                    memberResumeSend.ContactPhone = contactOne.Phone;
                }
                if (!string.IsNullOrEmpty(contactOne.Email))
                {
                    memberResumeSend.ContactEmail = contactOne.Email;
                }
            }
            memberResumeSend.JobId = jobId;
            memberResumeSend.MemberId = CDictionary.account;  
            memberResumeSend.JobName = jobName;
            memberResumeSend.CompanyTaxid = companyTaxid;

            return View(memberResumeSend);
        }
    }
}
