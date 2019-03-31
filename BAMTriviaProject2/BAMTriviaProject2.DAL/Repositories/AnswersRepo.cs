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
        private BAMTriviaProject2Context Context { get; set; }

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

        public List<AnswerModel> GetQuizAnswers(int quizId)
        {
            try
            {
                List<QuizQuestionsModel> questions = _mapper.Map(Context.QuizQuestions.Where(c => c.QuizId == quizId)).ToList();
                List<AnswerModel> answers = _mapper.Map(Context.Answers.Where(a => questions.Any(q => q.Qid == a.Qid))).ToList();
                for (int i = 0; i < answers.Count(); i++)
                {
                    answers[i].QuestionText = Context.Questions.Single(q => q.Qid == answers[i].QuestionId).Qstring;

                }
                return answers;
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

        public async Task<int> AddAnswer(AnswerModel answer)
        {
            var value = _mapper.Map(answer);
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

        public async Task<int> DeleteAnswer(int Id)
        {
            try
            {
                Context.Remove(Context.Answers.Find(Id));
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

        public async Task<int> Save()
        {
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
