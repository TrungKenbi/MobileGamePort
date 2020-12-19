using Microsoft.AspNetCore.Mvc;

namespace MobileGamePort.Controllers
{
    public class Payment : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}