using Microsoft.AspNetCore.Mvc;
using MSITTeam1.Models;
using MSITTeam1.ViewModels;
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
            ViewBag.Name = CDictionary.username;
            ViewBag.Type = CDictionary.memtype;
            ViewBag.account = CDictionary.account;
            if (ViewBag.Type == "2")
            {
                ViewBag.Bonus = (float)(hello.TMemberLevels.FirstOrDefault(m => m.FLevel == hello.TCompanyBasics.FirstOrDefault(t => t.CompanyTaxid == CDictionary.account).FLevel).BonusPercent);
            }
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
        [HttpPost]
        public IActionResult ComfirmBuy(CPointOrderViewModel vModel,string orderId)
        {
            ViewBag.Name = CDictionary.username;
            ViewBag.Type = CDictionary.memtype;
            ViewBag.account = CDictionary.account;
            string title = hello.TMemberLevels.FirstOrDefault(l => l.FLevel == hello.TCompanyBasics.FirstOrDefault(m => m.CompanyTaxid == CDictionary.account).FLevel).Title;
            string bonus = ((hello.TMemberLevels.FirstOrDefault(l => l.FLevel == hello.TCompanyBasics.FirstOrDefault(m => m.CompanyTaxid == CDictionary.account).FLevel).BonusPercent)*100).ToString();
            TCompanyPoint item = new TCompanyPoint
            {
                CompanyTaxid = CDictionary.account,
                PointType = "點數購買",
                PointDescription = $"訂單號碼：{orderId}，購買點數{vModel.BuyPoint}點，{title}回饋{bonus}%，一共獲得{vModel.ToTalGetPoint}點",
                PointRecord = vModel.ToTalGetPoint,
                OrderId = orderId
            };
            hello.Add(vModel.Porder);
            hello.TCompanyPoints.Add(item);
            hello.SaveChanges();

            var totalCost = from p in hello.TPointOrders
                            join c in hello.TCompanyBasics on p.CompanyTaxid equals c.CompanyTaxid
                            where p.CompanyTaxid == CDictionary.account
                            select p.ToTalGetPoint;
            var levelUp = totalCost.AsEnumerable().Sum();
            var mem = hello.TCompanyBasics.FirstOrDefault(m => m.CompanyTaxid == CDictionary.account);
            if (mem != null)
            {
                if (levelUp  < 200000)
                {
                    mem.FLevel = 1;
                }
                if (levelUp >= 200000 && levelUp < 300000)
                {
                    mem.FLevel = 2;
                }
                if (levelUp >= 300000 && levelUp < 500000)
                {
                    mem.FLevel = 3;
                }
                if (levelUp >= 500000 )
                {
                    mem.FLevel = 4;
                }
                hello.SaveChanges();
            };
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
