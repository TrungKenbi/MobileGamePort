using GleamTech.AspNet.UI;
using GleamTech.FileUltimate.AspNet.UI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileGamePort.Controllers
{
    public class FileManagerController : Controller
    {
        public ActionResult Index([FromQuery(Name = "langCode")] string langCode, [FromQuery(Name = "Type")] string type)
        {
            var fileManager = new FileManager
            {
                DisplayLanguage = "en",
                DisplayMode = DisplayMode.Viewport,
                ClientEvents = new FileManagerClientEvents
                {
                    Chosen = "fileManagerChosen"
                },
                Chooser = true
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


            if (!string.IsNullOrEmpty(langCode))
                fileManager.DisplayLanguage = langCode;

            if (!string.IsNullOrEmpty(type))
                fileManager.InitialFolder = type + @":\";

            return View(fileManager);
        }
    }
}
