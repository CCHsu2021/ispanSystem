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
    public class InterviewInvitationViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly helloContext _context;
        public InterviewInvitationViewComponent(helloContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke(int jobId,string resumeSendId)
        {
            var jobInfo = (from p in _context.TNewJobVacancies
                              select p).FirstOrDefault(p => p.Fid == jobId);

            TCompanyRespondViewModel vModel = new TCompanyRespondViewModel();
            vModel.ResumeSendId = resumeSendId;
            vModel.ContactPerson = jobInfo.FContactPerson;
            vModel.ContactPersonPhone = jobInfo.FContactPhone;
            vModel.ContactPersonEmail = jobInfo.FContactEmail;
            vModel.InterviewAddress = jobInfo.FCity + jobInfo.FDistrict + jobInfo.FWorkAddress;
            vModel.JobName = jobInfo.FJobName;
            

            return View(vModel);
        }
    }
}
