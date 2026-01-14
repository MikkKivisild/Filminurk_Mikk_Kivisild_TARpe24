using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Dto.OMDbAPI;

namespace Core.ServiceInterface
{
    public interface IOMDbMovieServices
    {
        Task<OMDbMovieResultDTO> MovieResult(OMDbMovieResultDTO dto);
    }
}
