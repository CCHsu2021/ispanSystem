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
            ViewBag.count = 0;
            if (CDictionary.memtype != null)
                ViewBag.memType = 0;
            else
                ViewBag.memType = CDictionary.memtype;
            if (CDictionary.account != null)
            {
                var account = hello.StudentBasics.FirstOrDefault(c => c.MemberId == CDictionary.account);
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
                    var comself = from p in hello.TClassGrades
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
                    if (comself.FirstOrDefault() != null)
                    {
                        foreach (var obj in comself)
                        {
                            ViewBag.classname = hello.TClassInfos.FirstOrDefault(c => c.FClassExponent == Grade.txtidentify).FClassname;
                            ViewBag.showavgself = (obj.FBeforeClassGrade + obj.FAfterClassGrade) / 2;
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
                    }
                    if (comself.FirstOrDefault() != null)
                    {
                        foreach (var obj in comself)
                        {
                            ViewBag.showbeforeself = obj.FBeforeClassGrade;
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
                    }
                    if (comself.FirstOrDefault() != null)
                    {
                        foreach (var obj in comself)
                        {
                            ViewBag.showAfterself = obj.FAfterClassGrade;
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
                    }
                    if (maxcount < 5)
                        maxcount = 5;
                    ViewBag.count = maxcount;
                    return View();
                }
            }
            return View();
        }
    }
}
