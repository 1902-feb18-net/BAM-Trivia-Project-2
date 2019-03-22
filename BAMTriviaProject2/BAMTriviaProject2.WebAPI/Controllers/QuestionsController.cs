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
    public class QuestionsController : ControllerBase
    {
        private readonly ILogger<QuestionsController> _logger;

        //public UsersController(IUsersRepo newUsersRepo, ILogger<UsersController> logger)
        //{
        //    usersRepo = newUsersRepo;
        //    _logger = logger;
        //}

        //public IUsersRepo usersRepo { get; set; }
        public IQuestionRepo questionsRepo { get; set; }

        public QuestionsController(IQuestionRepo newQuestionsRepo, ILogger<QuestionsController> logger)
        {
            questionsRepo = newQuestionsRepo;
            _logger = logger;
        }

        // GET: api/Questions
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "We are in Questions" };
        }

        // GET: api/Questions/5
        [HttpGet("{id}", Name = "GetQuestionById")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<QuestionsModel> Get(int id)
        {
            return questionsRepo.GetQuestionById(id);
            //return usersRepo.GetUserById(id);
        }

        //// POST: api/Questions
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/Questions/5
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
