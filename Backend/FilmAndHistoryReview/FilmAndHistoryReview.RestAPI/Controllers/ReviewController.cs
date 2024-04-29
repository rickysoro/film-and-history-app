using FilmAndHistoryReview.Core.Exceptions;
using FilmAndHistoryReview.Core.Manager;
using FilmAndHistoryReview.Core.Service;
using FilmAndHistoryReview.RestAPI.Mapper;
using FilmAndHistoryReview.RestAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace FilmAndHistoryReview.RestAPI.Controllers
{
    [ApiController]
    [Route("reviews")]
    public class ReviewController : ControllerBase
    {
        private ReviewManager _manager;

        public ReviewController(ReviewManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        [Route("/{id}")]
        public ActionResult<ReviewDto> GetReview([FromRoute(Name = "id")] int id)
        {
            try
            {
                var reviewToGet = _manager.GetReview(id);
                return Ok(ReviewDtoMapper.From(reviewToGet));
            }
            catch (ReviewNotFoundException exception)
            {
                return BadRequest(new ErrorResponse(exception.Message));
            }
        }

        [HttpGet]
        public ActionResult<List<ReviewDto>> GetAllReviews()
        {
            return Ok(_manager.GetAllReviews());
        }

        [HttpPost]
        public ActionResult<ReviewDto> AddReview([FromBody] ReviewRequest body)
        {
            try
            {
                var reviewToAdd = _manager.AddReview(body.UserId, body.MovieId, body.Comment);
                var uri = $"/reviews/{reviewToAdd.Id}";
                return Created(uri, ReviewDtoMapper.From(reviewToAdd));
            }
            catch (TextTooShortException exception)
            {
                return BadRequest(new ErrorResponse(exception.Message));
            }
        }

        [HttpPut]
        [Route("/{id}")]
        public ActionResult<ReviewDto> UpdateReview([FromRoute(Name = "id")] int id, string comment)
        {
            try
            {
                var reviewToUpdate = _manager.UpdateReview(id, comment);
                return Ok(ReviewDtoMapper.From(reviewToUpdate));
            }
            catch (ReviewNotFoundException exception)
            {
                return NotFound(new ErrorResponse(exception.Message));
            }
            catch (TextTooShortException exception)
            {
                return BadRequest(new ErrorResponse(exception.Message));
            }
        }

        [HttpDelete]
        [Route("/{id}")]
        public ActionResult<bool> DeleteReview([FromRoute(Name = "id")] int id)
        {
            try
            {
                _manager.DeleteReview(id);
                return Ok(true);
            }
            catch (ReviewNotFoundException exception)
            {
                return NotFound(new ErrorResponse(exception.Message));
            }
        }
    }
}
