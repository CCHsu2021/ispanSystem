using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MSITTeam1.Models;
using MSITTeam1.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace MSITTeam1.ViewComponent
{
    [Microsoft.AspNetCore.Mvc.ViewComponent]
    public class StudentLanguageViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly helloContext hello;

        [ActivatorUtilitiesConstructor]
        public StudentLanguageViewComponent(helloContext _hello)
        {
            hello = _hello;
        }
        public IViewComponentResult Invoke()
        {
            string account = CDictionary.account;
            ViewBag.fAccount = account;
            CStudentResumeViewModel SBvModel = new CStudentResumeViewModel();
            List<CStudentResumeViewModel> list = new List<CStudentResumeViewModel>();
            var datas = from b in hello.StudentLanguages.Where(p => p.MemberId == account) select b;

            foreach (StudentLanguage t in datas)
                list.Add(new CStudentResumeViewModel() { language = t ,Listening = determine(t.Listening), Speaking = determine(t.Speaking), Reading=determine(t.Reading) , Writing=determine(t.Writing)
                });
            return View(list);
        }

        public string determine(string a)
        {
            if (a == "0")
                return "初階";
            if (a == "1")
                return "中等";
            if (a == "2")
                return "高階";
            if (a == "3")
                return "母語";
            return "未指定";
        }
    }
}
