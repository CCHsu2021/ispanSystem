using Microsoft.AspNetCore.Mvc;
using MSITTeam1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSITTeam1.Controllers
{
    public class BuyPointController : Controller
    {
        private readonly helloContext hello;
        public BuyPointController(helloContext _hello)
        {
            hello = _hello;
        }
        public IActionResult Index()
        {
            var oid = hello.TPointOrders.Max(t => t.OrderId);
            string now = DateTime.Now.ToString("yyyyMMdd");
            if (oid != null)
            {
                int proid = int.Parse(oid.Substring(10, 5)) + 1;
                ViewBag.OrderId = "PO" + now + proid.ToString("00000");
            }
            else
            {
                ViewBag.OrderId = "PO"+ now + "00001";
            }
            return View();
        }
    }
}
