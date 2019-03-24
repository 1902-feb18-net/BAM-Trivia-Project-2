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
        private readonly IMapper _mapper;

        public UserQuizesRepo(BAMTriviaProject2Context dbContext,
            ILogger<UserQuizesRepo> logger, IMapper mapper)
        {
            _db = dbContext;
            _logger = logger;
            _mapper = mapper;
        }

        public List<UserQuizzesModel> GetUserQuizesByUser(int userId)
        {
            try
            {
                return _mapper.Map(_db.UserQuizzes.Where(u => u.UserId == userId)).ToList();
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
