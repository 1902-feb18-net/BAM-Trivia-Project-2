using BLL.Library.IRepositories;
using BLL.Library.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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
            return Mapper.Map(_db.Quiz.First(r => r.QuizId == QId)) ?? throw new ArgumentNullException("ID needs to be valid");
        }

        public List<QuizzesModel> GetAllQuizzes()
        {
            return Mapper.Map(_db.Quiz).ToList();
        }

        public List<QuizzesModel> GetAllQuizesByCategoryAndDifficulty(string category, int difficulty)
        {
            //return Mapper.Map(_db.Quiz.GroupBy(q => q.QuizCategory == category && q.QuizDifficulty == difficulty));
            List<QuizzesModel> list = new List<QuizzesModel>();
            return list;
        }
    }
}
