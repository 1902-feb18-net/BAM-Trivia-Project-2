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
    public class AnswersController : ControllerBase
    {
        private readonly ILogger<AnswersController> _logger;

        public IAnswersRepo answersRepo { get; set; }

        public AnswersController(IAnswersRepo newAnswerRepo, ILogger<AnswersController> logger)
        {
            answersRepo = newAnswerRepo;
            _logger = logger;
        }

        // GET: api/Answers/5
        [HttpGet("{id}", Name = "GetAnswersByQuestionId")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IEnumerable<AnswerModel> GetAnswersByQuestionId(int id)
        {
            return answersRepo.GetAnswerByQuestion(id);
        }

        //public IEnumerable<ApiCharacter> Get()
        //{
        //    return _characterRepository.GetAll().Select(_mapper.Map);
        //    // whenever an action method returns something that's not an IActionResult
        //    // ... it's automatically wrapped in 200 OK response.
        //}

        //// POST: api/Answers
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/Answers/5
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
