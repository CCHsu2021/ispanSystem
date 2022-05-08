using Microsoft.AspNetCore.Mvc;
using MSITTeam1.Models;
using MSITTeam1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MSITTeam1.ViewComponent
{
    [Microsoft.AspNetCore.Mvc.ViewComponent]
    public class StudentResumeImageViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly helloContext hello;
        public StudentResumeImageViewComponent(helloContext _hello)
        {
            hello = _hello;
        }
        public IViewComponentResult Invoke()
        {

            CStudentResumeViewModel SBvModel = new CStudentResumeViewModel();
            List<CStudentResumeViewModel> sb = new List<CStudentResumeViewModel>();
            
            StudentResume sr = hello.StudentResumes.FirstOrDefault(a => a.MemberId == CDictionary.account);
            if (sr != null)
            {
                SBvModel.ResumeImage = Convert.ToBase64String(sr.ResumeImage);
                sb.Add(SBvModel);
                return View(sb);
            }

            return View();
        }
    }
}
