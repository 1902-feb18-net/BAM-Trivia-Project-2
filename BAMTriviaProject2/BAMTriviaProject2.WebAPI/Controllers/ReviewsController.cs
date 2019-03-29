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

        //// POST: api/Reviews
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/Reviews/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
