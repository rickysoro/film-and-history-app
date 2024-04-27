using System.ComponentModel;

namespace FilmAndHistoryReview.RestAPI.Model
{
    public class ReviewRequest
    {
        [DisplayName("user_id")]
        public int UserId { get; set; }

        [DisplayName("movie_id")]
        public int MovieId { get; set; }

        [DisplayName("comment")]
        public string Comment { get; set; }
    }
}
