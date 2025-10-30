using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto
{
    public enum Gender
    {
        Male, Female
    }
    public class ActorsDTO
    {
        [Key]
        public Guid ActorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        List<string> MoviesActedFor { get; set; }
        public Guid PortraitID { get; set; }
        public DateTime FirstActed { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
    }
}
