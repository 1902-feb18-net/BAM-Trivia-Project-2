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
    public class ResultsRepo : IResultsRepo
    {
        private readonly ILogger<ResultsRepo> _logger;
        private readonly IMapper _mapper;
        public static BAMTriviaProject2Context Context { get; set; }

        public ResultsRepo(BAMTriviaProject2Context dbContext,
            ILogger<ResultsRepo> logger, IMapper mapper)
        {
            Context = dbContext;
            _logger = logger;
            _mapper = mapper;

        }

        public IEnumerable<ResultsModel> GetAllResults()
        {
            try
            {
                return _mapper.Map(Context.Results);
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

        public List<ResultsModel> GetResultsByUserQuizId(int userQuizId)
        {
            try
            {
                List<ResultsModel> results = _mapper.Map(Context.Results.Where(r => r.UserQuizId == userQuizId)).ToList();
                return results;
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

        public async Task<int> AddResults(ResultsModel result)
        {
            var newResult = _mapper.Map(result);
            Context.Results.Add(newResult);
            return await SaveChangesAndCheckException();
        }

        public async Task<int> SaveChangesAndCheckException()
        {
            try
            {
                await Context.SaveChangesAsync();
                return 0;
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError(ex.ToString());
                return 1;
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex.ToString());
                return 1;
            }
        }

        public ResultsModel GetResultsById(int resultId)
        {
            try
            {
                return _mapper.Map(Context.Results.Single(r => r.ResultId == resultId));
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
