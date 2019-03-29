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
        public IUserQuizzesRepo _userQuizzesRepo { get; set; }
        public IQuizQuestionsRepo quizQuestionRepo { get; set; }
        public IAnswersRepo _answersRepo { get; set; }
        public IQuestionRepo _questionsRepo { get; set; }


        public QuizzesController(IQuizRepo _quizRepo,
            IUserQuizzesRepo userQuizzesRepo,
            IQuizQuestionsRepo _quizQuestionRepo,
            IAnswersRepo answersRepo,
            IQuestionRepo questionsRepo,
            ILogger<QuizzesController> logger)
        {
            quizRepo = _quizRepo;
            _userQuizzesRepo = userQuizzesRepo;
            _logger = logger;
            quizQuestionRepo = _quizQuestionRepo;
            _answersRepo = answersRepo;
            _questionsRepo = questionsRepo;
        }


        // GET: Quizzes/Create
        //[HttpGet("{Quizzes}", Name = "Create")]
        [HttpGet]
        public IEnumerable<QuizzesModel> Get()
        {
            IEnumerable<QuizzesModel> quizzes = quizRepo.GetAllQuizzes();
            return quizzes;
        }

        [HttpGet]
        [Route("Latest")]
        public UserQuizzesModel GetLastQuiz()
        {
            UserQuizzesModel quiz = _userQuizzesRepo.GetLastQuiz();
            return quiz;
        }

        [HttpGet]
        [Route("{id}/Answers")]
        public IEnumerable<AnswerModel> GetQuizAnswers(int id)
        {
            IEnumerable<AnswerModel> answers = _answersRepo.GetQuizAnswers(id);
            return answers;
        }


        //GET: Quizzes/Find/5
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
            int quizId = quizzes2[x].Id; //for when it's working

            //int quizId = 1; //temporary

            //finds all questions that were on that quiz
            List<QuestionsModel> questions = quizQuestionRepo.GetQuestionsByQuizId(quizId);

            //QuizzesModel quiz = new QuizzesModel();
            //quiz.Id = 1;

            return CreatedAtAction(nameof(Create), questions);

        }

        [HttpPost]
        [Route("Random")]
        public async Task<ActionResult> CreateRandomQuiz(QuizzesModel quiz)
        {
            Random random = new Random();

            // Quiz
            quiz.MaxScore = 10;

            // Get some random quiz questions based upon difficulty
            int numQuestions = 10;
            List<QuestionsModel> questions1 = _questionsRepo.GetQuestionByDifficultyAndCategory(
                 quiz.Difficulty, quiz.Category).Result;
            List<QuestionsModel> questions2 = new List<QuestionsModel>();
            List<QuestionsModel> questions3 = new List<QuestionsModel>();
            if (quiz.Difficulty == 1)
            {
                questions2 = _questionsRepo.GetQuestionByDifficultyAndCategory(
                3, quiz.Category).Result;
            }
            else
            {
                questions2 = _questionsRepo.GetQuestionByDifficultyAndCategory(
                quiz.Difficulty - 1, quiz.Category).Result;
            }

            if (quiz.Difficulty == 5)
            {
                questions3 = _questionsRepo.GetQuestionByDifficultyAndCategory(
                3, quiz.Category).Result;
            }
            else
            {
                questions3 = _questionsRepo.GetQuestionByDifficultyAndCategory(
                quiz.Difficulty + 1, quiz.Category).Result;
            }
            List<QuestionsModel> quizQuestionsPool = new List<QuestionsModel>();
            foreach (var item in questions1)
            {
                quizQuestionsPool.Add(item);
            }
            foreach (var item in questions2)
            {
                quizQuestionsPool.Add(item);
            }
            foreach (var item in questions3)
            {
                quizQuestionsPool.Add(item);
            }

            List<QuestionsModel> quizQuestions = new List<QuestionsModel>();
            int randNum;
            for (int i = 0; i < numQuestions; i++)
            {
                randNum = random.Next() % (15 - i);
                //if (quizQuestionsPool[i] != )
                //{

                //}
                quizQuestions.Add(quizQuestionsPool[randNum]);
                quizQuestionsPool.RemoveAt(randNum);
            }

            await quizRepo.AddQuiz(quiz);
            int lastQuizId = quizRepo.GetLastQuizId();
            quiz.Id = lastQuizId;

            for (int i = 0; i < quizQuestions.Count(); i++)
            {
                await quizQuestionRepo.AddQuizQuestion(lastQuizId, quizQuestions[i].Id);
            }

            return CreatedAtAction(nameof(Create), quiz);
        }

        // POST: Quizzes/Answers

        [HttpPost("Answers")]
        //[ProducesResponseType(typeof(List<AnswerModel>), StatusCodes.Status201Created)]
        public async Task<ActionResult> Answer([FromBody] List<QuestionsModel> quizQuestions)
        {
            List<AnswerModel> answers = new List<AnswerModel>();
            
            for (int i = 0; i < quizQuestions.Count; i++)
            {
                IEnumerable<AnswerModel> Ianswers = await _answersRepo.GetAnswerByQuestion(quizQuestions[i].Id);
                foreach (var item in Ianswers)
                {
                    answers.Add(item);
                }
            }

            return CreatedAtAction(nameof(Answer), answers);
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