using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MSITTeam1.Models;

namespace MSITTeam1.Controllers
{
    public class TestPaperBanksController : Controller
    {
        private readonly helloContext _context;

        public TestPaperBanksController(helloContext context)
        {
            _context = context;
        }

        // GET: TTestPaperBanks
        public async Task<IActionResult> Index()
        {
            return View(await _context.TTestPaperBanks.ToListAsync());
        }

        // GET: TTestPaperBanks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tTestPaperBank = await _context.TTestPaperBanks
                .FirstOrDefaultAsync(m => m.FTestPaperId == id);
            if (tTestPaperBank == null)
            {
                return NotFound();
            }

            return View(tTestPaperBank);
        }

        // GET: TTestPaperBanks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TTestPaperBanks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FTestPaperId,FDesignerAccount,FTestPaperName,FSubjectId,FNote")] TTestPaperBank tTestPaperBank)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tTestPaperBank);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tTestPaperBank);
        }

        // GET: TTestPaperBanks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tTestPaperBank = await _context.TTestPaperBanks.FindAsync(id);
            if (tTestPaperBank == null)
            {
                return NotFound();
            }
            return View(tTestPaperBank);
        }

        // POST: TTestPaperBanks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FTestPaperId,FDesignerAccount,FTestPaperName,FSubjectId,FNote")] TTestPaperBank tTestPaperBank)
        {
            if (id != tTestPaperBank.FTestPaperId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tTestPaperBank);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TTestPaperBankExists(tTestPaperBank.FTestPaperId))
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
            return View(tTestPaperBank);
        }

        // GET: TTestPaperBanks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tTestPaperBank = await _context.TTestPaperBanks
                .FirstOrDefaultAsync(m => m.FTestPaperId == id);
            if (tTestPaperBank == null)
            {
                return NotFound();
            }

            return View(tTestPaperBank);
        }

        // POST: TTestPaperBanks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tTestPaperBank = await _context.TTestPaperBanks.FindAsync(id);
            _context.TTestPaperBanks.Remove(tTestPaperBank);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TTestPaperBankExists(int id)
        {
            return _context.TTestPaperBanks.Any(e => e.FTestPaperId == id);
        }
    }
}
