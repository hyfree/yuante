using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoreNote.Common.Utils;
using MoreNote.Logic.Entity;
using yuante.Models;

namespace yuante.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            return Content("远特车机后台模拟软件 V0.0.1");
            
        }

    

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [Route("/api/1.0/app/[action]")]
        public IActionResult getlist()
        {

            var db= MyDB.ReadJsonFile();
            AppInfo[] appInfos = db.AppInfos;
            APPStoreInfo aPPStoreInfoList = new APPStoreInfo()
            {
                resp_data = new Resp_Data()
                {
                    app_list = appInfos
                }
            };

            return Json(aPPStoreInfoList, MyJsonConvert.GetOptions());

        }
        [Route("/api/1.0/app/update/callback/[action]")]
        public IActionResult callback()
        {

            return Content("callback");
        }
    }
}
