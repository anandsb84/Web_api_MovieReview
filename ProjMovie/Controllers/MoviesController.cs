using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjMovie.Models;
using ProjMovie.Services;
using System.Collections.Generic;

namespace ProjMovie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        IMovieService movieService;
        public MoviesController(IMovieService service)
        {
            movieService = service;
        }

        [HttpGet("GetReview/{movieID}")]
        public IActionResult GetReview(int movieID)
        {
            List<ReviewDb> lst;
            try
            {
               lst= movieService.MovieReviews(movieID);
                return Ok(lst);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost("AddNewMovie")]
        public IActionResult AddNewMovie(string movie,string review)
        {
            MovieDb m=new MovieDb();
            m.MovieName = movie;
            ReviewDb r=new ReviewDb();
            r.Review = review;
            int movieid;
            
            try
            {
                movieid = movieService.AddMovie(m);
                r.MovieId = movieid;
                movieService.AddReview(r);
                return Ok(r);

            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("GetMovies")]
        public IActionResult GetMovies()
        {
            List<MovieDb> movies;
            try
            {
                movies=movieService.GetAllMovies();
                return Ok(movies);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost("AddNewReview")]
        public IActionResult AddNewReview(int movieID,string review)
        {
            try
            {
                ReviewDb r=new ReviewDb();
                r.MovieId = movieID;
                r.Review = review;
                //MovieDb mov = new MovieDb();
                //mov.MovieName = movieName;
                //movieService.AddMovie(mov);
                //return Ok();
                movieService.AddReview(r);
                return Ok();

            }
            catch
            {
                return BadRequest();
            }

        }
        [HttpDelete("DeleteMovie/{movieId}")]
        public IActionResult DeleteMovie(int movieId)
        {
            
            try
            {
                movieService.DeleteReview(movieId);
                movieService.DeleteMovie(movieId);
                return Ok();

            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("EditReview")]
        public IActionResult EditReview(int ReviewId,string review)
        {
            try
            {
                movieService.UpdateReview(ReviewId, review);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }

        }
    }
}
