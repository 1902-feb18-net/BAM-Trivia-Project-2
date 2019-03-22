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
    public class QuestionRepo : IQuestionRepo
    {
        private readonly ILogger<QuestionRepo> _logger;
        public static BAMTriviaProject2Context Context { get; set; }

        public QuestionRepo(BAMTriviaProject2Context dbContext,
            ILogger<QuestionRepo> logger)
        {
            Context = dbContext;
            _logger = logger;

        }

        public QuestionsModel GetQuestionById(int questionId)
        {
            try
            {
                return Mapper.Map(Context.Questions.Single(u => u.Qid == questionId));
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

        public List<QuestionsModel> GetQuestionByCategory(string category)
        {
            List<QuestionsModel> list = new List<QuestionsModel>();
            return list;
        }

        public List<QuestionsModel> GetQuestionByDifficulty(int difficulty)
        {
            List<QuestionsModel> list = new List<QuestionsModel>();
            return list;
        }

        public List<QuestionsModel> GetQuestionByDifficultyAndCategory(int difficulty, string category)
        {
            List<QuestionsModel> list = new List<QuestionsModel>();
            return list;
        }
    }
}
