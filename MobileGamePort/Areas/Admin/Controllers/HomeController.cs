using GleamTech.AspNet.UI;
using GleamTech.FileUltimate.AspNet.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileGamePort.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult FileManager()
        {
            var fileManager = new FileManager
            {
                DisplayLanguage = "en",
                DisplayMode = DisplayMode.Viewport
            };

            var rootFolderFiles = new FileManagerRootFolder
            {
                Name = "Root",
                Location = "~/filemanager/root"
            };

            rootFolderFiles.AccessControls.Add(new FileManagerAccessControl
            {
                Path = @"\",
                AllowedPermissions = FileManagerPermissions.Full
            });


            fileManager.RootFolders.Add(rootFolderFiles);

            return View(fileManager);
        }
    }
}
