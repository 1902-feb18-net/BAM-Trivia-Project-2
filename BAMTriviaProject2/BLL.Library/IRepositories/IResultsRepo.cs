using BLL.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Library.IRepositories
{
    public interface IResultsRepo
    {
        IEnumerable<ResultsModel> GetAllResults();
        List<ResultsModel> GetResultsByUserQuizId(int userQuizId);
        ResultsModel GetResultsById(int resultId);
        Task<int> AddResults(ResultsModel result);
        Task<int> SaveChangesAndCheckException();
    }
}
