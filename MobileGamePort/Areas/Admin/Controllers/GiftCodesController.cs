using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MobileGamePort.Data;
using MobileGamePort.Models;

namespace MobileGamePort.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class GiftCodesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GiftCodesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/GiftCodes
        public async Task<IActionResult> Index()
        {
            return View(await _context.GiftCode.ToListAsync());
        }

        // GET: Admin/GiftCodes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giftCode = await _context.GiftCode
                .FirstOrDefaultAsync(m => m.Id == id);
            if (giftCode == null)
            {
                return NotFound();
            }

            return View(giftCode);
        }

        // GET: Admin/GiftCodes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/GiftCodes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Code,Money,CreatedAt")] GiftCode giftCode)
        {
            if (ModelState.IsValid)
            {
                _context.Add(giftCode);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(giftCode);
        }

        // GET: Admin/GiftCodes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giftCode = await _context.GiftCode.FindAsync(id);
            if (giftCode == null)
            {
                return NotFound();
            }
            return View(giftCode);
        }

        // POST: Admin/GiftCodes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Code,Money,CreatedAt")] GiftCode giftCode)
        {
            if (id != giftCode.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(giftCode);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GiftCodeExists(giftCode.Id))
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
            return View(giftCode);
        }

        // GET: Admin/GiftCodes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giftCode = await _context.GiftCode
                .FirstOrDefaultAsync(m => m.Id == id);
            if (giftCode == null)
            {
                return NotFound();
            }

            return View(giftCode);
        }

        // POST: Admin/GiftCodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var giftCode = await _context.GiftCode.FindAsync(id);
            _context.GiftCode.Remove(giftCode);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GiftCodeExists(int id)
        {
            return _context.GiftCode.Any(e => e.Id == id);
        }
    }
}
