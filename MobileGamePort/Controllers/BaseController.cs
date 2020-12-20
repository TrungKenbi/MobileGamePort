using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MobileGamePort.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileGamePort.Controllers
{
    public class BaseController : Controller
    {
        protected UserManager<User> _userManager;
        public BaseController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public User GetCurrentUser()
        {
            var user = _userManager.GetUserAsync(User).Result;
            return user;
        }
    }
}
