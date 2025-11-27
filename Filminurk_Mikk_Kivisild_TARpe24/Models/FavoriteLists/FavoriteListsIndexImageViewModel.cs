namespace Filminurk_Mikk_Kivisild_TARpe24.Models.FavoriteLists
{
    public class FavoriteListsIndexImageViewModel
    {
        public Guid ImageID { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }
        public string Image {  get; set; }
        public Guid? ListID { get; set; }
    }
}
