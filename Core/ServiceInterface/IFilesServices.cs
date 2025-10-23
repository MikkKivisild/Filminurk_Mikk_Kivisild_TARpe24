using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;
using Core.Dto;

namespace Core.ServiceInterface
{
    public interface IFilesServices
    {
        void FileToApi(MoviesDTO dto, Movie domain);

        Task<FileToApi> RemoveImageFromApi(FileToApiDTO dto);
    }
}
