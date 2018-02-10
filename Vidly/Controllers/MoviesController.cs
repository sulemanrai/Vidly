using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;
using System.Data.Entity.Validation;


namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() {Name = "Shrek!"};
            var customers = new List<Customer>
            {
                new Customer{Name = "Customer 1"},
                new Customer{Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };
            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(p => p.Id == id);
            var viewModel = new MovieFormViewModel(movie)
            {

                GenreTypes = _context.Genres.ToList(),                
            };
            return View(viewModel);
            //return Content("id " + id);
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        public ActionResult Index()
        {
            var movies = GetMovies();

            if (User.IsInRole(RoleName.CanManageMovies))
            //var movies = GetMovies();
                return View("List", movies);
            return View("ReadOnlyList", movies);
        }

        [Authorize(Roles= RoleName.CanManageMovies)]
        public ActionResult New()
        {
            
            var viewModel = new MovieFormViewModel()
            {
                
                GenreTypes = _context.Genres.ToList(),
                
            };
            return View("MovieForm",viewModel);
        }
        public List<Movie> GetMovies()
        {

            // var movies = new List<Movie>
            //   {
            //      new Movie{Name = "Shrek",Id =1},
            //      new Movie{Name = "Wall-E",Id =2}
            //    };

            var movies = _context.Movies.Include(m => m.Genre).ToList();

            return movies;
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(p => p.Id == id);
            return View(movie);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    GenreTypes = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.Genre = movie.Genre;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        [HttpPost]
        public ActionResult Update(Movie movie)
        {
            var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);
            movieInDb.Name = movie.Name;
            movieInDb.GenreId = movie.GenreId;
            movieInDb.NumberInStock = movie.NumberInStock;
            movieInDb.ReleaseDate = movie.ReleaseDate;
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

    }
}