using FilmAndHistoryReview.Core.Exceptions;
using FilmAndHistoryReview.Core.Model;
using FilmAndHistoryReview.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmAndHistoryReview.Core.Manager
{
    public class ReviewManager
    {
        IStorageService _storageService;

        public ReviewManager(IStorageService storageService)
        {
            _storageService = storageService;
        }

        public Review GetReview(int id) => _storageService.GetReview(id);

        public List<Review> GetAllReviews() => _storageService.GetAllReviews();

        public Review AddReview(int userId, int movieId, string comment)
        {
            if (comment.Length < 10) throw new TextTooShortException();
            return _storageService.AddReview(userId, movieId, comment);
        }

        public Review UpdateReview(int id, string comment)
        {
            if (comment.Length < 10) throw new TextTooShortException();
            return _storageService.UpdateReview(id, comment);
        }

        public void DeleteReview(int id) => _storageService.DeleteReview(id);
    }
}
