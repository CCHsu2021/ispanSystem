﻿using Microsoft.AspNetCore.Mvc;
using MSITTeam1.Models;
using MSITTeam1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSITTeam1.Controllers
{
    public class ShowClassGradeController : Controller
    {
        private readonly helloContext hello;
        public ShowClassGradeController(helloContext _hello)
        {
            hello = _hello;
        }
        public IActionResult Index(GradeIdentify Grade)
        {
            ViewBag.txtidentify = Grade.txtidentify;
            ViewBag.count = 0;
            ViewBag.showavgself = 0;
                ViewBag.memType = CDictionary.memtype;
            if (CDictionary.account != null)
            {
                StudentBasic account = null;
                if (Grade.txtaccount == null)
                {
                    account = hello.StudentBasics.FirstOrDefault(c => c.MemberId == CDictionary.account);
                }
                else {
                    account = hello.StudentBasics.FirstOrDefault(c => c.FAccount == Grade.txtaccount);
                }
                TCompanyBasic comaccount = null;
                if (account == null)
                {
                    comaccount = hello.TCompanyBasics.FirstOrDefault(c => c.CompanyTaxid == CDictionary.account);
                    ViewBag.Account = comaccount.CompanyTaxid;
                }
                else
                {
                    ViewBag.Account = account.FAccount;
                }
                ViewBag.Identify = Grade.txtidentify;
                if (account != null)
                {
                    var maxcount = 0;
                    TClassGrade self = hello.TClassGrades.FirstOrDefault(c => c.FAccountId == account.FAccount && c.FClassCode == Grade.txtidentify);
                    if (self != null)
                    {
                        ViewBag.classname = hello.TClassInfos.FirstOrDefault(c => c.FClassExponent == Grade.txtidentify).FClassname;
                        ViewBag.showavgself = (self.FBeforeClassGrade + self.FAfterClassGrade) / 2;
                        int list = 0;
                        for (int i = 5; i <= 100; i += 10)
                        {
                            list = (from p in hello.TClassGrades
                                    where p.FClassCode == Grade.txtidentify && (p.FBeforeClassGrade + p.FAfterClassGrade) / 2 > (i - 5) && (p.FBeforeClassGrade + p.FAfterClassGrade) / 2 <= (i + 5)
                                    select p).Count();
                            if (maxcount < list)
                                maxcount = list;
                            if (i == 95)
                                ViewBag.showavg += list + "";
                            else
                                ViewBag.showavg += list + ",";
                        }
                    }
                    if (self != null)
                    {
                        ViewBag.showbeforeself = self.FBeforeClassGrade;
                        int list = 0;
                        for (int i = 5; i <= 100; i += 10)
                        {
                            list = (from p in hello.TClassGrades
                                    where p.FClassCode == Grade.txtidentify && p.FBeforeClassGrade > (i - 5) && p.FBeforeClassGrade <= (i + 5)
                                    select p).Count();
                            if (maxcount < list)
                                maxcount = list;
                            if (i == 95)
                                ViewBag.showbefore += list + "";
                            else
                                ViewBag.showbefore += list + ",";
                        }
                    }
                    if (self != null)
                    {
                        ViewBag.showAfterself = self.FAfterClassGrade;
                        int list = 0;
                        for (int i = 5; i <= 100; i += 10)
                        {
                            list = (from p in hello.TClassGrades
                                    where p.FClassCode == Grade.txtidentify && p.FAfterClassGrade > (i - 5) && p.FAfterClassGrade <= (i + 5)
                                    select p).Count();
                            if (maxcount < list)
                                maxcount = list;
                            if (i == 95)
                                ViewBag.showAfter += list + "";
                            else
                                ViewBag.showAfter += list + ",";
                        }
                    }
                    if (maxcount < 5)
                        maxcount = 5;
                    ViewBag.count = maxcount;
                    return View();

                }
                else
                {
                    var maxcount = 0;
                    var comselfSQL = from p in hello.TClassGrades
                                     join i in hello.StudentBasics on p.FAccountId equals i.FAccount
                                     join od in hello.TClassOrderDetails on i.MemberId equals od.MemberId
                                     join o in hello.TClassOrders on od.OrderId equals o.OrderId
                                     where o.MemberId == comaccount.CompanyTaxid && p.FClassCode == Grade.txtidentify
                                     group p by i.FCompany into g
                                     select new
                                     {
                                         FBeforeClassGrade = g.Sum(c => c.FBeforeClassGrade),
                                         FAfterClassGrade = g.Sum(c => c.FAfterClassGrade)
                                     };
                    var comself = comselfSQL.FirstOrDefault();
                    if (comself != null)
                    {
                        ViewBag.classname = hello.TClassInfos.FirstOrDefault(c => c.FClassExponent == Grade.txtidentify).FClassname;
                        ViewBag.showavgself = (comself.FBeforeClassGrade + comself.FAfterClassGrade) / 2;
                        int list = 0;
                        for (int i = 5; i <= 100; i += 10)
                        {
                            list = (from p in hello.TClassGrades
                                    where p.FClassCode == Grade.txtidentify && (p.FBeforeClassGrade + p.FAfterClassGrade) / 2 > (i - 5) && (p.FBeforeClassGrade + p.FAfterClassGrade) / 2 <= (i + 5)
                                    select p).Count();
                            if (maxcount < list)
                                maxcount = list;
                            if (i == 95)
                                ViewBag.showavg += list + "";
                            else
                                ViewBag.showavg += list + ",";
                        }
                        ViewBag.showbeforeself = comself.FBeforeClassGrade;
                        int list2 = 0;
                        for (int i = 5; i <= 100; i += 10)
                        {
                            list2 = (from p in hello.TClassGrades
                                     where p.FClassCode == Grade.txtidentify && p.FBeforeClassGrade > (i - 5) && p.FBeforeClassGrade <= (i + 5)
                                     select p).Count();
                            if (maxcount < list2)
                                maxcount = list2;
                            if (i == 95)
                                ViewBag.showbefore += list2 + "";
                            else
                                ViewBag.showbefore += list2 + ",";
                        }
                        ViewBag.showAfterself = comself.FAfterClassGrade;
                        int list3 = 0;
                        for (int i = 5; i <= 100; i += 10)
                        {
                            list3 = (from p in hello.TClassGrades
                                     where p.FClassCode == Grade.txtidentify && p.FAfterClassGrade > (i - 5) && p.FAfterClassGrade <= (i + 5)
                                     select p).Count();
                            if (maxcount < list3)
                                maxcount = list3;
                            if (i == 95)
                                ViewBag.showAfter += list3 + "";
                            else
                                ViewBag.showAfter += list3 + ",";
                        }
                    }

                    if (maxcount < 5)
                        maxcount = 5;
                    ViewBag.count = maxcount;
                    return View();
                }
            }
            return View();
        }
        public IActionResult Employee(GradeIdentify Grade)
        {
            if (CDictionary.memtype == "2")
            {
                var select = from p in hello.TClassGrades
                             join i in hello.StudentBasics on p.FAccountId equals i.FAccount
                             join od in hello.TClassOrderDetails on i.MemberId equals od.MemberId
                             join o in hello.TClassOrders on od.OrderId equals o.OrderId
                             where o.MemberId == CDictionary.account && p.FClassCode == Grade.txtidentify
                             select new classgradeselect
                             {
                                 account = i.FAccount,
                                 Name = i.Name
                             };
                return Json(select);
            }
            else
            {
                return Json(new { account = "" , Name =""});
            }
        }
    }
}
