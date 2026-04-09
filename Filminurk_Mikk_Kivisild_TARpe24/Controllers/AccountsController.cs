using Core.Domain;
using Core.ServiceInterface;
using Data;
using Filminurk_Mikk_Kivisild_TARpe24.Models.Accounts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Filminurk_Mikk_Kivisild_TARpe24.Controllers
{
	public class AccountsController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly FilminurkTARpe24Context _context;
		private readonly IEmailsServices _emailsServices;

		public AccountsController(
			UserManager<ApplicationUser> userManager,
			SignInManager<ApplicationUser> signInManager,
			FilminurkTARpe24Context context
			)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_context = context;
		}
		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}
		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> Register(RegisterViewModel model)
		{
			if (ModelState.IsValid)
			{
				var user = new ApplicationUser()
				{
					UserName = model.DisplayName,
					Email = model.Email,
					ProfileType = model.ProfileType,
				};
				var result = await _userManager.CreateAsync(user, model.Password);
				if (result.Succeeded)
				{
					var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

					var confirmationLink = Url.Action("ConfirmEmail", "Accounts", new { userID = user.Id, token = token }, Request.Scheme);
					
				}

				return RedirectToAction("Index", "Home");
			}
			return BadRequest();
		}


	}
}
