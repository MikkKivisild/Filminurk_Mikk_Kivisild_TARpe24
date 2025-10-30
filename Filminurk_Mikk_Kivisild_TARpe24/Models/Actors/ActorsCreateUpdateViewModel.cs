using System.ComponentModel.DataAnnotations;

namespace Filminurk_Mikk_Kivisild_TARpe24.Models.Actors
{
    public class ActorsCreateUpdateViewModel
    {
        [Key]
        public Guid ActorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        List<string>? MoviesActedFor { get; set; }
        public Guid PortraitID { get; set; }
        public DateOnly? FirstActed { get; set; }
        public int? Age { get; set; }
        public Gender? Gender { get; set; }
    }
}
