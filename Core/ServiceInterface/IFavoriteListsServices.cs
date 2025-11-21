using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;
using Core.Dto;

namespace Core.ServiceInterface
{
    public interface IFavoriteListsServices
    {
        Task<FavoriteList> DetailsAsync(Guid id);
        Task<FavoriteList> Create(FavoriteListDTO dto, List<Movie> selectedMovies);
    }
}
