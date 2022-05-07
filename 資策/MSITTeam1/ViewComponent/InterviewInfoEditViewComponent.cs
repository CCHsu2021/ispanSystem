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
    public class InterviewInfoEditViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly helloContext _context;
        public InterviewInfoEditViewComponent(helloContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke(int jobId,string CompanyRespondId)
        {
            var companyRespond = _context.TCompanyResponds.FirstOrDefault(p => p.CompanyRespondId == CompanyRespondId);
            var jobInfo = (from p in _context.TNewJobVacancies
                              select p).FirstOrDefault(p => p.Fid == jobId);

            ResumeSendAndCompanyRespondViewModel vModel = new ResumeSendAndCompanyRespondViewModel();
            vModel.comR = companyRespond;
            vModel.JobName = jobInfo.FJobName;
            

            return View(vModel);
        }
    }
}
