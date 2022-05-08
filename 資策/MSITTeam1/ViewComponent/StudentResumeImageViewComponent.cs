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

            
            List<CStudentResumeViewModel> sb = new List<CStudentResumeViewModel>();
            
            var sr = hello.StudentResumes.Where(a => a.MemberId == CDictionary.account).ToList();
            if (sr != null)
            {
                foreach (var t in sr)
                    sb.Add(new CStudentResumeViewModel() { resume = t , ResumeImage= Convert.ToBase64String(t.ResumeImage) });
 
                return View(sb);
            }

            return View();
        }
    }
}
