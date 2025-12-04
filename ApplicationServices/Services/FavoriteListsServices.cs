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
                .AsNoTracking()
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

        public async Task<FavoriteList> Update(FavoriteListDTO updatedList, string typeOfMethod)
        {
            
            FavoriteList updatedListInDB = new FavoriteList();

            updatedListInDB.FavoriteListID = updatedListInDB.FavoriteListID;
            updatedListInDB.ListBelongsToUser = updatedListInDB.ListBelongsToUser;
            updatedListInDB.IsMovieOrActor = updatedListInDB.IsMovieOrActor;
            updatedListInDB.ListName = updatedListInDB.ListName;
            updatedListInDB.ListDescription = updatedListInDB.ListDescription;
            updatedListInDB.IsPrivate = updatedListInDB.IsPrivate;
            updatedListInDB.ListOfMovies = updatedListInDB.ListOfMovies;
            updatedListInDB.ListCreatedAt = updatedListInDB.ListCreatedAt;
            updatedListInDB.ListDeletedAt = updatedListInDB.ListDeletedAt;
            updatedListInDB.ListModifiedAt = updatedListInDB.ListModifiedAt;
            if (typeOfMethod == "Delete")
            {
                _context.FavoriteLists.Attach(updatedListInDB);
                _context.Entry(updatedListInDB).Property(l => l.ListDeletedAt).IsModified=true;
            }
            else if(typeOfMethod == "Private")
            {
                _context.FavoriteLists.Attach(updatedListInDB);
                _context.Entry(updatedListInDB).Property(l => l.IsPrivate).IsModified = true;
            }
            _context.Entry(updatedListInDB).Property(l => l.ListModifiedAt).IsModified = true;
            await _context.SaveChangesAsync();
            return updatedListInDB;
        }
    }
}
