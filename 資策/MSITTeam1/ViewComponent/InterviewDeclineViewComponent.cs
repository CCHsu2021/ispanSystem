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
    public class InterviewDeclineViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly helloContext _context;
        public InterviewDeclineViewComponent(helloContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke(int jobId,string resumeSendId)
        {
            var choooseOne = (from p in _context.TNewJobVacancies
                              select p).FirstOrDefault(p => p.Fid == jobId);

            TCompanyRespondViewModel vModel = new TCompanyRespondViewModel();
            vModel.ResumeSendId = resumeSendId;
            vModel.ContactPerson = choooseOne.FContactPerson;
            vModel.ContactPersonPhone = choooseOne.FContactPhone;
            vModel.ContactPersonEmail = choooseOne.FContactEmail;
            vModel.JobName = choooseOne.FJobName;
            

            return View(vModel);
        }
    }
}
