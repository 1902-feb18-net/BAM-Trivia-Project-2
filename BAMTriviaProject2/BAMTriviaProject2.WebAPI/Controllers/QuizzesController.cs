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
    public class QuizzesController : ControllerBase
    {
        private readonly ILogger<QuizzesController> _logger;

        public IQuizRepo quizRepo { get; set; }

        public IQuizQuestionsRepo quizQuestionRepo { get; set; }

        public QuizzesController(IQuizRepo _quizRepo, IQuizQuestionsRepo _quizQuestionRepo, ILogger<QuizzesController> logger)
        {
            quizRepo = _quizRepo;
            _logger = logger;
            quizQuestionRepo = _quizQuestionRepo;
        }


        // GET: Quizzes/Create
        //[HttpGet("{Quizzes}", Name = "Create")]
        [HttpGet]
        public IEnumerable<QuizzesModel> Get()
        {
            IEnumerable<QuizzesModel> quizzes = quizRepo.GetAllQuizzes();
            return quizzes;
        }


        // GET: Quizzes/Find/5
        [HttpGet("{id}", Name = "GetQuizById")]
        public ActionResult<QuizzesModel> Find(int id)
        {
            return quizRepo.GetQuizById(id);
        }

        // POST: Quizzes
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] QuizzesModel quizzesModel)
        {

            //finds all quizzes in the right category and right difficulty
            IEnumerable<QuizzesModel> quizzes = await quizRepo.GetAllQuizesByCategoryAndDifficulty(quizzesModel.Category, quizzesModel.Difficulty);
            List<QuizzesModel> quizzes2 = quizzes.ToList();
            //gets a random quiz out of the list of available ones
            Random random = new Random();
            int x = random.Next(quizzes2.Count);

            //gets the id of the quiz to use
            //int quizId = quizzes2[x].Id; //for when it's working

            int quizId = 1; //temporary

            //finds all questions that were on that quiz
            List<QuestionsModel> questions = quizQuestionRepo.GetQuestionsByQuizId(quizId);

            //QuizzesModel quiz = new QuizzesModel();
            //quiz.Id = 1;

            return CreatedAtAction(nameof(Create), questions);

        }

        // GET: Quizzes/Edit/5
        [HttpPut("{id}", Name = "EditQuizById")]
        public ActionResult<QuizzesModel> Edit(int id)
        {
            return quizRepo.GetQuizById(id);
        }

        //// POST: Quizzes/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return ViewResult();
        //    }
        //}

        // GET: Quizzes/Delete/5
        [HttpDelete("{id}", Name = "DeleteQuizById")]
        public ActionResult<QuizzesModel> Delete(int id)
        {
            return quizRepo.GetQuizById(id);
        }

        //// POST: Quizzes/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return ViewResult();
        //    }
        //}
    }
}