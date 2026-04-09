using System.ComponentModel.DataAnnotations;

namespace Filminurk_Mikk_Kivisild_TARpe24.Models.Accounts
{
	public class ForgotPasswordViewModel
	{
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
