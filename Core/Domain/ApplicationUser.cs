using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
	public class ApplicationUser : IdentityUser
	{
		public List<Guid>? FavouriteListIDs { get; set; }
		public List<Guid>? CommentIDs { get; set; }
		public string AvatarImageID { get; set; }
		public string DisplayName { get; set; }
		public bool ProfileType { get; set; }

		public string FavoriteColor { get; set; }
		public int Age { get; set; }
	}
}
