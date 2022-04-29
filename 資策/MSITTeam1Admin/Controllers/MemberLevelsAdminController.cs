using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MSITTeam1Admin.Models;

namespace MSITTeam1Admin.Controllers
{
    public class MemberLevelsAdminController : Controller
    {
        private readonly helloContext _context;

        public MemberLevelsAdminController(helloContext context)
        {
            _context = context;
        }

        // GET: MemberLevelsAdmin
        public async Task<IActionResult> Index()
        {
            return View(await _context.TMemberLevels.ToListAsync());
        }

        // GET: MemberLevelsAdmin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tMemberLevel = await _context.TMemberLevels
                .FirstOrDefaultAsync(m => m.FLevel == id);
            if (tMemberLevel == null)
            {
                return NotFound();
            }

            return View(tMemberLevel);
        }

        // GET: MemberLevelsAdmin/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MemberLevelsAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FLevel,Title,BonusPercent")] TMemberLevel tMemberLevel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tMemberLevel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tMemberLevel);
        }

        // GET: MemberLevelsAdmin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tMemberLevel = await _context.TMemberLevels.FindAsync(id);
            if (tMemberLevel == null)
            {
                return NotFound();
            }
            return View(tMemberLevel);
        }

        // POST: MemberLevelsAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FLevel,Title,BonusPercent")] TMemberLevel tMemberLevel)
        {
            if (id != tMemberLevel.FLevel)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tMemberLevel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TMemberLevelExists(tMemberLevel.FLevel))
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
            return View(tMemberLevel);
        }

        // GET: MemberLevelsAdmin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tMemberLevel = await _context.TMemberLevels
                .FirstOrDefaultAsync(m => m.FLevel == id);
            if (tMemberLevel == null)
            {
                return NotFound();
            }

            return View(tMemberLevel);
        }

        // POST: MemberLevelsAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tMemberLevel = await _context.TMemberLevels.FindAsync(id);
            _context.TMemberLevels.Remove(tMemberLevel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TMemberLevelExists(int id)
        {
            return _context.TMemberLevels.Any(e => e.FLevel == id);
        }
    }
}
