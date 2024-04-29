using FilmAndHistoryReview.Core.Exceptions;
using FilmAndHistoryReview.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmAndHistoryReview.Core.Service
{
    public class InMemoryStorageService : IStorageService
    {
        public List<Review> _reviews;

        public InMemoryStorageService() 
        { 
            _reviews = new List<Review>();
        }

        public Review AddReview(int userId, int movieId, string comment)
        {
            var id = GenerateId();
            var reviewToAdd = new Review(id, userId, movieId, comment);
            _reviews.Add(reviewToAdd);
            return reviewToAdd;
        }

        public void DeleteReview(int id)
        {
            var reviewToDelete = FindReviewByIdOrFail(id);
            _reviews.Remove(reviewToDelete);
        }

        public List<Review> GetAllReviews() => _reviews;

        public Review GetReview(int id) => FindReviewByIdOrFail(id);

        public Review UpdateReview(int id, string comment)
        {
            var reviewToUpdate = FindReviewByIdOrFail(id);
            reviewToUpdate.Comment = comment;
            return reviewToUpdate;
        }

        private Review FindReviewByIdOrFail(int id)
        {
            var reviewToFind = _reviews.FirstOrDefault(review => review.Id == id);
            if (reviewToFind == null) throw new ReviewNotFoundException(id);
            return reviewToFind;
        }

        private int GenerateId()
        {
            if (_reviews.Count == 0) return 1;
            return _reviews.Select(review => review.Id).Max() + 1;
        }
    }
}
