using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;
using Core.Dto;

namespace Core.ServiceInterface
{
    public interface IUserCommentsServices
    {
        Task<UserComment> NewComment(UserCommentDTO newcommentDTO);
        Task<UserComment> DetailsAsync(Guid id);
    }
}
