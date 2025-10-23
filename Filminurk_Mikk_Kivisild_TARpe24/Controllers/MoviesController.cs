using ApplicationServices.Services;
using Core.Domain;
using Core.Dto;
using Core.ServiceInterface;
using Data;
using Filminurk_Mikk_Kivisild_TARpe24.Models.Movies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Filminurk_Mikk_Kivisild_TARpe24.Controllers
{
    public class MoviesController : Controller
    {
        private readonly FilminurkTARpe24Context _context;
        private readonly IMovieServices _movieServices;
        private readonly IFilesServices _filesServices; // piltide lisamiseks vajalik fileservices injection
        public MoviesController
            (
            FilminurkTARpe24Context context,
            IMovieServices movieServices,
            IFilesServices filesServices // piltide lisamiseks vajalik fileservices injection
            )
        {
            _context = context;
            _movieServices = movieServices;
            _filesServices = filesServices; // piltide lisamiseks vajalik fileservices injection
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
            MoviesCreateUpdateViewModel result = new();
            return View("Create", result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(MoviesCreateUpdateViewModel vm)
        {
            if (vm == null)
            {
                return NotFound();
            }
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
                Files = vm.Files,
                FilesToApiDTOs  = vm.Images
                .Select(x => new FileToApiDTO
                {
                    ImageID = x.ImageID,
                    FilePath = x.FilePath,
                    MovieID = x.MovieID,
                    IsPoster = x.IsPoster,
                }).ToArray()
            };
            var result = await _movieServices.Create(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var movie = await _movieServices.DetailsAsync(id);

            if (movie == null)
            {
                return NotFound();
            }
            var vm = new MoviesDetailsViewModel();

            vm.ID = movie.ID;
            vm.Title = movie.Title;
            vm.Description = movie.Description;
            vm.FirstPublished = movie.FirstPublished;
            vm.CurrentRating = movie.CurrentRating;
            vm.Seasons = movie.Seasons;
            vm.LastPublished = movie.LastPublished;
            vm.Fish = movie.Fish;
            vm.EntryCreatedAt = movie.EntryCreatedAt;
            vm.EntryModifiedAt = movie.EntryModifiedAt;
            vm.Director = movie.Director;
            vm.Actors = movie.Actors;

            return View(vm);
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var movie = await _movieServices.DetailsAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            var images = await _context.FilesToApi
               .Where(x => x.MovieID == id)
               .Select(y => new ImageViewModel
               {
                   FilePath = y.ExistingFilePath,
                   ImageID = id
               }).ToArrayAsync();

            var vm = new MoviesCreateUpdateViewModel();
            vm.ID = id;
            vm.Title = vm.Title;
            vm.Description = vm.Description;
            vm.FirstPublished = vm.FirstPublished;
            vm.Director = vm.Director;
            vm.Actors = vm.Actors;
            vm.CurrentRating = vm.CurrentRating;
            vm.Seasons = vm.Seasons;
            vm.LastPublished = vm.LastPublished;
            vm.Fish = vm.Fish;
            vm.EntryCreatedAt = vm.EntryCreatedAt;
            vm.EntryModifiedAt = movie.EntryModifiedAt;
            vm.Images.AddRange(images);

            
            return View("CreateUpdate",vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(MoviesCreateUpdateViewModel vm)
        {

            var dto = new MoviesDTO()
            {
                ID = vm.ID,
                Title = vm.Title,
                Description = vm.Description,
                FirstPublished = vm.FirstPublished,
                CurrentRating = vm.CurrentRating,
                Seasons = vm.Seasons,
                LastPublished = vm.LastPublished,
                Fish = vm.Fish,
                EntryCreatedAt = vm.EntryCreatedAt,
                EntryModifiedAt = vm.EntryModifiedAt,
                Director = vm.Director,
                Actors = vm.Actors,
                Files = vm.Files,
                FilesToApiDTOs = vm.Images
                .Select(x => new FileToApiDTO
                {
                    MovieID = x.MovieID,
                    FilePath = x.FilePath,
                    ImageID = x.ImageID
                }).ToArray()
            };
            var result = await _movieServices.Update(dto);

            if (result == null)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var movie = await _movieServices.DetailsAsync(id);

            if (movie == null) 
            {
                return NotFound();
            }
            var images = await _context.FilesToApi
                .Where(x => x.MovieID == id)
                .Select(y => new ImageViewModel
                {
                    FilePath = y.ExistingFilePath,
                    ImageID = y.ImageID,
                }).ToArrayAsync();

            var vm = new MovieDeleteViewModel();
            vm.ID = movie.ID;
            vm.Title = movie.Title;
            vm.Description = movie.Description;
            vm.FirstPublished = movie.FirstPublished;
            vm.Director = movie.Director;
            vm.Actors = movie.Actors;
            vm.CurrentRating = movie.CurrentRating;
            vm.Seasons = movie.Seasons;
            vm.LastPublished = movie.LastPublished;
            vm.Fish = movie.Fish;
            vm.EntryCreatedAt = movie.EntryCreatedAt;
            vm.EntryModifiedAt = movie.EntryModifiedAt;

            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var movie = await _movieServices.Delete(id);
            if(movie == null)
            {  return NotFound(); }
            return RedirectToAction(nameof(Index));
        }
    }
}
