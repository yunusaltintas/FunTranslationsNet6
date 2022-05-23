using FunTranslation.Presentation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FunTranslation.Presentation.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [Route("/Error")]
        [HttpGet]
        public IActionResult Error()
        {
            var ErrorInfo = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            //var logger = LogManager.GetLogger("FileLogger");
            //logger.Log(NLog.LogLevel.Error, $"\nHatanın Gerçekleştiği yer:{ErrorInfo.Path}\nHata Mesajı: {ErrorInfo.Error.Message}\nStack Trace:{ErrorInfo.Error.StackTrace}");
            return View();
        }

        [HttpGet]
        public IActionResult NotFound(int code)
        {
            ViewBag.Code = code;

            return View();
        }
    }
}