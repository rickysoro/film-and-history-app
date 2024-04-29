using FilmAndHistoryReview.Core.Model;
using FilmAndHistoryReview.RestAPI.Model;
using System.Net.NetworkInformation;

namespace FilmAndHistoryReview.RestAPI.Mapper
{
    public class ReviewDtoMapper
    {
        public static ReviewDto From(Review review) => new ReviewDto
        {
            Id = review.Id,
            UserId = review.UserId,
            MovieId = review.MovieId,
            Comment = review.Comment,
        };
    }
}
