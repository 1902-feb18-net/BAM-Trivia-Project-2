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
    public class AnswersRepo : IAnswersRepo
    {
        private readonly ILogger<AnswersRepo> _logger;
        private readonly IMapper _mapper;
        public static BAMTriviaProject2Context Context { get; set; }

        public AnswersRepo(BAMTriviaProject2Context dbContext,
            ILogger<AnswersRepo> logger, IMapper mapper)
        {
            Context = dbContext;
            _logger = logger;
            _mapper = mapper;

        }

        // public List<QuestionsModel> GetQuestionByCategory(string category)
        public async Task<IEnumerable<AnswerModel>> GetAnswerByQuestion(int questionId)
        {
            try
            {
                return _mapper.Map(await Context.Answers.Where(c => c.Qid == questionId).ToListAsync());
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

        public void AddAnswer(AnswerModel answer)
        {
            var value = _mapper.Map(answer);
            Context.Add(value);
            Context.SaveChanges();
        }

        public AnswerModel GetAnswerById(int answerId)
        {
            try
            {
                return _mapper.Map(Context.Answers.Single(a => a.Aid == answerId));
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

        public void DeleteAnswer(int Id)
        {
            Context.Remove(Context.Answers.Find(Id));
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
