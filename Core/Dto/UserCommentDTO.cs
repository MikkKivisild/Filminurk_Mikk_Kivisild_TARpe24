using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto
{
	public class UserCommentDTO
	{
		public class UserComment
		{
			[Key]
			public Guid ID { get; set; }
			public string? CommentUserID { get; set; }
			public string CommentBody { get; set; }
			public int CommentScore { get; set; }
			public int IsHelpful { get; set; }
			public int IsHarmful { get; set; }

			/* Andmebaasi jaoks vajalikud andmed */
			public DateTime CommentCreatedAt { get; set; }
			public DateTime CommentModifieddAt { get; set; }
			public DateTime? CommentDeletedAt { get; set; }
		}
	}
}
