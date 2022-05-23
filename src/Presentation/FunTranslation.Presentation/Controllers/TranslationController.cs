using AutoMapper;
using FunTranslation.Application.Interfaces.IService;
using FunTranslation.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace FunTranslation.Presentation.Controllers
{
    [AllowAnonymous]
    public class TranslationController : Controller
    {
        private readonly IServiceManager _serviceManager;
        private readonly IMapper _mapper;

        public TranslationController(IServiceManager serviceManager, IMapper mapper)
        {
            _serviceManager = serviceManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            TranslateViewModel model = new TranslateViewModel();
            await FillSelectListItem();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(TranslateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                await FillSelectListItem();
                return View();
            }

            await FillSelectListItem();

            var addedResult = await _serviceManager.PastTranslationService.Translate(model);

            var jsonResult = JsonConvert.SerializeObject(addedResult);

            return Json(jsonResult);
        }

        private async Task FillSelectListItem()
        {
            var result = await _serviceManager.LanguageService.GetAllAsync();
            var values = (from x in result.OrderBy(p=>p.LanguageName)
                          select new SelectListItem
                          {
                              Text = x.LanguageName,
                              Value = x.Id.ToString()
                          }).ToList();

            ViewBag.Languages = values;

        }
    }
}
