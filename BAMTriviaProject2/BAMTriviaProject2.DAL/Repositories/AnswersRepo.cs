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
        public List<AnswerModel> GetAnswerByQuestion(int questionId)
        {
            try
            {
                return _mapper.Map(Context.Answers.Where(c => c.Qid == questionId)).ToList();
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
