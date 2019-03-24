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
    public class QuizRepo : IQuizRepo
    {
        private readonly ILogger<QuizRepo> _logger;
        public static BAMTriviaProject2Context _db { get; set; }

        public QuizRepo(BAMTriviaProject2Context dbContext,
            ILogger<QuizRepo> logger)
        {
            _db = dbContext;
            _logger = logger;

        }

        public QuizzesModel GetQuizById(int QId)
        {

            try
            {
                return Mapper.Map(_db.Quiz.Single(r => r.QuizId == QId));
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

        public List<QuizzesModel> GetAllQuizzes()
        {
            try
            {
                return Mapper.Map(_db.Quiz).ToList();
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

        public List<QuizzesModel> GetAllQuizesByCategoryAndDifficulty(string category, int difficulty)
        { 
            try
            {
                return Mapper.Map(_db.Quiz
                    .Where(c => c.QuizCategory == category)
                    .Where(d => d.QuizDifficulty == difficulty))
                    .ToList();
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
    }
}
