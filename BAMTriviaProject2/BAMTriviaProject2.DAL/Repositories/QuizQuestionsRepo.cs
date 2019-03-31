using BLL.Library.IRepositories;
using BLL.Library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMTriviaProject2.DAL.Repositories
{
    public class QuizQuestionsRepo : IQuizQuestionsRepo
    {
        private readonly ILogger<QuizQuestionsRepo> _logger;
        public BAMTriviaProject2Context _db { get; set; }
        private readonly IMapper _mapper;

        public QuizQuestionsRepo(BAMTriviaProject2Context dbContext,
            ILogger<QuizQuestionsRepo> logger, IMapper mapper)
        {
            _db = dbContext;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<int> SaveChangesAndCheckException()
        {
            try
            {
                await _db.SaveChangesAsync();
                return 0;
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError(ex.ToString());
                return 1;
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex.ToString());
                return 1;
            }
        }

        public List<QuestionsModel> GetQuestionsByQuizId(int QId)
        {
            try
            {
                List<QuizQuestionsModel> quizQuestions = _mapper.Map(_db.QuizQuestions.Where(q => q.QuizId == QId)).ToList();
                List<QuestionsModel> questions = _mapper.Map(_db.Questions).ToList();
                QuestionsModel question = new QuestionsModel();
                var targetQuestions = quizQuestions.Join(questions, qq => qq.Qid, q => q.Id, (qq, q) => new QuestionsModel()
                {
                    Id = q.Id,
                    AverageReview = q.AverageReview,
                    Category = q.Category,
                    Qstring = q.Qstring,
                    Rating = q.Rating,
                    Type = q.Type
                }).ToList();
                return targetQuestions;
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return null;
            }
        }

        public List<QuestionsModel> GetQuestionsByQuizAndQuestionId(int QId, int QuestionId)
        {
            List<QuestionsModel> list = new List<QuestionsModel>();
            return list;
        }

        public async Task<int> AddQuizQuestion(int quizId, int questionId)
        {
            QuizQuestionsModel newQuizQuestion = new QuizQuestionsModel
            {
                QuizId = quizId,
                Qid = questionId
            };

            var newQuizQuestionDAL = _mapper.Map(newQuizQuestion);
            _db.QuizQuestions.Add(newQuizQuestionDAL);
            return await SaveChangesAndCheckException();
        }
    }
}
