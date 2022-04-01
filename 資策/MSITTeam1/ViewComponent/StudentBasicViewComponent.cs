﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MSITTeam1.Models;
using MSITTeam1.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace MSITTeam1.ViewComponent
{
    [Microsoft.AspNetCore.Mvc.ViewComponent]
    public class StudentBasicViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly helloContext hello;
        //IWebHostEnvironment _enviroment;

        [ActivatorUtilitiesConstructor]
        public StudentBasicViewComponent(helloContext _hello/*, IWebHostEnvironment p*/)
        {
            hello = _hello;
            //_enviroment = p;
        }
        public IViewComponentResult Invoke()
        {
            string account = CDictionary.account;
            ViewBag.fAccount = account;

            CStudentResumeViewModel SBvModel = new CStudentResumeViewModel();
            List<CStudentResumeViewModel> sb = new List<CStudentResumeViewModel>();
            var datas = from b in hello.StudentBasics.Where(p => p.MemberId == account)
                        select new
                        {
                            MemberId = b.MemberId,
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
                
                SBvModel.MemberId = a.MemberId;
                SBvModel.fName = a.Name;
                SBvModel.fGender = a.gen.Equals("0") ? "男" : a.gen.Equals("1") ? "女" : "未填寫";
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
