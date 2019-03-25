using BLL.Library.IRepositories;
using BLL.Library.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BAMTriviaProject2.DAL.Repositories
{
    public class QuizQuestionsRepo : IQuizQuestionsRepo
    {
        private readonly ILogger<QuizQuestionsRepo> _logger;
        public static BAMTriviaProject2Context _db { get; set; }
        private readonly IMapper _mapper;

        public QuizQuestionsRepo(BAMTriviaProject2Context dbContext,
            ILogger<QuizQuestionsRepo> logger, IMapper mapper)
        {
            _db = dbContext;
            _logger = logger;
            _mapper = mapper;
        }

        public List<QuestionsModel> GetQuestionsByQuizId(int QId)
        {
            try
            {
                List<QuizQuestionsModel> quizQuestions = _mapper.Map(_db.QuizQuestions.Where(q => q.QuizId == QId)).ToList();
                List<QuizzesModel> quizzes = _mapper.Map(_db.Quiz).ToList();
                QuestionsModel questions = new QuestionsModel();
                var targetQuestions = quizQuestions.Join(quizzes, qq => qq.Qid, q => q.Id, (qq, q) => questions).ToList();
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
    }
}
