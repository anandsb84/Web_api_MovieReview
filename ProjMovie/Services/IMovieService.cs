using ProjMovie.Models;
using System;
using System.Collections.Generic;

namespace ProjMovie.Services
{
    public interface IMovieService
    {
        List<ReviewDb> MovieReviews(int movieId);
        public List<MovieDb> GetAllMovies();

        int AddMovie(MovieDb movie);

        void AddReview(ReviewDb movie);

        void DeleteReview(int id);

        void DeleteMovie(int id);

        void RemoveMovieReview(int ReviewId);

        void UpdateReview(int ReviewId, string rev);






    }
}
