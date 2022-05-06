using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using MSITTeam1.Models;
using MSITTeam1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace MSITTeam1.Controllers
{
    public class ClassCheckOutController : Controller
    {
        private readonly helloContext hello;
        public ClassCheckOutController(helloContext _hello)
        {
            hello = _hello;
        }
            
        public IActionResult Index()
        {
            var oid = hello.TClassOrders.Max(t => t.OrderId);
            string now = DateTime.Now.ToString("yyyyMMdd");
            string newday = "C"+now + "00001";
            var newid = hello.TClassOrders.FirstOrDefault(t => t.OrderId == newday);
            if (oid != null)
            {
                if (newid != null) { 
                int proid = int.Parse(oid.Substring(9, 5)) + 1;
                ViewBag.OrderId = "C"+now + proid.ToString("00000");
                }
                else
                {
                    ViewBag.OrderId = newday;
                }
            }
            else
            {
                ViewBag.OrderId = "C"+now +"00001";
            }
            ViewBag.Name = CDictionary.username;
            ViewBag.Type = CDictionary.memtype;
            ViewBag.account = CDictionary.account;
            if (CDictionary.memtype == "1")
            {
                ViewBag.STel = hello.StudentBasics.FirstOrDefault(c => c.FAccount == CDictionary.account).Phone;
                var Scity = hello.StudentBasics.FirstOrDefault(c => c.FAccount == CDictionary.account).FCity;
                var Sdis = hello.StudentBasics.FirstOrDefault(c => c.FAccount == CDictionary.account).FDistrict;
                var Sadr = hello.StudentBasics.FirstOrDefault(c => c.FAccount == CDictionary.account).ContactAddress;
                ViewBag.SAddress = Scity + Sdis + Sadr;
                var Spoint = from o in hello.TStudentPoints
                            join i in hello.StudentBasics
                           on o.MemberId equals i.MemberId
                           select o.PointRecord;
                if (Spoint != null)
                {
                ViewBag.Point = Spoint.AsEnumerable().Sum();
                }
                else
                {
                    ViewBag.Point = 0;
                }
            }
            if (CDictionary.memtype == "2")
            {
                ViewBag.Tel = hello.TCompanyBasics.FirstOrDefault(c => c.CompanyTaxid == CDictionary.account).FPhone;
                var city = hello.TCompanyBasics.FirstOrDefault(c => c.CompanyTaxid == CDictionary.account).FCity;
                var dis = hello.TCompanyBasics.FirstOrDefault(c => c.CompanyTaxid == CDictionary.account).FDistrict;
                var adr = hello.TCompanyBasics.FirstOrDefault(c => c.CompanyTaxid == CDictionary.account).FAddress;
                ViewBag.Address = city + dis + adr;
            }
            var point = from o in hello.TCompanyPoints
                        join i in hello.TCompanyBasics
                       on o.CompanyTaxid equals i.CompanyTaxid
                        select o.PointRecord;
            if (point != null)
            {
                ViewBag.CPoint = point.AsEnumerable().Sum();
            }
            else
            {
                ViewBag.Point = 0;
            }
            string key = CDictionary.SK_ClASS_PURCHASED_LIST + CDictionary.account;
            if (HttpContext.Session.Keys.Contains(key))
            {
                string json = HttpContext.Session.GetString(key);
                List<ClassCheckOutViewModel> list = JsonSerializer.Deserialize<List<ClassCheckOutViewModel>>(json);
                return View(list);
            };
            return RedirectToAction("Index", "Index", null);
        }
        [HttpPost]
        public IActionResult ComfirmPay(ClassCheckOutViewModel vModel)
        {

            string key = CDictionary.SK_ClASS_PURCHASED_LIST + CDictionary.account;
            if (HttpContext.Session.Keys.Contains(key))
            {
                string json = HttpContext.Session.GetString(key);
                List<ClassCheckOutViewModel> list = JsonSerializer.Deserialize<List<ClassCheckOutViewModel>>(json);
                foreach(var i in list)
                {
                    TClassOrderDetail item = new TClassOrderDetail()
                    {
                        MemberId = CDictionary.account,
                        OrderId = vModel.OrderId,
                        ClassExponent = i.productId,
                        Price = i.price,
                        DepartmentName = vModel.DepartmentName,
                        StaffEmail= vModel.StaffEmail,
                        StaffName= vModel.StaffName
                    };
                    hello.TClassOrderDetails.Add(item);
                }
                HttpContext.Session.Remove(key);
            };
            hello.Add(vModel.order);
            hello.SaveChanges();
            return RedirectToAction("OrderCompleted", "CheckOut", new { id = vModel.OrderId });
        }
        public IActionResult OrderCompleted(string id)
        {
            ViewBag.Name = CDictionary.username;
            ViewBag.Type = CDictionary.memtype;
            ViewBag.account = CDictionary.account;
            ViewBag.id = id;
            return View();
        }
    }
}
