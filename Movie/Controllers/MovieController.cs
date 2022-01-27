using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.Model;
using Movie.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Movie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;

        public MovieController(IMovieRepository movieRepository) 
        {
            _movieRepository = movieRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<MovieModel>> GetAllMovies() 
        {
            return await _movieRepository.GetAllMovies();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieModel>> GetMovieById(int id)
        {
            return await _movieRepository.GetMovieById(id);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public async Task<ActionResult<MovieModel>> Create([FromBody] MovieModel movieModel)
        {
            var newMovie = await _movieRepository.Create(movieModel);
            return CreatedAtAction(nameof(GetMovieById), new { id = newMovie.Id }, newMovie);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut]
        public async Task<ActionResult<MovieModel>> Update([FromBody] MovieModel movieModel)
        {
            var movie = await _movieRepository.GetMovieById(movieModel.Id);
            if (movie == null)
                return BadRequest();

            await _movieRepository.Update(movieModel);
            return Ok();
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var movie = await _movieRepository.GetMovieById(id);
            if (movie == null)
                return NotFound();

            movie.IsDeleted = true;
            await _movieRepository.Update(movie);
            return Ok();
        }
    }
}
