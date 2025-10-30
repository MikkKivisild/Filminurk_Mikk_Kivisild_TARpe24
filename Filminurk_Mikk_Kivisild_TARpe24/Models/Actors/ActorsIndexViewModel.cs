using System.ComponentModel.DataAnnotations;

namespace Filminurk_Mikk_Kivisild_TARpe24.Models.Actors
{
    public enum Gender
    {
        Male,Female
    }
    public class ActorsIndexViewModel
    {
        [Key]
        public Guid ActorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public Guid PortraitID { get; set; }
        public DateOnly? FirstActed { get; set; }
        public int? Age { get; set; }
        public Gender? Gender { get; set; }
        public DateTime? EntryCreatedAt { get; set; }
        public DateTime? EntryModifiedAt { get; set; }
    }
}
