using Microsoft.EntityFrameworkCore;
using Movie.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Repository
{
    public class MovieRepository : IMovieRepository
    {

        private readonly ApplicationDbContext _context;

        public MovieRepository(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<MovieModel> Create(MovieModel movieModel)
        {
            _context.MovieModels.Add(movieModel);
            await _context.SaveChangesAsync();
            return movieModel;
        }

        public async Task Delete(int id)
        {
            var movie = await _context.MovieModels.FindAsync(id);
            _context.MovieModels.Remove(movie);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MovieModel>> GetAllMovies()
        {
            return await _context.MovieModels.Where(x => !x.IsDeleted).ToListAsync();
        }

        public async Task<MovieModel> GetMovieById(int id)
        {
            return await _context.MovieModels.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(MovieModel movieModel)
        {
            _context.Update(movieModel);
            await _context.SaveChangesAsync();
        }
    }
}
