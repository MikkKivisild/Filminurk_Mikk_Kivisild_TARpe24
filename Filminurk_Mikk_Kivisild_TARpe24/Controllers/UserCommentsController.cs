using Core.Domain;
using Data;
using Filminurk_Mikk_Kivisild_TARpe24.Models.UserComments;
using Microsoft.AspNetCore.Mvc;

namespace Filminurk_Mikk_Kivisild_TARpe24.Controllers
{
	public class UserCommentsController : Controller
	{
		private readonly FilminurkTARpe24Context _context;
		public UserCommentsController(FilminurkTARpe24Context context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			var result = _context.UserComments
				.Select(c => new UserCommentsIndexViewModel
				{
					CommentID = c.CommentID,
					CommentBody = c.CommentBody,
					IsHarmful = c.IsHarmful,
					CommentCreatedAt = c.CommentCreatedAt
				}
			);
			return View(result);
		}
	}
}
