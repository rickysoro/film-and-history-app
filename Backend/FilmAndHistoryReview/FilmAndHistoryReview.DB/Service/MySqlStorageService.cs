using FilmAndHistoryReview.Core.Exceptions;
using FilmAndHistoryReview.Core.Model;
using FilmAndHistoryReview.Core.Service;
using FilmAndHistoryReview.DB.Mapper;
using FilmAndHistoryReview.DB.Model;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmAndHistoryReview.DB.Service
{
    public class MySqlStorageService : IStorageService
    {
        private ApplicationContext _context;

        public MySqlStorageService()
        {
            _context = new();
            _context.Database.EnsureCreated();
        }

        public Review AddReview(int userId, int movieId, string comment)
        {
            var reviewToAdd = new ReviewEntity() 
            { UserId = userId, MovieId = movieId, Comment = comment };
            _context.Add(reviewToAdd);
            _context.SaveChanges();
            return ReviewEntityMapper.From(reviewToAdd);
        }

        public void DeleteReview(int id)
        {
            var reviewToDelete = FindReviewByIdOrFail(id);
            _context.Reviews.Remove(reviewToDelete);
            _context.SaveChanges();
        }

        public List<Review> GetAllReviews() => _context.Reviews.Select(review => ReviewEntityMapper.From(review)).ToList();

        public Review GetReview(int id)
        {
            var reviewToGet = FindReviewByIdOrFail(id);
            return ReviewEntityMapper.From(reviewToGet);
        }

        public Review UpdateReview(int id, string comment)
        {
            var reviewToUpdate = FindReviewByIdOrFail(id);
            reviewToUpdate.Comment = comment;
            _context.SaveChanges();
            return ReviewEntityMapper.From(reviewToUpdate); 
        }

        private ReviewEntity FindReviewByIdOrFail(int id)
        {
            var reviewToFind = _context.Reviews.Find(id);
            if (reviewToFind == null) throw new ReviewNotFoundException(id);
            return reviewToFind;
        }
    }
}
