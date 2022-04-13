﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MSITTeam1.Models;
using MSITTeam1.ViewModels;

namespace MSITTeam1.Controllers
{
    public class TJobVacanciesController : Controller
    {
        private readonly helloContext _context;
        //private readonly TJobVacanciesViewModel _jobVacancyVM;

        public TJobVacanciesController(helloContext context)
        {
            _context = context;
        }

        // GET: TJobVacancies
        public IActionResult Index()
        {
            IEnumerable<TJobVacanciesViewModel> list = null;

            //LINQ，TNewJobVacancies left join TCompanyBasics
            list = from p in _context.TNewJobVacancies
                       join t in _context.TCompanyBasics on p.FCompanyTaxid equals t.CompanyTaxid into pt
                       from combin in pt.DefaultIfEmpty()
                       join s in _context.TJobDirects on p.FJobListId equals s.JobListId into ps
                       from combin2 in ps.DefaultIfEmpty()
                       select new TJobVacanciesViewModel()
                       {
                           jobV = p,
                           FCompanyName = combin.FName,
                           FCompanyLogo = combin.FLogo,
                           FJobDirect = combin2.FJobDirect
                       };
            return View(list);

            //var helloContext = _context.TJobVacancies.Include(t => t.F).Include(t => t.FAccountNavigation).Include(t => t.FJoblist);
            //return View(await helloContext.ToListAsync());
        }
        [HttpPost]
        public IActionResult Index(FormCollection post) //todo 接收搜尋欄等post過來的資料，是否可以另建ViewModel來用偷雞摸狗法。
        {
            return View();
        }

        // GET: TJobVacancies/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tJobVacancy = await _context.TJobVacancies
                .Include(t => t.F)
                .Include(t => t.FAccountNavigation)
                .Include(t => t.FJoblist)
                .FirstOrDefaultAsync(m => m.FJobId == id);
            if (tJobVacancy == null)
            {
                return NotFound();
            }

            return View(tJobVacancy);
        }


        // POST: TJobVacancies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var tJobVacancy = await _context.TJobVacancies.FindAsync(id);
            _context.TJobVacancies.Remove(tJobVacancy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TJobVacancyExists(long id)
        {
            return _context.TJobVacancies.Any(e => e.FJobId == id);
        }

        //// GET: TJobVacancies/Create
        //public IActionResult Create()
        //{
        //    ViewData["FCity"] = new SelectList(_context.TCityContrasts, "FCityName", "FCityName");
        //    ViewData["FAccount"] = new SelectList(_context.TCompanyBasics, "FAccount", "FAccount");
        //    ViewData["FJoblistId"] = new SelectList(_context.TJobDirects, "JobListId", "FClass");
        //    return View();
        //}

        //// POST: TJobVacancies/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("FJobId,FJoblistId,FCompanyId,FAccount,FSalaryMode,FSalary,FEmployeesType,FWorkAddress,FPostCode,FCity,FDistrict,FWorkHours,FLeaveSystem,FWorkExp,FEducation,FOther,FNeedPerson,FJobName,FLanguage")] TJobVacancy tJobVacancy)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(tJobVacancy);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["FCity"] = new SelectList(_context.TCityContrasts, "FCityName", "FCityName", tJobVacancy.FCity);
        //    ViewData["FAccount"] = new SelectList(_context.TCompanyBasics, "FAccount", "FAccount", tJobVacancy.FAccount);
        //    ViewData["FJoblistId"] = new SelectList(_context.TJobDirects, "JobListId", "FClass", tJobVacancy.FJoblistId);
        //    return View(tJobVacancy);
        //}

        //// GET: TJobVacancies/Edit/5
        //public async Task<IActionResult> Edit(long? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var tJobVacancy = await _context.TJobVacancies.FindAsync(id);
        //    if (tJobVacancy == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["FCity"] = new SelectList(_context.TCityContrasts, "FCityName", "FCityName", tJobVacancy.FCity);
        //    ViewData["FAccount"] = new SelectList(_context.TCompanyBasics, "FAccount", "FAccount", tJobVacancy.FAccount);
        //    ViewData["FJoblistId"] = new SelectList(_context.TJobDirects, "JobListId", "FClass", tJobVacancy.FJoblistId);
        //    return View(tJobVacancy);
        //}

        //// POST: TJobVacancies/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(long id, [Bind("FJobId,FJoblistId,FCompanyId,FAccount,FSalaryMode,FSalary,FEmployeesType,FWorkAddress,FPostCode,FCity,FDistrict,FWorkHours,FLeaveSystem,FWorkExp,FEducation,FOther,FNeedPerson,FJobName,FLanguage")] TJobVacancy tJobVacancy)
        //{
        //    if (id != tJobVacancy.FJobId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(tJobVacancy);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!TJobVacancyExists(tJobVacancy.FJobId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["FCity"] = new SelectList(_context.TCityContrasts, "FCityName", "FCityName", tJobVacancy.FCity);
        //    ViewData["FAccount"] = new SelectList(_context.TCompanyBasics, "FAccount", "FAccount", tJobVacancy.FAccount);
        //    ViewData["FJoblistId"] = new SelectList(_context.TJobDirects, "JobListId", "FClass", tJobVacancy.FJoblistId);
        //    return View(tJobVacancy);
        //}

        //// GET: TJobVacancies/Delete/5
        //public async Task<IActionResult> Delete(long? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var tJobVacancy = await _context.TJobVacancies
        //        .Include(t => t.F)
        //        .Include(t => t.FAccountNavigation)
        //        .Include(t => t.FJoblist)
        //        .FirstOrDefaultAsync(m => m.FJobId == id);
        //    if (tJobVacancy == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(tJobVacancy);
        //}
    }
}
