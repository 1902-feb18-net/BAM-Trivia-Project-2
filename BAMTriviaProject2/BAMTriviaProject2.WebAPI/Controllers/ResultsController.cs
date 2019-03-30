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
    public class ResultsController : ControllerBase
    {
        private readonly ILogger<ResultsController> _logger;

        public IResultsRepo resultsRepo { get; set; }

        public ResultsController(IResultsRepo newResultsRepo, ILogger<ResultsController> logger)
        {
            resultsRepo = newResultsRepo;
            _logger = logger;
        }

        // GET: api/Results
        [HttpGet]
        public IEnumerable<ResultsModel> Get()
        {
            return resultsRepo.GetAllResults();
        }

        [HttpGet("{id}", Name = "GetResultByResultId")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ResultsModel> GetById(int id)
        {
            return resultsRepo.GetResultsById(id);
        }

        // GET: api/Results/UserQuizzes/{id}
        [HttpGet("UserQuizzes/{id}", Name = "GetResultsByUserQuizId")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IEnumerable<ResultsModel> GetByUserQuizzesId(int id)
        {
            IEnumerable<ResultsModel> results = resultsRepo.GetResultsByUserQuizId(id);
            return results;
        }

        // POST: api/Results
        [HttpPost]
        [ProducesResponseType(typeof(AnswerModel), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] ResultsModel result)
        {
            resultsRepo.AddResults(result);
            return CreatedAtAction(nameof(GetById), new { id = result.ResultId }, result.ResultId);
        }
    }
}
