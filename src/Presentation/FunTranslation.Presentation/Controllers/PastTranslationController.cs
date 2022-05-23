using AutoMapper;
using FunTranslation.Application.Interfaces.IService;
using FunTranslation.Application.ViewModels;
using FunTranslation.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace FunTranslation.Presentation.Controllers
{
    [Authorize(Roles =("Admin"))]
    public class PastTranslationController : Controller
    {
        private readonly IServiceManager _serviceManager;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public PastTranslationController(IServiceManager serviceManager, IMapper mapper, UserManager<AppUser> userManager)
        {
            _serviceManager = serviceManager;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index(PastTranslateRequestViewModel? model)
        {
            await FillSelectListItem();

            var query = _serviceManager.PastTranslationService.GetPastTranslation(model);
            query = query.OrderByDescending(i => i.CreateDate);

            PastTranslateViewModel result = new PastTranslateViewModel
            {
                PastTranslations = query.ToList(),
                UserId = model.UserId,
                LanguageId = model.LanguageId
            };

            return View(result);
        }

        private async Task FillSelectListItem()
        {
            var result = _userManager.Users.ToList();
            var values = (from x in result.OrderBy(p => p.UserName)
                          select new SelectListItem
                          {
                              Text = x.UserName,
                              Value = x.Id.ToString()
                          }).ToList();

            ViewBag.Users = values;

            var result2 = await _serviceManager.LanguageService.GetAllAsync();
            var values2 = (from x in result2.OrderBy(p => p.LanguageName)
                           select new SelectListItem
                           {
                               Text = x.LanguageName,
                               Value = x.Id.ToString()
                           }).ToList();

            ViewBag.Languages = values2;

        }
    }
}
