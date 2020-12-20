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
    public class RechargesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RechargesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Recharges
        public async Task<IActionResult> Index()
        {
            return View(await _context.Recharges.ToListAsync());
        }

        // GET: Admin/Recharges/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recharge = await _context.Recharges
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recharge == null)
            {
                return NotFound();
            }

            return View(recharge);
        }

        // GET: Admin/Recharges/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Recharges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Amount,Type,Money,CreatedAt")] Recharge recharge)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recharge);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recharge);
        }

        // GET: Admin/Recharges/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recharge = await _context.Recharges.FindAsync(id);
            if (recharge == null)
            {
                return NotFound();
            }
            return View(recharge);
        }

        // POST: Admin/Recharges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Amount,Type,Money,CreatedAt")] Recharge recharge)
        {
            if (id != recharge.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recharge);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RechargeExists(recharge.Id))
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
            return View(recharge);
        }

        // GET: Admin/Recharges/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recharge = await _context.Recharges
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recharge == null)
            {
                return NotFound();
            }

            return View(recharge);
        }

        // POST: Admin/Recharges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recharge = await _context.Recharges.FindAsync(id);
            _context.Recharges.Remove(recharge);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RechargeExists(int id)
        {
            return _context.Recharges.Any(e => e.Id == id);
        }
    }
}
