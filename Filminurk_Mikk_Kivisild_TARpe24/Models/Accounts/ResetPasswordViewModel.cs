using System.ComponentModel.DataAnnotations;

namespace Filminurk_Mikk_Kivisild_TARpe24.Models.Accounts
{
	public class ResetPasswordViewModel
	{
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Kirjuta oma uus parool uuesti:")]
        [Compare("Password", ErrorMessage = "Paroolid ei kattu, palun proovi uuesti.")]
        public string ConfirmNewPassword { get; set; }
        public string Token { get; set; }
    }
}
