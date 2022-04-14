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
        public IActionResult CompanyInformationEdit(String CompanyTaxid)
        {
            TCompanyBasic c = hello.TCompanyBasics.FirstOrDefault(p => p.CompanyTaxid == CompanyTaxid);
            if (c != null)
            {
                return View(new CCompanyBasicViewModel() { com = c });
            }

            return View();
        }
        [HttpPost]
        public IActionResult CompanyInformationEdit([FromBody]CCompanyBasicViewModel company)
        {
            TCompanyBasic c = hello.TCompanyBasics.FirstOrDefault(p => p.CompanyTaxid == company.CompanyTaxid);
            if (c != null)
            {
                if (company.FLogo != null)
                {
                    string photoName = Guid.NewGuid().ToString() + ".jpg";
                    c.FLogo = photoName;
                    company.photo.CopyTo(new FileStream(_enviroment.WebRootPath + @"\UploadImage\" + photoName,FileMode.Create));
                }
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
                hello.SaveChanges();
            }
            return Content("success");
        }
        [HttpPost]
        public JsonResult GetCityByCityGroup(string selectedCity)
        {
            var districtlist = from c in hello.TCityContrasts where c.FCityName == selectedCity select c;
            return Json(districtlist);
        }
    }
}
