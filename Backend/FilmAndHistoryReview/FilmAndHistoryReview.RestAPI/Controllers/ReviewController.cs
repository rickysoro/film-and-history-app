using FilmAndHistoryReview.Core.Manager;
using FilmAndHistoryReview.RestAPI.Mapper;
using FilmAndHistoryReview.RestAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace FilmAndHistoryReview.RestAPI.Controllers
{
    [ApiController]
    [Route("reviews")]
    public class ReviewController : ControllerBase
    {
        ReviewManager _manager;

        public ReviewController(ReviewManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        [Route("/{id}")]
        public ActionResult<ReviewDto> GetReview([FromRoute(Name = "id")]int id)
        {
            var reviewToGet = _manager.GetReview(id);
            return Ok(ReviewDtoMapper.From(reviewToGet));
        }


    }
}
