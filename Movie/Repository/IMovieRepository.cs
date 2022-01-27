using Movie.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Repository
{
    public interface IMovieRepository
    {
        Task<IEnumerable<MovieModel>> GetAllMovies();
        Task<MovieModel> GetMovieById(int id);
        Task<MovieModel> Create(MovieModel movieModel);
        Task Update(MovieModel movieModel);
        Task Delete(int id);
    }
}
