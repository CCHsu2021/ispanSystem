using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MSITTeam1.Models;
using MSITTeam1.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace MSITTeam1.ViewComponent
{
    [Microsoft.AspNetCore.Mvc.ViewComponent]
    public class StudentResumeViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly helloContext hello;
        //IWebHostEnvironment _enviroment;

        [ActivatorUtilitiesConstructor]
        public StudentResumeViewComponent(helloContext _hello/*, IWebHostEnvironment p*/)
        {
            hello = _hello;
            //_enviroment = p;
        }
        public IViewComponentResult Invoke()
        {
            int keyword = 111;

            CStudentResumeViewModel SBvModel = new CStudentResumeViewModel();
            List<CStudentResumeViewModel> sb = new List<CStudentResumeViewModel>();
            var datas = from b in hello.StudentBasics.Where(p => p.FAccount == keyword.ToString())
                        select new
                        {
                            Account = b.FAccount,
                            Name = b.Name,
                            Email = b.Email,
                            Phone = b.Phone,
                            birthday = b.BirthDate,
                            Address = b.ContactAddress,
                            Autobiography = b.Autobiography,
                            gen = b.Gender,
                            c = b.FCompany,
                            protrait = b.Portrait
                        };
            foreach (var a in datas)

            {
                SBvModel.fAccount = a.Account;
                SBvModel.fName = a.Name;
                SBvModel.fGender = a.gen.Equals("0") ? "男" : "女";
                SBvModel.fBirthDate = a.birthday;
                SBvModel.fEmail = a.Email;
                SBvModel.fPhone = a.Phone;
                SBvModel.fAddress = a.Address;
                SBvModel.fAutobiography = a.Autobiography;
                SBvModel.fPortrait = a.protrait;
            }
            sb.Add(SBvModel);


            return View(sb);
        }
    }
}
