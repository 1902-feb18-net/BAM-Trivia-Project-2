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
    public class UserQuizesRepo : IUserQuizzesRepo
    {

        private readonly ILogger<UserQuizesRepo> _logger;
        public static BAMTriviaProject2Context _db { get; set; }

        public UserQuizesRepo(BAMTriviaProject2Context dbContext,
            ILogger<UserQuizesRepo> logger)
        {
            _db = dbContext;
            _logger = logger;
        }

        public List<UserQuizzesModel> GetUserQuizesByUser(int userId)
        {
            try
            {
                return Mapper.Map(_db.UserQuizzes.Where(u => u.UserId == userId)).ToList();
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

        public List<UserQuizzesModel> GetUserQuizesByQuiz(int QId)
        {
            List<UserQuizzesModel> list = new List<UserQuizzesModel>();
            return list;
        }

        public double GetMaxScoreOfQuiz(QuizzesModel quiz)
        {
            return 0.0;
        }

    }
}
