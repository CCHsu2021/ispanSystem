using Microsoft.AspNetCore.Http;
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
    public class StudentBasicEditViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly helloContext hello;
        public StudentBasicEditViewComponent(helloContext _hello)
        {
            hello = _hello;
        }

        public IViewComponentResult Invoke(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var student = hello.StudentBasics.FirstOrDefault(p => p.FAccount == id);
                if (student != null)
                    return View(new CStudentResumeViewModel() { student = student, fGender = student.Gender.Equals("0") ? "男" : "女" });
            }
            return View("../CMemberCenter/Index");
        }
    }
}