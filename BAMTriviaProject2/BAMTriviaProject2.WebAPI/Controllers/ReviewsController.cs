using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Library.IRepositories;
using BLL.Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BAMTriviaProject2.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly ILogger<ReviewsController> _logger;

        public IReviewRepo reviewsRepo { get; set; }

        public ReviewsController(IReviewRepo newReviewRepo, ILogger<ReviewsController> logger)
        {
            reviewsRepo = newReviewRepo;
            _logger = logger;
        }


        // GET: api/Reviews
        [HttpGet]
        public IEnumerable<ReviewsModel> Get()
        {
            return reviewsRepo.GetAllReviews();
        }

        // GET: api/Reviews
        [HttpGet("Quiz", Name ="GetAllQuizReviews")]
        public IEnumerable<ReviewsModel> GetReviewsQuiz()
        {
            return reviewsRepo.GetAllQuizReviews();
        }

        // GET: api/Reviews/Quizzes/{Id}
        [HttpGet("{id}", Name = "GetByReviewId")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ReviewsModel GetById(int id)
        {
            ReviewsModel review = reviewsRepo.GetByReviewId(id);
            return review;
        }

        // GET: api/Reviews/Quizzes/{Id}
        [HttpGet("Quizzes/{id}", Name = "GetReviewsByQuizId")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IEnumerable<ReviewsModel> GetReviewsByQuizId(int id)
        {
            IEnumerable<ReviewsModel> reviews = reviewsRepo.GetReviewsByQuizId(id);
            return reviews;
        }

        // GET: api/Reviews/Questions/{Id}
        [HttpGet("Questions/{id}", Name = "GetReviewsByQuestionId")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IEnumerable<ReviewsModel> GetReviewsByQuestionId(int id)
        {
            IEnumerable<ReviewsModel> reviews = reviewsRepo.GetReviewsByQuestionId(id);
            return reviews;
        }

        // GET: api/Reviews/Users/{Id}
        [HttpGet("Users/{id}", Name = "GetReviewsByUserId")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IEnumerable<ReviewsModel> GetReviewsByUserId(int id)
        {
            IEnumerable<ReviewsModel> reviews = reviewsRepo.GetReviewsByUserId(id);
            return reviews;
        }

        [HttpGet("Users/{id}/Quiz", Name = "GetReviewsByUserIdQuiz")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IEnumerable<ReviewsModel> GetReviewsByUserIdQuiz(int id)
        {
            IEnumerable<ReviewsModel> reviews = reviewsRepo.GetReviewsByUserIdQuizOnly(id);
            return reviews;
        }

        // POST: api/Review
        [HttpPost]
        [ProducesResponseType(typeof(ReviewsModel), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] ReviewsModel review)
        {
            await reviewsRepo.AddReview(review);
            return CreatedAtAction(nameof(GetById), new { id = review.Id }, review);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}", Name = "DeleteReviewsById")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            //answersRepo.DeleteAnswer(id);
            if (reviewsRepo.GetByReviewId(id) is ReviewsModel review) //if found
            {
                //delete user
                await reviewsRepo.DeleteReviewAsync(review.Id);
                await reviewsRepo.Save();
                return NoContent(); // 204
            }

            //if not found,
            return NotFound(); //404
        }
    }
}
