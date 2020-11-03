using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;
using AutoMapper;
using System.Data.Entity;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private EntContext _context;

        public MoviesController()
        {
            _context = new EntContext();
        }

        public IEnumerable<MovieDto> GetMovies()
        {

            return _context.Movies
                .Include(m => m.genre)
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);

        }

        public IHttpActionResult GetMovie(int id)
        {
            var mov = _context.Movies
                .Include(m => m.genre)
                .SingleOrDefault(m => m.id == id);

            if(mov == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Movie, MovieDto>(mov));
        }

        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var mov = Mapper.Map<MovieDto, Movie>(movDto);
            _context.Movies.Add(mov);
            _context.SaveChanges();

            movDto.id = mov.id;

            return Created(new Uri(Request.RequestUri + "/" + mov.id), movDto);
        }

        [HttpPut]
        public void UpdateMovie(int id, MovieDto movDto)
        {

            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var mov = _context.Movies.SingleOrDefault(m => m.id == id);
            if(mov == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            Mapper.Map<MovieDto, Movie>(movDto, mov);

            _context.SaveChanges();

        }

        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var mov = _context.Movies.SingleOrDefault(m => m.id == id);
            if(mov == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(mov);
            _context.SaveChanges();

            return Ok(mov);

        }

    }
}