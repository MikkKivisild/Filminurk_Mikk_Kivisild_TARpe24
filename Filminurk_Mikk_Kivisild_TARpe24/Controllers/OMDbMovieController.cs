using System.Reflection;
using Core.Dto.OMDbAPI;
using Core.ServiceInterface;
using Filminurk_Mikk_Kivisild_TARpe24.Models.OMDbMovies;
using Microsoft.AspNetCore.Mvc;

namespace Filminurk_Mikk_Kivisild_TARpe24.Controllers
{
    public class OMDbMovieController : Controller
    {
        private readonly IOMDbMovieServices _services;
        public OMDbMovieController (IOMDbMovieServices services)
        {
            _services = services;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FindMovie(OMDbMovieViewModel model) 
        {
            if (ModelState.IsValid) 
            {
                return RedirectToAction("Movie");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Movie(string movie)
        {
            OMDbMovieResultDTO dto = new();
            dto.Title = movie;
            _services.MovieResult(dto);
            OMDbMovieViewModel vm = new();

            vm.Title = dto.Title;
            vm.Year = dto.Year;
            vm.Rated = dto.Rated;
            vm.Released = dto.Released;
            vm.Runtime = dto.Runtime;
            vm.Genre = dto.Genre;
            vm.Director = dto.Director;
            vm.Writer = dto.Writer;
            vm.Actors = dto.Actors;
            vm.Plot = dto.Plot;
            vm.Language = dto.Language;
            vm.Country = dto.Country;
            vm.Awards = dto.Awards;
            vm.Poster = dto.Poster;
            vm.Metascore = dto.Metascore;
            vm.imdbRating = dto.imdbRating;
            vm.imdbID = dto.imdbID;
            vm.Type = dto.Type;
            vm.DVD = dto.DVD;
            vm.BoxOffice = dto.BoxOffice;
            vm.Production = dto.Production;
            vm.Website = dto.Website;
            vm.Response = dto.Response;
            return View(vm);
        }
    }
}
