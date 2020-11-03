using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        private EntContext _context;

        public MovieController()
        {
            _context = new EntContext();
        }

        // GET: Movie
        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.genre).SingleOrDefault(m => m.id == id);

            if(movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }

        public ActionResult Add()
        {

            var gen = _context.Genre.ToList();
            var vm = new ManageMoviesViewModel
            {
                Genres = gen,
                
            };
            return View(vm);

        }

        [Route("Movie/Edit/{id}")]
        public ActionResult Edit(int id)
        {

            
            var mov = _context.Movies.SingleOrDefault(m => m.id == id);
            var gen = _context.Genre.ToList();
            var vm = new ManageMoviesViewModel
            {
                Genres = gen,
                movie = mov
            };


            return View(vm);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(ManageMoviesViewModel MovieVM)
        {

            var gen = _context.Genre.ToList();
            var mov = MovieVM.movie;
            var vm = new ManageMoviesViewModel
            {
                movie = mov,
                Genres = gen
            };

            if (!ModelState.IsValid)
            {
                if (MovieVM.movie.id == 0)
                {
                    vm.movie.id = 0;
                    return View("Add", vm);
                }
                else
                {
                    return View("Edit", vm);
                }
            }
            

            if(MovieVM.movie.id == 0)
            {
                _context.Movies.Add(MovieVM.movie);
            }
            else
            {
                var oldMovie = _context.Movies.Single(m => m.id == MovieVM.movie.id);
                //oldMovie.name = MovieVM.Movie.name;
                //oldMovie.releaseDate = MovieVM.Movie.releaseDate;
                //oldMovie.stock = MovieVM.Movie.stock;
                //oldMovie.genre = MovieVM.Movie.genre;
                oldMovie = MovieVM.movie;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Movie");
        }

    }
}