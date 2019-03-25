using BLL.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Library.IRepositories
{
    public interface IQuizRepo
    {
        QuizzesModel GetQuizById(int QId);

        List<QuizzesModel> GetAllQuizzes();

        Task<IEnumerable<QuizzesModel>> GetAllQuizesByCategoryAndDifficulty(string category, int difficulty);

    }
}
