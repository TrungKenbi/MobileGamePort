using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MobileGamePort.Models;

namespace MobileGamePort.Controllers
{
    [Authorize]
    public class AccountController : BaseController
    {
        public AccountController(UserManager<User> userManager) : base(userManager)
        {
        }
        public IActionResult Index()
        {
            ViewData["user"] = this.GetCurrentUser();
            return View();
        }
    }
}