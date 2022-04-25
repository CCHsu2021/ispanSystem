using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        #region 會員基本資料Edit
        [AllowAnonymous]
        public IActionResult Edit([FromBody] CStudentResumeViewModel p)
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
                sb.Gender = p.fGender.Equals("男") ? "0" : p.fGender.Equals("女") ? "1" : "2";
                sb.BirthDate = p.fBirthDate;
                sb.Email = p.fEmail;
                sb.Phone = p.fPhone;
                sb.ContactAddress = p.fAddress;
                sb.Autobiography = p.fAutobiography;
                hello.SaveChanges();
            }
            return Content("修改成功");
        }
        #endregion

        #region 製作履歷主頁
        [AllowAnonymous]
        public IActionResult Create()
        {

            string account = CDictionary.account;
            if (account != null)
            {

                StudentBasic sb = hello.StudentBasics.FirstOrDefault(c => c.MemberId == (string)account);
                if (sb != null)
                    return View(new CStudentResumeViewModel() { student = sb });

            }

            return View();
        }


        #endregion

        #region 儲存基本資料
        [HttpPost]
        public IActionResult EditBasic(CStudentResumeViewModel p)
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
                sb.Gender = p.fGender;
                sb.BirthDate = p.fBirthDate;
                sb.Email = p.fEmail;
                sb.Phone = p.fPhone;
                sb.FCity = p.fCity;
                sb.FDistrict = p.fDistrict;
                sb.ContactAddress = p.fAddress;
                sb.Autobiography = p.fAutobiography;
                hello.SaveChanges();
            }
            return Content("修改成功");
        }
        #endregion

        //[AllowAnonymous]
        //public IActionResult Edit(string? id)
        //{
        //    if (id != null)
        //    {

        //        StudentBasic sb = hello.StudentBasics.FirstOrDefault(c => c.MemberId == (string)id);
        //        if (sb != null)
        //            return View(new CStudentResumeViewModel() { student = sb, fGender = sb.Gender.Equals("0") ? "男" : sb.Gender.Equals("1") ? "女" : "未指定" });
        //    }
        //    return RedirectToAction("Create");
        //}

        #region  工作經歷 Create Edit Delete
        [HttpPost]
        public IActionResult CreateWork([FromBody] CStudentResumeViewModel p)
        {

            hello.StudentWorkExperiences.Add(p.workExperience);
            hello.SaveChanges();
            return Content("新增成功");
        }

        [HttpPost]
        public IActionResult EditWork([FromBody] CStudentResumeViewModel p)
        {
            StudentWorkExperience sw = hello.StudentWorkExperiences.FirstOrDefault(c => c.WorkExperienceId == p.WorkExperienceId);
            if (sw != null)
            {
                sw.CompanyName = p.CompanyName;
                sw.CompanyDepartment = p.CompanyDepartment;
                sw.JobTitle = p.JobTitle;
                sw.EmploymentFrom = p.EmploymentFrom;
                sw.EmploymentTo = p.EmploymentTo;
                sw.JobDescription = p.JobDescription;
                hello.SaveChanges();
            }
            return Content("修改成功");
        }


        public IActionResult DeleteWork(String WorkExperienceId)
        {

            StudentWorkExperience sw = hello.StudentWorkExperiences.FirstOrDefault(c => c.WorkExperienceId.ToString() == WorkExperienceId);
            if (sw != null)
            {
                hello.StudentWorkExperiences.Remove(sw);
                hello.SaveChanges();
            }

            return Content("刪除成功");
        }

        #endregion

        public IActionResult CreateEdu([FromBody] CStudentResumeViewModel p)
        {
            hello.StudentEducations.Add(p.education);
            hello.SaveChanges();
            return Content("新增成功");
        }

        public IActionResult EditEdu([FromBody] CStudentResumeViewModel p)
        {
            StudentEducation sw = hello.StudentEducations.FirstOrDefault(c => c.EducationId == p.EducationId);
            if (sw != null)
            {
                sw.GraduateSchool = p.GraduateSchool;
                sw.GraduateDepartment = p.GraduateDepartment;
                sw.StudyFrom = p.StudyFrom;
                sw.StudyTo = p.StudyTo;
                hello.SaveChanges();
            }
            return Content("修改成功");
        }

        public IActionResult DeleteEdu(String EducationId)
        {

            StudentEducation sw = hello.StudentEducations.FirstOrDefault(c => c.EducationId.ToString() == EducationId);
            if (sw != null)
            {
                hello.StudentEducations.Remove(sw);
                hello.SaveChanges();
            }

            return Content("刪除成功");
        }

        public IActionResult CreateLan([FromBody] CStudentResumeViewModel p)
        {
            hello.StudentLanguages.Add(p.language);
            hello.SaveChanges();
            return Content("新增成功");
        }

        public IActionResult EditLan([FromBody] CStudentResumeViewModel p)
        {
            StudentLanguage sw = hello.StudentLanguages.FirstOrDefault(c => c.LanguageId == p.LanguageId);
            if (sw != null)


            sw.LanguageName = p.LanguageName;
            sw.Listening = determine(p.Listening);
            sw.Speaking = determine( p.Speaking);
            sw.Reading =  determine(p.Reading);
            sw.Writing =  determine(p.Writing);
            hello.SaveChanges();

            return Content("修改成功");
        }

        public string determine(string a)
        {
            if (a == "初階")
                return "0";
            if (a == "中等")
                return "1";
            if (a == "高階")
                return "2";
            if (a == "母語")
                return "3";
            return "4";
        }

        public IActionResult DeleteLan(String LanguageId)
        {

            StudentLanguage sw = hello.StudentLanguages.FirstOrDefault(c => c.LanguageId.ToString() == LanguageId);
            if (sw != null)
            {
                hello.StudentLanguages.Remove(sw);
                hello.SaveChanges();
            }

            return Content("刪除成功");
        }


    }
}
