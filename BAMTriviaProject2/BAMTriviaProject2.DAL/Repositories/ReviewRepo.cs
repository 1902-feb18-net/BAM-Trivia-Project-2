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
    public class ReviewRepo : IReviewRepo
    {
        private readonly ILogger<ReviewRepo> _logger;
        private readonly IMapper _mapper;
        public static BAMTriviaProject2Context Context { get; set; }

        public ReviewRepo(BAMTriviaProject2Context dbContext,
            ILogger<ReviewRepo> logger, IMapper mapper)
        {
            Context = dbContext;
            _logger = logger;
            _mapper = mapper;

        }
        public List<ReviewsModel> GetReviewsByQuizId(int quizId)
        {
            try
            {
                List<ReviewsModel> reviews = _mapper.Map(Context.Reviews.Where(r => r.QuizId == quizId)).ToList();
                return reviews;
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

        public List<ReviewsModel> GetReviewsByQuestionId(int questionId)
        {
            try
            {
                List<ReviewsModel> reviews = _mapper.Map(Context.Reviews.Where(r => r.Qid == questionId)).ToList();
                return reviews;
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

        public List<ReviewsModel> GetReviewsByUserId(int userId)
        {
            try
            {
                List<ReviewsModel> reviews = _mapper.Map(Context.Reviews.Where(r => r.UserId == userId)).ToList();
                return reviews;
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

        public IEnumerable<ReviewsModel> GetAllReviews()
        {
            try
            {
                return _mapper.Map(Context.Reviews);
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
