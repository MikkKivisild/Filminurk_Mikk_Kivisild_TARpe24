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
    public class MovieServices : IMovieServices
    {
        private readonly FilminurkTARpe24Context _context;
        private readonly IFilesServices _filesServices; // Failid

        public MovieServices(FilminurkTARpe24Context context, IFilesServices filesServices) // Failid)
        {
            _context = context;
            _filesServices = filesServices;// Failid
        }
        public async Task<Movie> Create(MoviesDTO dto)
        {
            Movie movie = new Movie();
            movie.ID =  Guid.NewGuid();
            movie.Title = dto.Title;
            movie.Description = dto.Description;
            movie.CurrentRating = dto.CurrentRating;
            movie.FirstPublished = (DateOnly)dto.FirstPublished;
            movie.Actors = dto.Actors;
            movie.Director = dto.Director;
            /* Kolm enda oma*/
            movie.Seasons = dto.Seasons;
            movie.LastPublished = dto.LastPublished;
            movie.Fish = dto.Fish;
            movie.EntryCreatedAt = DateTime.Now;
            movie.EntryModifiedAt = DateTime.Now;
            _filesServices.FileToApi(dto, movie);


            _context.Movies.Update(movie);
            await _context.AddAsync(movie);
            await _context.SaveChangesAsync();

            return movie;
        }
        public async Task<Movie> DetailsAsync(Guid id)
        {
            var result = await _context.Movies.FirstOrDefaultAsync(x => x.ID == id);
            return result;
        }
        public async Task<Movie> Update(MoviesDTO dto)
        {
            Movie movie = new Movie();

            movie.ID = (Guid)dto.ID;
            movie.Title = dto.Title;
            movie.Description = dto.Description;
            movie.CurrentRating = dto.CurrentRating;
            movie.FirstPublished = (DateOnly)dto.FirstPublished;
            movie.Director = dto.Director;
            movie.Actors = dto.Actors.ToList();
            movie.Seasons = (int)dto.Seasons;
            movie.LastPublished = dto.LastPublished;
            movie.Fish = dto.Fish;
            movie.EntryCreatedAt = dto.EntryCreatedAt;
            movie.EntryModifiedAt = DateTime.Now;
            _filesServices.FileToApi(dto, movie);

            await _context.AddAsync(movie);
            await _context.SaveChangesAsync();
            return movie;

        }

        public async Task<Movie> Delete(Guid id)
        {

            var result = await _context.Movies
                .FirstOrDefaultAsync(m => m.ID == id);

            var images = await _context.FilesToApi
                .Where(x => x.MovieID == id)
                .Select(y => new FileToApiDTO
                {
                    ImageID = y.ImageID,
                    MovieID = y.MovieID,
                    FilePath = y.ExistingFilePath,
                }).ToArrayAsync();

            await _filesServices.RemoveImagesFromApi(images);
            _context.Movies.Remove(result);
            await _context.SaveChangesAsync();

            return result;
        }
    }
}
