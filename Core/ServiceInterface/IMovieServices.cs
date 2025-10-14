using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;
using Core.Dto;

namespace Core.ServiceInterface
{
    public interface IMovieServices // see on interface. asub .core/serviceinterface
    {
        Task<Movie> Create (MoviesDTO dto);
        Task<Movie> DetailsAsync(Guid id);
    }
}
