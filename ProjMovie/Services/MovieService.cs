using ProjMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjMovie.Services
{
    public class MovieService : IMovieService
    {
        private Context _context;
        public MovieService(Context context)
        {
            _context = context;
        }

        public void DeleteReview(int id)
        {
            List<ReviewDb> rev;
            try
            {
                rev = _context.ReviewDbs.Where(x => x.MovieId == id).ToList();
                _context.ReviewDbs.RemoveRange(rev);
                _context.SaveChanges();


            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void DeleteMovie(int id)
        {
            MovieDb movie;
            try
            {
               movie= _context.MovieDbs.Find(id);
                _context.MovieDbs.Remove(movie);
                _context.SaveChanges();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void AddReview(ReviewDb rev)
        {
            List<ReviewDb> reviews;
            try
            {
                reviews = _context.ReviewDbs.ToList();
                //if (reviews.Count > 0)
                //{
                //    rev.ReviewId = reviews[reviews.Count - 1].ReviewId + 1;
                //}
                //else
                //    rev.ReviewId = 1;
                _context.ReviewDbs.Add(rev);
                _context.SaveChanges();
                //return 0;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public int AddMovie(MovieDb movie)
        {
            int movieId;
            List<MovieDb> movielst;
            try
            {
                movielst = _context.MovieDbs.ToList();
                if (movielst.Count > 0)
                    movieId = movielst[movielst.Count - 1].MovieId + 1;
                else
                    movieId = 1;

                _context.MovieDbs.Add(movie);
                _context.SaveChanges();
                return movieId;

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            throw new System.NotImplementedException();
        }

         
        public List<MovieDb> GetAllMovies()
        {
            return _context.MovieDbs.ToList();
        }

        public List<ReviewDb> MovieReviews(int movieId)
        {
            List<ReviewDb> reviews;
            try
            {
                reviews = _context.Set<ReviewDb>().Where(x=>x.MovieId == movieId).ToList();
                return reviews;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            throw new System.NotImplementedException();
        }

        public void RemoveMovieReview(int ReviewId)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateReview(int ReviewId, string rev)
        {
            ReviewDb revs;
            try
            {
                revs=_context.ReviewDbs.FirstOrDefault(x => x.ReviewId == ReviewId);
                revs.Review = rev;
                _context.ReviewDbs.Update(revs);
                _context.SaveChanges();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }

            //sthrow new System.NotImplementedException();
        }

        //List<string> IMovieService MovieReviews(int movieId)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
