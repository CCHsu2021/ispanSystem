using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MSITTeam1.Models;
using MSITTeam1.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MSITTeam1.Controllers
{
    public class StudentResumeController : Controller
    {
        private readonly helloContext hello;
        IWebHostEnvironment _enviroment;

        [ActivatorUtilitiesConstructor]
        public StudentResumeController(helloContext _hello, IWebHostEnvironment p)
        {
            hello = _hello;
            _enviroment = p;
        }

        public IActionResult List()
        {
            int keyword = 111;
            ViewBag.k = keyword;

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

        
        //public IActionResult Edit(string? id)
        //{
        //    if (id != null)
        //    {

        //        StudentBasic sb = hello.StudentBasics.FirstOrDefault(c => c.FAccount == (string)id);
        //        if (sb != null)
        //            return View(new CStudentResumeViewModel() { student = sb ,fGender = sb.Gender.Equals("0")?"男":"女"});
        //    }
        //    return RedirectToAction("List");
        //}

        [HttpPost]
        public IActionResult Edit([FromBody]CStudentResumeViewModel p)
        {

            StudentBasic sb = hello.StudentBasics.FirstOrDefault(c => c.FAccount == p.fAccount);
            if (sb != null)
            {
                if (p.photo != null)
                {
                    string photoName = Guid.NewGuid().ToString() + ".jpg";
                    sb.Portrait = photoName;

                    p.photo.CopyTo(new FileStream(
                        _enviroment.WebRootPath + @"\images\student\" + photoName, FileMode.Create)); 
                }
                sb.Name = p.fName;
                sb.Gender = p.fGender.Equals("男")?"0":"1";
                sb.BirthDate= p.fBirthDate;
                sb.Email = p.fEmail;
                sb.Phone = p.fPhone;
                sb.ContactAddress = p.fAddress;
                sb.Autobiography = p.fAutobiography;
                hello.SaveChanges();
            }
            return Content("修改成功");
        }
    }
}
