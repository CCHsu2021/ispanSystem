
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MSITTeam1.Models;
using MSITTeam1.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace MSITTeam1.ViewComponent
{
    [Microsoft.AspNetCore.Mvc.ViewComponent]
    public class StudentWorkExperienceViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly helloContext hello;

        [ActivatorUtilitiesConstructor]
        public StudentWorkExperienceViewComponent(helloContext _hello)
        {
            hello = _hello;
        }
        public IViewComponentResult Invoke()
        {
            string account = CDictionary.account;
            ViewBag.fAccount = account;

            CStudentResumeViewModel SBvModel = new CStudentResumeViewModel();
            List<CStudentResumeViewModel> list = new List<CStudentResumeViewModel>();
            var datas = from b in hello.StudentWorkExperiences.Where(p => p.MemberId == account) select b;
           
            foreach (StudentWorkExperience t in datas)
                list.Add(new CStudentResumeViewModel() { workExperience = t });
            return View(list);
        }
    }
}
