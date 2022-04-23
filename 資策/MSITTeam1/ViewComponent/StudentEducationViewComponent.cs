using Microsoft.AspNetCore.Mvc;
using MSITTeam1.Models;
using MSITTeam1.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace MSITTeam1.ViewComponent
{
    [Microsoft.AspNetCore.Mvc.ViewComponent]
    public class StudentEducationViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly helloContext hello;
        public StudentEducationViewComponent(helloContext _hello)
        {
            hello = _hello;
        }
        public IViewComponentResult Invoke()
        {
            string account = CDictionary.account;
            ViewBag.fAccount = account;
            CStudentResumeViewModel SBvModel = new CStudentResumeViewModel();
            List<CStudentResumeViewModel> list = new List<CStudentResumeViewModel>();
            var datas = from b in hello.StudentEducations.Where(p => p.MemberId == account) select b;

            foreach (StudentEducation t in datas)
                list.Add(new CStudentResumeViewModel() { education = t });
            return View(list);
        }
    }
}
