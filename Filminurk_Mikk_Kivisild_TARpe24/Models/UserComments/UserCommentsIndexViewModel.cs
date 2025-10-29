using System.ComponentModel.DataAnnotations;

namespace Filminurk_Mikk_Kivisild_TARpe24.Models.UserComments
{
	public class UserCommentsIndexViewModel
	{
		[Key]
		public Guid CommentID { get; set; }
		public string? CommentUserID { get; set; }
		public string CommentBody { get; set; }
		public int? CommentScore { get; set; }
		public int? IsHelpful { get; set; }
		public int IsHarmful { get; set; }

		/* Andmebaasi jaoks vajalikud andmed */
		public DateTime CommentCreatedAt { get; set; }
		public DateTime CommentModifieddAt { get; set; }
		public DateTime? CommentDeletedAt { get; set; }
	}
}
