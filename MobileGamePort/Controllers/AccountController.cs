using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobileGamePort.Data;
using MobileGamePort.Models;

namespace MobileGamePort.Controllers
{
    [Authorize]
    public class AccountController : BaseController
    {
        private readonly ApplicationDbContext _context;
        public AccountController(ApplicationDbContext context, UserManager<User> userManager) : base(userManager)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewData["user"] = this.GetCurrentUser();
            return View(ViewData["user"]);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,Fullname,Email,PhoneNumber")] User user)
        {
            if (user == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    User realUser = await _context.Users.FindAsync(user.Id);
                    realUser.Fullname = user.Fullname;
                    realUser.Email = user.Email;
                    realUser.PhoneNumber = user.PhoneNumber;
                    _context.Update(realUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountExists(user.Id))
                    {
                        // return Redirect("/" + user.Id);
                        // return RedirectToAction(nameof(Index));
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(nameof(Index), user);
        }

        private bool AccountExists(string id)
        {
            return _context.Users.Any(e => e.Id.Equals(id));
        }
    }
}