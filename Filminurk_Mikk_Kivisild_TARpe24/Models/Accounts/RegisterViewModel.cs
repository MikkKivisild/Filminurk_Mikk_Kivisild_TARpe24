using System.ComponentModel.DataAnnotations;

namespace Filminurk_Mikk_Kivisild_TARpe24.Models.Accounts
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Paroolid ei kattu, kontrolli et oled sama moodi sisestanud")]
        [Display(Name = "Sisesta parool uuesti:")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public string DisplayName { get; set; }
        public bool ProfileType { get; set; } = false;
    }
}
