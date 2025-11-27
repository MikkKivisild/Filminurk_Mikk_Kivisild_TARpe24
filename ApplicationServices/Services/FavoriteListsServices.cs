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
    public class FavouriteListsServices : IFavoriteListsServices
    {
        private readonly FilminurkTARpe24Context _context;
        private readonly IFilesServices _filesServices;

        public FavouriteListsServices(FilminurkTARpe24Context context, IFilesServices filesServices)
        {
            _context = context;
            _filesServices = filesServices;
        }
        public async Task<FavoriteList> DetailsAsync(Guid id)
        {
            var result = await _context.FavoriteLists
                .FirstOrDefaultAsync(x => x.FavoriteListID == id);
            return result;
        }

        public async Task<FavoriteList> Create(FavoriteListDTO dto/*, List<Movie> selectedMovies */)
        {
            FavoriteList newlist = new();
            newlist.FavoriteListID = Guid.NewGuid();
            newlist.ListName = dto.ListName;
            newlist.ListDescription = dto.ListDescription;
            newlist.ListCreatedAt = dto.ListCreatedAt;
            newlist.ListModifiedAt = (DateTime)dto.ListModifiedAt;
            newlist.ListDeletedAt = (DateTime)dto.ListDeletedAt;
            newlist.ListOfMovies = dto.ListOfMovies;
            await _context.FavoriteLists.AddAsync(newlist);
            await _context.SaveChangesAsync();

            // foreach (var movieid in selectedMovies)
            // {
            //     _context.FavouriteLists.Entry
            //
            //
            // }
            return newlist;

        }

    }
}
