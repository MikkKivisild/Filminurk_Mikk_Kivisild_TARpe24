using System.ComponentModel.DataAnnotations;

namespace Filminurk_Mikk_Kivisild_TARpe24.Models.Accounts
{
    public class AddPasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Sisesta oma uus praool")]
        public string NewPassword { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Kirjuta oma uus parool uuesti:")]
        [Compare("NewPassword", ErrorMessage = "Paroolid ei kattu, palun proovi uuesti.")]
        public string ConfirmNewPassword { get; set; }
    }
}
