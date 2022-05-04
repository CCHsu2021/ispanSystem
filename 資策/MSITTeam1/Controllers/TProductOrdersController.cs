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
    public class TProductOrdersController : Controller
    {
        private readonly helloContext _context;

        public TProductOrdersController(helloContext context)
        {
            _context = context;
        }

        // GET: TProductOrders
        public async Task<IActionResult> Index()
        {
            return View(await _context.TProductOrders.ToListAsync());
        }

        // GET: TProductOrders/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tProductOrder = await _context.TProductOrders
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (tProductOrder == null)
            {
                return NotFound();
            }

            return View(tProductOrder);
        }

        // GET: TProductOrders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TProductOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,MemberId,Date,TotalPrice,PayMethod,ShipBy,ShipTo,Invoice")] TProductOrder tProductOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tProductOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tProductOrder);
        }

        // GET: TProductOrders/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tProductOrder = await _context.TProductOrders.FindAsync(id);
            if (tProductOrder == null)
            {
                return NotFound();
            }
            return View(tProductOrder);
        }

        // POST: TProductOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("OrderId,MemberId,Date,TotalPrice,PayMethod,ShipBy,ShipTo,Invoice")] TProductOrder tProductOrder)
        {
            if (id != tProductOrder.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tProductOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TProductOrderExists(tProductOrder.OrderId))
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
            return View(tProductOrder);
        }

        // GET: TProductOrders/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tProductOrder = await _context.TProductOrders
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (tProductOrder == null)
            {
                return NotFound();
            }

            return View(tProductOrder);
        }

        // POST: TProductOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tProductOrder = await _context.TProductOrders.FindAsync(id);
            _context.TProductOrders.Remove(tProductOrder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TProductOrderExists(string id)
        {
            return _context.TProductOrders.Any(e => e.OrderId == id);
        }
    }
}
