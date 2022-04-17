using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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

        
        public IActionResult Create()
        {
            string account = CDictionary.account;
            if (account != null)
            {

                StudentBasic sb = hello.StudentBasics.FirstOrDefault(c => c.MemberId == (string)account);
                //StudentWorkExperience sbw = hello.StudentWorkExperiences.FirstOrDefault(c => c.MemberId == (string)account);
                if (sb != null /*&& sbw != null*/)
                    return View(new CStudentResumeViewModel() { student = sb,/*workExperience=sbw*/  fGender = sb.Gender.Equals("0") ? "男" : sb.Gender.Equals("1") ? "女" : "未指定" });
            }
            
            return View();
        }


        //public IActionResult List()
        //{

        //    string account = HttpContext.Session.GetString(CDictionary.SK_LOGINED_USER_ACCOUNT);
        //    ViewBag.fAccount = account;

        //    CStudentResumeViewModel SBvModel = new CStudentResumeViewModel();
        //    List<CStudentResumeViewModel> sb = new List<CStudentResumeViewModel>();
        //    var datas = from b in hello.StudentBasics.Where(p => p.MemberId == account)
        //                select new
        //                {
        //                    MemberId = b.MemberId,
        //                    Name = b.Name,
        //                    Email = b.Email,
        //                    Phone = b.Phone,
        //                    birthday = b.BirthDate,
        //                    Address = b.ContactAddress,
        //                    Autobiography = b.Autobiography,
        //                    gen = b.Gender,
        //                    c = b.FCompany,
        //                    protrait = b.Portrait

        //                };
        //    foreach (var a in datas)

        //    {

        //        SBvModel.MemberId = a.MemberId;
        //        SBvModel.fName = a.Name;
        //        SBvModel.fGender = a.gen.Equals("0") ? "男" : a.gen.Equals("1") ? "女" : "未填寫";
        //        SBvModel.fBirthDate = a.birthday;
        //        SBvModel.fEmail = a.Email;
        //        SBvModel.fPhone = a.Phone;
        //        SBvModel.fAddress = a.Address;
        //        SBvModel.fAutobiography = a.Autobiography;
        //        SBvModel.fPortrait = a.protrait;
        //    }
        //    sb.Add(SBvModel);


        //    return View(sb);
        //}


        public IActionResult Edit(string? id)
        {
            if (id != null)
            {

                StudentBasic sb = hello.StudentBasics.FirstOrDefault(c => c.MemberId == (string)id);
                if (sb != null)
                    return View(new CStudentResumeViewModel() { student = sb, fGender = sb.Gender.Equals("0") ? "男" : sb.Gender.Equals("1") ? "女" : "未指定" });
            }
            return RedirectToAction("List");
        }

        [HttpPost]
        public IActionResult Edit([FromBody]CStudentResumeViewModel p)
        {

            StudentBasic sb = hello.StudentBasics.FirstOrDefault(c => c.MemberId == p.MemberId);
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
                sb.Gender = p.fGender.Equals("男")?"0":p.fGender.Equals("女")?"1":"2";
                sb.BirthDate= p.fBirthDate;
                sb.Email = p.fEmail;
                sb.Phone = p.fPhone;
                sb.ContactAddress = p.fAddress;
                sb.Autobiography = p.fAutobiography;
                hello.SaveChanges();
            }
            return Content("修改成功");
        }
        public IActionResult CreateWork([FromBody]CStudentResumeViewModel p)
        {
            
            hello.StudentWorkExperiences.Add(p.workExperience);
            hello.SaveChanges();
            return Content("新增成功");
        }


    }
}
