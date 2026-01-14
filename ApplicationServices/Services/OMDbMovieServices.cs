using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Dto.OMDbAPI;
using Core.ServiceInterface;

namespace ApplicationServices.Services
{
    public class OMDbMovieServices : IOMDbMovieServices
    {
        public async Task<OMDbMovieResultDTO> MovieResult(OMDbMovieResultDTO dto)
        {
            string apikey = Data.Enviroment.omdbapikey;

            using (var client = new HttpClient()) 
            {
                var httpResponseMovie = client.GetAsync(apikey).GetAwaiter().GetResult();
                string jsonMovie = await httpResponseMovie.Content.ReadAsStringAsync();

                OMDbMovieResultDTO movieResultDTO = JsonSerializer.Deserialize<OMDbMovieResultDTO>(jsonMovie);

                dto.Title = movieResultDTO.Title;
                dto.Year = movieResultDTO.Year;
                dto.Rated = movieResultDTO.Rated;
                dto.Released = movieResultDTO.Released;
                dto.Runtime = movieResultDTO.Runtime;
                dto.Genre = movieResultDTO.Genre;
                dto.Director = movieResultDTO.Director;
                dto.Writer = movieResultDTO.Writer;
                dto.Actors = movieResultDTO.Actors;
                dto.Plot = movieResultDTO.Plot;
                dto.Language = movieResultDTO.Language;
                dto.Country = movieResultDTO.Country;
                dto.Awards = movieResultDTO.Awards;
                dto.Poster = movieResultDTO.Poster;
                dto.Metascore = movieResultDTO.Metascore;
                dto.imdbRating = movieResultDTO.imdbRating;
                dto.imdbID = movieResultDTO.imdbID;
                dto.Type = movieResultDTO.Type;
                dto.DVD = movieResultDTO.DVD;
                dto.BoxOffice = movieResultDTO.BoxOffice;
                dto.Production = movieResultDTO.Production;
                dto.Website = movieResultDTO.Website;
                dto.Response = movieResultDTO.Response;
            }
            return dto;
        }
    }
}
