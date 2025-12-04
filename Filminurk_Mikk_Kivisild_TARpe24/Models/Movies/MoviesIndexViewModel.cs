namespace Filminurk_Mikk_Kivisild_TARpe24.Models.Movies
{
    public class MoviesIndexViewModel
    {
        public Guid? ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateOnly FirstPublished { get; set; }
        public Double? CurrentRating { get; set; }


        // minu andme tüübid
        public int? Seasons { get; set; }
        public DateTime? LastPublished { get; set; }
 
    }
}
