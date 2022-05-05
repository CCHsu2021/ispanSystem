using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MSITTeam1.Models;
using MSITTeam1.ViewModels;

namespace MSITTeam1.Controllers
{
    public class PostMessageController : Controller
    {
        private readonly helloContext _context;

        public PostMessageController(helloContext context)
        {
            _context = context;
        }

        // GET: PostMessage
        public IActionResult Index()
        {
            //todo 目前這邊登入資料寫死
            string account = "222";
            ViewBag.account = account;
            var companyResumeReceive = from p in _context.TMemberResumeSends
                                       join t in _context.TCompanyBasics on p.CompanyTaxid equals t.CompanyTaxid into pt
                                       from combin in pt.DefaultIfEmpty()
                                       join s in _context.StudentBasics on p.MemberId equals s.MemberId into ps
                                       from combin2 in ps.DefaultIfEmpty()
                                       where p.CompanyTaxid.Equals(account)
                                       orderby p.CreatTime descending
                                       select new
                                       {
                                           p,
                                           combin.FName,
                                           combin2.Name
                                       };
            List<TCompanyResumeReceiveViewModel> list = new List<TCompanyResumeReceiveViewModel>();
            foreach (var item in companyResumeReceive)
            {
                TCompanyResumeReceiveViewModel vModel = new TCompanyResumeReceiveViewModel();
                vModel.memRS = item.p;
                vModel.FCompanyName = item.FName;
                vModel.FStudentName = item.Name;
                list.Add(vModel);
            }

            return View(list);
        }
        public IActionResult StudentResumeDetail(string ResumeSendId)
        {
            var chooseOne = (from p in _context.TMemberResumeSends
                             join t in _context.TCompanyBasics on p.CompanyTaxid equals t.CompanyTaxid into pt
                             from combin in pt.DefaultIfEmpty()
                             join s in _context.StudentBasics on p.MemberId equals s.MemberId into ps
                             from combin2 in ps.DefaultIfEmpty()
                             select new TCompanyResumeReceiveViewModel
                             {
                                 memRS = p,
                                 FCompanyName = combin.FName,
                                 FStudentName = combin2.Name
                             }).FirstOrDefault(p => p.ResumeSendId.Equals(ResumeSendId));
            chooseOne.ComReadOrNot = "已讀";

            return View(chooseOne);
            //todo 尚未做成View的格式，套用檢視職缺頁面
        }

        // GET: PostMessage/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tMemberResumeSend = await _context.TMemberResumeSends
                .FirstOrDefaultAsync(m => m.ResumeSendId == id);
            if (tMemberResumeSend == null)
            {
                return NotFound();
            }

            return View(tMemberResumeSend);
        }

        // GET: PostMessage/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PostMessage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ResumeSendId,ResumeId,MemberId,CompanyTaxid,JobName,ContactPhone,ContactEmail,ComReadOrNot,TimeToContact,CoverLetter,CreatTime,ModifyTime")] TMemberResumeSend tMemberResumeSend)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tMemberResumeSend);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tMemberResumeSend);
        }

        // GET: PostMessage/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tMemberResumeSend = await _context.TMemberResumeSends.FindAsync(id);
            if (tMemberResumeSend == null)
            {
                return NotFound();
            }
            return View(tMemberResumeSend);
        }

        // POST: PostMessage/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ResumeSendId,ResumeId,MemberId,CompanyTaxid,JobName,ContactPhone,ContactEmail,ComReadOrNot,TimeToContact,CoverLetter,CreatTime,ModifyTime")] TMemberResumeSend tMemberResumeSend)
        {
            if (id != tMemberResumeSend.ResumeSendId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tMemberResumeSend);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TMemberResumeSendExists(tMemberResumeSend.ResumeSendId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tMemberResumeSend);
        }

        // GET: PostMessage/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tMemberResumeSend = await _context.TMemberResumeSends
                .FirstOrDefaultAsync(m => m.ResumeSendId == id);
            if (tMemberResumeSend == null)
            {
                return NotFound();
            }

            return View(tMemberResumeSend);
        }

        // POST: PostMessage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tMemberResumeSend = await _context.TMemberResumeSends.FindAsync(id);
            _context.TMemberResumeSends.Remove(tMemberResumeSend);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TMemberResumeSendExists(string id)
        {
            return _context.TMemberResumeSends.Any(e => e.ResumeSendId == id);
        }
    }
}
