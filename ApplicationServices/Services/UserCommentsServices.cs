using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;
using Core.Dto;
using Core.ServiceInterface;
using Data;
using Microsoft.EntityFrameworkCore;

namespace ApplicationServices.Services
{
    public class UserCommentsServices : IUserCommentsServices
    {
        private readonly FilminurkTARpe24Context _context;

        public UserCommentsServices(FilminurkTARpe24Context context)
        {
            _context = context;
        }

        public async Task<UserComment> NewComment(UserCommentDTO newcommentDTO)
        {
            UserComment domain = new UserComment();

            domain.CommentID = Guid.NewGuid();
            domain.CommentBody = newcommentDTO.CommentBody;
            domain.CommenterUserID = newcommentDTO.CommenterUserID;
            domain.CommentScore = newcommentDTO.CommentScore;
            domain.CommentCreatedAt = DateTime.Now;
            domain.CommentModifieddAt = DateTime.Now;
            domain.IsHelpful = 0;
            domain.IsHarmful = 0;

            await _context.UserComments.AddAsync(domain);
            await _context.SaveChangesAsync();

            return domain;
        }
        public async Task<UserComment> DetailsAsync(Guid id)
        {
            var returnedComment = await _context.UserComments.FirstOrDefaultAsync(x => x.CommentID == id);
            return returnedComment;
        }
    }
}
