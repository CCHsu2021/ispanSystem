using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MSITTeam1.Models;
using MSITTeam1.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MSITTeam1.Controllers
{
    public class CMemberCenterController : Controller
    {
        private readonly helloContext hello;
        IWebHostEnvironment _enviroment;

        public CMemberCenterController(helloContext _hello, IWebHostEnvironment p )
        {
            hello = _hello;
            _enviroment = p;
        }
        public IActionResult Index()
        {
            ViewBag.Name = CDictionary.username;
            ViewBag.Type = CDictionary.memtype;
            ViewBag.account = CDictionary.account;
            return View();
        }


        //更新公司基本資料
        [HttpPost]
        public IActionResult CompanyInformationEdit(CCompanyBasicViewModel company)
        {
            TCompanyBasic c = hello.TCompanyBasics.FirstOrDefault(p => p.CompanyTaxid == company.CompanyTaxid);
            if (c != null)
            {
                c.FAddress = company.FAddress;
                c.FCity = company.FCity;
                c.FDistrict = company.FDistrict;
                c.FEmail = company.FEmail;
                c.FFaxCode = company.FFaxCode;
                c.FFax = company.FFax;
                c.FPhoneCode = company.FPhoneCode;
                c.FPhone = company.FPhone;
                c.FContactPerson = company.FContactPerson;
                c.FBenefits = company.FBenefits;
                c.FCustomInfo = company.FCustomInfo;
                c.FCapitalAmount = company.FCapitalAmount;
                c.FWebsite = company.FWebsite;
                c.FRelatedLink = company.FRelatedLink;
                c.FDistrictCode = company.FDistrictCode;
                hello.SaveChanges();
            }
            return Content("success");
        }

        //LOGO存取
        [HttpPost]
        public IActionResult SaveLogoPicture(IFormFile img,string id)
        {
            TCompanyBasic c = hello.TCompanyBasics.FirstOrDefault(p => p.CompanyTaxid == id);
            string photoName = Guid.NewGuid().ToString() + ".jpg";
            c.FLogo = photoName;
            img.CopyTo(new FileStream(
                _enviroment.WebRootPath + @"\images\company\" + photoName, FileMode.Create));
            hello.SaveChanges();
            return Json(new { suc="ok"});
        }

        [HttpPost]
        public IActionResult SaveFile(IFormFile file,string id)
        {
            var ph = (from p in hello.TPhotos where p.FAccount == id select p).Count();
            if (ph > 7)
            {
                return Json(new { err = "超過張數"});
            }
            string photoName = Guid.NewGuid().ToString() + ".jpg";
            using (FileStream fs = new FileStream(_enviroment.WebRootPath + @"\images\company\" + photoName,FileMode.Create))
            {
                file.CopyTo(fs);
                TPhoto photo = new TPhoto()
                {
                    FAccount = id,
                    FPhoto = photoName,
                };
                hello.TPhotos.Add(photo);
                hello.SaveChanges();
            }
            return Json(new { suc = "上傳成功"});
        }
        [HttpPost]
        public IActionResult DeleteFile()
        {
            Array filename = Request.Form["filename[]"];
            if (filename != null)
            {
                foreach(var i in filename)
                {
                    FileInfo file = new FileInfo(_enviroment.WebRootPath + @"\images\company\" + i);
                    if (file.Exists)
                    {
                        file.Delete();
                    }
                    TPhoto photo = hello.TPhotos.FirstOrDefault(p => p.FPhoto == i.ToString());
                    if (photo != null)
                    {
                        hello.TPhotos.Remove(photo);
                    }
                }
                hello.SaveChanges();
                return Content("Deleted");
            }
            return Content("fail");
        }
        public IActionResult CreateJobVacancy()
        {
            return View();
        }

    }
}
