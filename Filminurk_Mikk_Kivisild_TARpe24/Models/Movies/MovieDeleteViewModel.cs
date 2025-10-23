namespace Filminurk_Mikk_Kivisild_TARpe24.Models.Movies
{
    public class MovieDeleteViewModel
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateOnly FirstPublished { get; set; }
        public string Director { get; set; }
        public List<string> Actors { get; set; }
        public Double? CurrentRating { get; set; }

        /*Kassolevate piltide andmeomadused*/
        public List<ImageViewModel> Images { get; set; } = new List<ImageViewModel>();


        // minu andme tüübid
        public int? Seasons { get; set; }
        public DateTime? LastPublished { get; set; }
        public string Fish { get; set; }
        /* andmebaasi jaoks vajalikud */
        public DateTime? EntryCreatedAt { get; set; }
        public DateTime? EntryModifiedAt { get; set; }
    }
}
