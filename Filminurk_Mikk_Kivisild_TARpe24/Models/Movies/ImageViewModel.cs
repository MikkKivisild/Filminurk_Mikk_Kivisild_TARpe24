namespace Filminurk_Mikk_Kivisild_TARpe24.Models.Movies
{
    public class ImageViewModel
    {
        public Guid ImageID { get; set; }
        public string? FilePath { get; set; }
        public Guid? MovieID { get; set; }
        public bool? IsPoster { get; set; } //Määrab ära kas pilt on poster või mitte
    }
}
