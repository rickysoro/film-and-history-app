using FilmAndHistoryReview.Core.Model;
using FilmAndHistoryReview.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmAndHistoryReview.DB.Mapper
{
    public class ReviewEntityMapper
    {
        public static Review From(ReviewEntity entity)
        {
            return new Review(entity.Id, entity.UserId, entity.MovieId, entity.Comment);
        }
    }
}
