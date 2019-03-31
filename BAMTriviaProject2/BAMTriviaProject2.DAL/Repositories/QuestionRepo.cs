using BLL.Library.IRepositories;
using BLL.Library.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BAMTriviaProject2.DAL.Repositories
{
    public class QuestionRepo : IQuestionRepo
    {
        private readonly ILogger<QuestionRepo> _logger;
        private readonly IMapper _mapper;
        private BAMTriviaProject2Context Context { get; set; }

        public QuestionRepo(BAMTriviaProject2Context dbContext,
            ILogger<QuestionRepo> logger, IMapper mapper)
        {
            Context = dbContext;
            _logger = logger;
            _mapper = mapper;

        }

        public QuestionsModel GetQuestionById(int questionId)
        {
            try
            {
                return _mapper.Map(Context.Questions.Single(u => u.Qid == questionId));
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


        // grab questions by category: Movie, QC, Beer are the current ones
        public List<QuestionsModel> GetQuestionByCategory(string category)
        {

            try
            {
                return _mapper.Map(Context.Questions.Where(c => c.Qcategory == category)).ToList();
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

        public List<BLL.Library.Models.QuestionsModel> GetQuestionByDifficulty(int difficulty)
        {
            try
            {
                return _mapper.Map(Context.Questions.Where(c => c.Qrating == difficulty)).ToList();
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

        public async Task<List<BLL.Library.Models.QuestionsModel>> GetQuestionByDifficultyAndCategory(int difficulty, string category)
        {
            try
            {
                return _mapper.Map(Context.Questions
                    .Where(c => c.Qcategory == category)
                    .Where(d => d.Qrating == difficulty))
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

        public async Task<int> AddQuestion(BLL.Library.Models.QuestionsModel question)
        {
            var value = _mapper.Map(question);
            Context.Add(value);

            try
            {
                await Context.SaveChangesAsync();
                return 1;
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError(ex.ToString());
                return 0;
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex.ToString());
                return 0;
            }
        }
    }
}
