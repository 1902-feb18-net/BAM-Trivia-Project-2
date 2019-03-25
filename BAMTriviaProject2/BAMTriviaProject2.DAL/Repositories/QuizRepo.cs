using BLL.Library.IRepositories;
using BLL.Library.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMTriviaProject2.DAL.Repositories
{
    public class QuizRepo : IQuizRepo
    {
        private readonly ILogger<QuizRepo> _logger;
        public static BAMTriviaProject2Context _db { get; set; }
        private readonly IMapper _mapper;

        public QuizRepo(BAMTriviaProject2Context dbContext,
            ILogger<QuizRepo> logger, IMapper mapper)
        {
            _db = dbContext;
            _logger = logger;
            _mapper = mapper;
        }

        public QuizzesModel GetQuizById(int QId)
        {

            try
            {
                return _mapper.Map(_db.Quiz.Single(r => r.QuizId == QId));
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
                return _mapper.Map(_db.Quiz).ToList();
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

        public async Task<IEnumerable<QuizzesModel>> GetAllQuizesByCategoryAndDifficulty(string category, int difficulty)
        { 
            try
            {
                return _mapper.Map(await _db.Quiz
                   .Where(c => c.QuizCategory == category)
                   .Where(d => d.QuizDifficulty == difficulty)
                   .ToListAsync());
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
