using System.Threading.Tasks;
using ApplicationServices.Services;
using Core.Domain;
using Core.Dto;
using Core.ServiceInterface;
using Data;
using Filminurk_Mikk_Kivisild_TARpe24.Models.FavoriteLists;
using Filminurk_Mikk_Kivisild_TARpe24.Models.Movies;
using Microsoft.AspNetCore.Mvc;

namespace Filminurk_Mikk_Kivisild_TARpe24.Controllers
{
    public class FavoriteListsController : Controller
    {
        private readonly FilminurkTARpe24Context _context;
        private readonly IFavoriteListsServices _favoriteListsServices;
        private readonly IFilesServices _filesServices;
        public FavoriteListsController(FilminurkTARpe24Context context, IFavoriteListsServices favoriteListsServices, IFilesServices filesServices)
        {
            _context = context;
            _favoriteListsServices = favoriteListsServices;
            _filesServices = filesServices;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<FavoriteList> DetailsAsync()
        {

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
            newListDto.ListBelongsToUser = Guid.NewGuid().ToString();
            newListDto.ListModifiedAt = DateTime.UtcNow;
            newListDto.ListDeletedAt = DateTime.UtcNow;
            newListDto.ListOfMovies = vm.ListOfMovies;

            //lisa filmid nimekirja, olemasolevate id-de põhiselt

            var listofmoviestoadd = new List<Movie>();
            foreach (var movieId in tempParse)
            {
                Movie thismovie = (Movie)_context.Movies.Where(tm => tm.ID == movieId)
                    .ToList().First();
                listofmoviestoadd.Add(thismovie);
            }

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

        [HttpGet]
        public async Task<IActionResult> UserDetails(Guid id, Guid thisuserid)
        {
            if (id == null || thisuserid == null)
            {  return BadRequest(); }
            //TODO: reutrn corresponding errorviews. id not found for list, and user login error for userid

            var thisList = _context.FavoriteLists
                .Where(tl => tl.FavoriteListID == id && tl.ListBelongsToUser == thisuserid.ToString())
                .Select(
                stl => new FavoriteListUserDetailsViewModel
                {
                    FavoriteListID = stl.FavoriteListID,
                    ListBelongsToUser = stl.ListBelongsToUser,
                    IsMovieOrActor = stl.IsMovieOrActor,
                    ListName = stl.ListName,
                    ListDecription = stl.ListDescription,
                    IsPrivate = stl.IsPrivate,
                    ListOfMovies = stl.ListOfMovies,
                    IsReported = stl.IsReported,
                    Image = _context.FilesToDatabase
                    .Where(i => i.ListID == stl.FavoriteListID)
                    .Select(si => new FavoriteListsIndexImageViewModel
                    {
                        ImageID = si.ImageID,
                        ListID = si.ListID,
                        ImageData = si.ImageData,
                        ImageTitle = si.ImageTitle,
                        Image = string.Format("data:image/gif;based,{0}", Convert.ToBase64String(si.ImageData)),
                    }).ToList().First()
                }).First();
            if(thisList == null)
            { return NotFound(); }
            //add viewdata attribute here later, to discern user and admin
            return View("Details", thisList.First());
        }

        [HttpPost]
        public IActionResult UserTogglePrivacy(Guid id)
        {
            FavoriteList thisList = _favoriteListsServices.DetailsAsync(id);

            FavoriteListDTO updatedList = new FavoriteListDTO();
            updatedList.ListBelongsToUser = thisList.ListBelongsToUser;
            updatedList.FavoriteListID = thisList.FavoriteListID;
            updatedList.ListName = thisList.ListName;
            updatedList.ListDescription = thisList.ListDescription;
            updatedList.IsPrivate = thisList.IsPrivate;
            updatedList.ListOfMovies = thisList.ListOfMovies;
            updatedList.IsReported = thisList.IsReported;
            updatedList.IsMovieOrActor = thisList.IsMovieOrActor;
            updatedList.ListCreatedAt = thisList.ListCreatedAt;
            updatedList.ListModifiedAt = DateTime.Now;
            updatedList.ListDeletedAt = thisList.ListDeletedAt;
            

            
            thisList.IsPrivate = !thisList.IsPrivate;
            _favoriteListsServices.Update(thisList);
            return View("Details");
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
