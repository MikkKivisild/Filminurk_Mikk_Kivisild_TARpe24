using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;

namespace Core.Dto
{
    public class FavoriteListDTO
    {
        [Key]
        public Guid FavoriteListID { get; set; }
        public string ListBelongsToUser { get; set; }
        public bool IsMovieOrActor { get; set; }
        public string ListName { get; set; }
        public string? ListDescription { get; set; }
        public bool IsPrivate { get; set; }
        public List<Movie>? ListOfMovies { get; set; }
        //public List<Actor>? ListOfActors { get; set; }

        /*for DB*/
        public DateTime ListCreatedAt { get; set; }
        public DateTime ListModifiedAt { get; set; }
        public DateTime ListDeletedAt { get; set; }
        public bool IsReported { get; set; } = false;
    }
}
