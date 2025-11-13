using ApplicationServices.Services;
using AspNetCoreGeneratedDocument;
using Core.Domain;
using Core.Dto;
using Core.ServiceInterface;
using Data;
using Filminurk_Mikk_Kivisild_TARpe24.Models.UserComments;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Filminurk_Mikk_Kivisild_TARpe24.Controllers
{
	public class UserCommentsController : Controller
	{
		private readonly FilminurkTARpe24Context _context;
		private readonly IUserCommentsServices _userCommentsServices;
		public UserCommentsController(
			FilminurkTARpe24Context context,
            IUserCommentsServices userCommentsServices
			)
		{
			_context = context;
			_userCommentsServices = userCommentsServices;

        }
		public IActionResult Index()
		{
			var result = _context.UserComments
				.Select(c => new UserCommentsIndexViewModel
				{
					CommentID = c.CommentID,
					CommentBody = c.CommentBody,
					IsHarmful = (int)c.IsHarmful,
					CommentCreatedAt = c.CommentCreatedAt
				}
			);
			return View(result);
		}
		[HttpGet]
		public IActionResult NewComment()
		{
			//TODO: comment added by admin or user
			UserCommentsCreateViewModel newcomment = new();
			return View(newcomment);
		}
		[HttpPost, ActionName("NewComment")]
		// meetodile ei tohi panna allowanonymous
		public async Task<IActionResult> NewCommentPost(UserCommentsCreateViewModel newcommentVM)
		{
			//check dto
			newcommentVM.CommenterUserID = "00000000-0000-0000-000000000000";
			//TODO; newcommenti manuaalne seadistamina, asendada pärast kasutaja id-ga
			if (ModelState.IsValid)
			{
				var dto = new UserCommentDTO() { };
				dto.CommentID = newcommentVM.CommentID;
				dto.CommentBody = newcommentVM.CommentBody;
				dto.CommenterUserID = newcommentVM.CommenterUserID;
				dto.CommentScore = newcommentVM.CommentScore;
				dto.CommentCreatedAt = newcommentVM.CommentCreatedAt;
				dto.CommentModifieddAt = newcommentVM.CommentModifieddAt;
				dto.CommentDeletedAt = newcommentVM.CommentDeletedAt;
				dto.IsHelpful = newcommentVM.IsHelpful;
                dto.IsHarmful = newcommentVM.IsHarmful;

				var result = await _userCommentsServices.NewComment(dto);
				if (result == null)
				{
					return NotFound();
				}
				//TODO: admin or user, admin returns to admin-comments-index but user back to movies
				return RedirectToAction(nameof(Index));
				//return RedirectToAction("Details", "Movies", id)
			}
			return NotFound();

		}
		[HttpGet]
		public async Task<IActionResult> DetailsAdmin(Guid id)
		{
			var requestedComment = await _userCommentsServices.DetailsAsync(id);
			if (requestedComment == null) { return NotFound(); }
			var commentVM = new UserCommentsIndexViewModel();
			commentVM.CommentID = requestedComment.CommentID;
			commentVM.CommentBody = requestedComment.CommentBody;
			commentVM.CommenterUserID = requestedComment.CommenterUserID;
			commentVM.CommentScore = requestedComment.CommentScore;
			commentVM.CommentDeletedAt = requestedComment.CommentDeletedAt;
			commentVM.CommentModifieddAt= requestedComment.CommentModifieddAt;
			commentVM.CommentCreatedAt = requestedComment.CommentCreatedAt;

			return View(commentVM);

		}
	}
}
