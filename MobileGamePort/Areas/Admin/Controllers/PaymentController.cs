using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobileGamePort.Controllers;
using MobileGamePort.Data;
using MobileGamePort.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace MobileGamePort.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class PaymentController : BaseController
    {
        private readonly ApplicationDbContext _context;

        public PaymentController(ApplicationDbContext context, UserManager<User> userManager) : base(userManager)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public async Task<IActionResult> History(int? page)
        {
            var links = (from items in _context.Recharges.Include(x => x.User).OrderByDescending(x => x.Id) select items).OrderBy(x => x.Id);
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(links.ToPagedList(pageNumber, pageSize));
        }
    }
}
