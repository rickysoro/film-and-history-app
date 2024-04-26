using FilmAndHistoryReview.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmAndHistoryReview.Core.Service
{
    public interface IStorageService
    {
        public Review GetReview(int id);

        public List<Review> GetAllReviews();

        public Review AddReview(int userId, int movieId, string comment);

        public Review UpdateReview(int id, string comment);

        public void DeleteReview(int id);
    }
}
