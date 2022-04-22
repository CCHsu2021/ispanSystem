using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MSITTeam1.Models;
using MSITTeam1.ViewModels;
using System.Linq;

namespace MSITTeam1.ViewComponent
{
    [Microsoft.AspNetCore.Mvc.ViewComponent]
    public class StudentWorkExperienceEditViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly helloContext hello;

        [ActivatorUtilitiesConstructor]
        public StudentWorkExperienceEditViewComponent(helloContext _hello)
        {
            hello = _hello;
        }
        public IViewComponentResult Invoke(long id)
        {
            
            StudentWorkExperience sw = hello.StudentWorkExperiences.FirstOrDefault(c => c.WorkExperienceId == id);
            return View(new CStudentResumeViewModel() { workExperience = sw });
        }
    }
}
