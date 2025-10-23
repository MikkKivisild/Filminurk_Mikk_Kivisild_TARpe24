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
using Microsoft.Extensions.Hosting;

namespace ApplicationServices.Services
{
    public class FilesServices : IFilesServices
    {
        public readonly IHostEnvironment _webHost;
        private readonly FilminurkTARpe24Context _context;

        public FilesServices(IHostEnvironment webHost, FilminurkTARpe24Context context)
        {
            _webHost = webHost;
            _context = context;
        }
        public void FileToApi(MoviesDTO dto, Movie domain)
        {
            if (dto.Files != null && dto.Files.Count > 0)
            {
                if (Directory.Exists(_webHost.ContentRootPath + "\\wwwroot\\multipleFileUploard\\"))
                {
                    Directory.Exists(_webHost.ContentRootPath + "\\wwwroot\\multipleFileUploard\\");
                }

                foreach (var file in dto.Files)
                {
                    string uploadsFolder = Path.Combine(_webHost.ContentRootPath, "wwwroot", "multipleFileUploard");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                    string FilePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(FilePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                        FileToApi path = new FileToApi
                        {
                            ImageID = Guid.NewGuid(),
                            ExistingFilePath = uniqueFileName,
                            MovieID = domain.ID,
                        };
                        _context.FilesToApi.AddAsync(path);
                    }
                }
            }
        }

        public async Task<FileToApi> RemoveImageFromApi(FileToApiDTO dto)
        {
            var ImageID = await _context.FilesToApi.FirstOrDefaultAsync(x => x.ImageID == dto.ImageID);

            var filePath = _webHost.ContentRootPath + "\\wwwroot\\multipleFileUpload\\" + ImageID.ExistingFilePath;
           
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            _context.FilesToApi.Remove(ImageID);
            await _context.SaveChangesAsync();
            return null;
        }
    }
}
