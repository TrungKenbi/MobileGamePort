using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MobileGamePort.Data;
using MobileGamePort.Models;

namespace MobileGamePort.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ScratchCardsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ScratchCardsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/ScratchCards
        public async Task<IActionResult> Index()
        {
            return View(await _context.ScratchCards.ToListAsync());
        }

        // GET: Admin/ScratchCards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scratchCard = await _context.ScratchCards
                .FirstOrDefaultAsync(m => m.Id == id);
            if (scratchCard == null)
            {
                return NotFound();
            }

            return View(scratchCard);
        }

        // GET: Admin/ScratchCards/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/ScratchCards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RequestId,Telco,Amount,Serial,Code,Money,Status,CreatedAt")] ScratchCard scratchCard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(scratchCard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(scratchCard);
        }

        // GET: Admin/ScratchCards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scratchCard = await _context.ScratchCards.FindAsync(id);
            if (scratchCard == null)
            {
                return NotFound();
            }
            return View(scratchCard);
        }

        // POST: Admin/ScratchCards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RequestId,Telco,Amount,Serial,Code,Money,Status,CreatedAt")] ScratchCard scratchCard)
        {
            if (id != scratchCard.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(scratchCard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScratchCardExists(scratchCard.Id))
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
            return View(scratchCard);
        }

        // GET: Admin/ScratchCards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scratchCard = await _context.ScratchCards
                .FirstOrDefaultAsync(m => m.Id == id);
            if (scratchCard == null)
            {
                return NotFound();
            }

            return View(scratchCard);
        }

        // POST: Admin/ScratchCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var scratchCard = await _context.ScratchCards.FindAsync(id);
            _context.ScratchCards.Remove(scratchCard);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScratchCardExists(int id)
        {
            return _context.ScratchCards.Any(e => e.Id == id);
        }
    }
}
