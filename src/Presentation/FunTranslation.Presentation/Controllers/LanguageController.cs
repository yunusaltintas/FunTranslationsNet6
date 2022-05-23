using AutoMapper;
using FunTranslation.Application.Interfaces.IService;
using FunTranslation.Application.ViewModels;
using FunTranslation.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FunTranslation.Presentation.Controllers
{
    [Authorize(Roles ="Admin")]
    public class LanguageController : Controller
    {

        private readonly IServiceManager _serviceManager;
        private readonly IMapper _mapper;

        public LanguageController(IServiceManager serviceManager, IMapper mapper)
        {
            _serviceManager = serviceManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _serviceManager.LanguageService.GetAllAsync();
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(LanguageCreateViewModel model)
        {
            await _serviceManager.LanguageService.AddAsync(_mapper.Map<Language>(model));

            return RedirectToAction("Index", "Language");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var language = await _serviceManager.LanguageService.GetByIdAsync(id);

            return View(_mapper.Map<LanguageUpdateViewModel>(language));
        }

        [HttpPost]
        public IActionResult Update(LanguageUpdateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var result = _serviceManager.LanguageService.Update(_mapper.Map<Language>(model));

            if (result != null)
            {
                return RedirectToAction("Index", "Language");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {

            var language = await _serviceManager.LanguageService.GetByIdAsync(id);

            _serviceManager.LanguageService.Remove(language);

            return RedirectToAction("Index", "Language");
        }
    }
}
