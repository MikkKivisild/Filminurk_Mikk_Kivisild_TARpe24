using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Core.Dto
{
    public class MoviesDTO
    {
        public Guid? ID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateOnly? FirstPublished { get; set; }
        public string? Director { get; set; }
        public List<string>? Actors { get; set; }
        public double? CurrentRating { get; set; }

        /*Kassolevate piltide andmeomadused*/
        public List<IFormFile> Files { get; set; }
        public IEnumerable<FileToApiDTO> FilesToApiDTOs { get; set; } = new List<FileToApiDTO>();
        // minu andme tüübid
        public int? Seasons { get; set; }
        public DateTime? LastPublished { get; set; }
        public string? Fish { get; set; }

        /* andmebaasi jaoks vajalikud */
        public DateTime? EntryCreatedAt { get; set; }
        public DateTime? EntryModifiedAt { get; set; }
    }
}
