using ApplicationServices.Services;
using Core.Dto;
using Core.ServiceInterface;
using Data;
using Filminurk_Mikk_Kivisild_TARpe24.Models.Movies;
using Microsoft.AspNetCore.Mvc;

namespace Filminurk_Mikk_Kivisild_TARpe24.Controllers
{
    public class MoviesController : Controller
    {
        private readonly FilminurkTARpe24Context _context;
        private readonly IMovieServices _movieServices;
        public MoviesController
            (
            FilminurkTARpe24Context context,
            IMovieServices movieServices
            )
        {
            _context = context;
            _movieServices = movieServices;
        }
        public IActionResult Index()
        {
            var result = _context.Movies.Select(vm => new MoviesIndexViewModel
            {
                ID = vm.ID,
                Title = vm.Title,
                FirstPublished = vm.FirstPublished,
                CurrentRating = vm.CurrentRating,
                
            });
            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            MoviesCreateViewModel result = new();
            return View("Create",result);
        }
        [HttpPost]
        public async Task<IActionResult> Create (MoviesCreateViewModel vm)
        {
            var dto = new MoviesDTO()
            {
                ID = vm.ID,
                Title = vm.Title,
                Description = vm.Description,
                FirstPublished = vm.FirstPublished,
                Director = vm.Director,
                Actors = vm.Actors,
                CurrentRating = vm.CurrentRating,
                Seasons = vm.Seasons,
                LastPublished = vm.LastPublished,
                Fish = vm.Fish,
                EntryCreatedAt = vm.EntryCreatedAt,
                EntryModifiedAt = vm.EntryModifiedAt,
            };
            var result = await _movieServices.Create(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
