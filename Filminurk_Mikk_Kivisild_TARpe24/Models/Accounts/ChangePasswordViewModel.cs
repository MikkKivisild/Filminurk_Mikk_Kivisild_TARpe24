using System.ComponentModel.DataAnnotations;

namespace Filminurk_Mikk_Kivisild_TARpe24.Models.Accounts
{
    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Sisesta oma praegune parool")]
        public string CurrentPassword { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Sisesta oma uus parool")]
        public string NewPassword { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Kirjuta oma uus parool uuesti")]
        [Compare("NewPassword", ErrorMessage = "Paroolid ei kattu, proovi uuesti.")]
        public string ConfirmNewPassword { get; set; }
    }
}
