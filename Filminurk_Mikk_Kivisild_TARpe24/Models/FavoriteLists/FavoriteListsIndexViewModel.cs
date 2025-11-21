using Core.Domain;

namespace Filminurk_Mikk_Kivisild_TARpe24.Models.FavoriteLists
{
    public class FavoriteListsIndexViewModel
    {
        public Guid? FavoriteListID { get; set; }
        public string ListBelongsToUser { get; set; }
        public bool IsMovieOrActor { get; set; }
        public string ListName { get; set; }
        public string ListOfDescription { get; set; }
        //public List<Movie> ListOfMovies { get; set; }
        //public List<Actor>? ListOfActors { get; set; }

        public DateTime? ListCreatedAt { get; set; }
        public DateTime? ListModifiedAt { get; set; }
        public DateTime? ListDeletedAt { get; set; }

        public List<FavoriteListIndexImageViewModel> Image {  get; set; } new
            List<FavoriteListsIndexImageViewModel>();
    }
}
