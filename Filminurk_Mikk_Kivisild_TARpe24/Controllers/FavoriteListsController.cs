using ApplicationServices.Services;
using Core.Domain;
using Core.Dto;
using Core.ServiceInterface;
using Data;
using Filminurk_Mikk_Kivisild_TARpe24.Models.Movies;
using Microsoft.AspNetCore.Mvc;

namespace Filminurk_Mikk_Kivisild_TARpe24.Controllers
{
    public class FavoriteListsController : Controller
    {
        private readonly FilminurkTARpe24Context _context;
        private readonly IFavoriteListsServices _favoriteListsServices;
        public FavoriteListsController(FilminurkTARpe24Context context, IFavoriteListsServices favoriteListsServices)
        {
            _context = context;
            _favoriteListsServices = favoriteListsServices;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            var movies = _context.Movies
                .OrderBy(m => m.Title)
                .Select(mo => new MoviesIndexViewModel
            {
                ID = mo.ID,
                Title = mo.Title,
                FirstPublished = mo.FirstPublished,
                Seasons = mo.Seasons,
            }).ToList();
            ViewData["allmovies"] = movies;
            ViewData["UserHasSelected"] = new List<string>();
            FavoriteListUserCreateViewModel vm = new();
            return View("Create", vm);
        }
        [HttpPost]
        public async Task<IActionResult> UserCreate(FavoriteListUserCreateViewModel vm,
            List<string> userHasSelected, List<MoviesIndexViewModel> movies)
        {
            List<Guid> tempParse = new();
            foreach (var item in movies)
            {
                tempParse.Add(Guid.Parse(stringID));
            }

            var newListDto = new FavoriteListDTO() { };
            newListDto.ListName = vm.ListName;
            newListDto.ListDescription = vm.ListDecription;
            newListDto.IsMovieOrActor = vm.IsMovieOrActor;
            newListDto.IsPrivate = vm.IsPrivate;
            newListDto.ListCreatedAt = DateTime.UtcNow;
            newListDto.ListBelongsToUser = "00000000-0000-0000-000000000001";
            newListDto.ListModifiedAt = DateTime.UtcNow;
            newListDto.ListDeletedAt = vm.ListDeletedAt;
            newListDto.ListOfMovies = vm.ListOfMovies;

          /*List<Guid> convertedIDs = new List<Guid>();
            if (newListDto.ListOfMovies != null)
            {
                convertedIDs = MovieToId(newListDto.ListOfMovies);
            }
          */
            var newList = await _favoriteListsServices.Create (newListDto /*, convertedIDs*/);
            if (newList != null) 
            {
                return BadRequest();
            }
            return RedirectToAction("Index", vm);
        }
        private List<Guid> MovieToId(List<Movie> listOfMovies)
        {
            var result = new List<Guid>();
            foreach (var movie in listOfMovies)
            {
                result.Add(movie.ID);
            }
            return result;
        }

    }
}
