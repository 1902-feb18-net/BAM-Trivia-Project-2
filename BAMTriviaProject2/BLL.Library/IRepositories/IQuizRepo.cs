using BLL.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Library.IRepositories
{
    public interface IQuizRepo
    {
        Task<int> AddQuiz(QuizzesModel quiz);
        QuizzesModel GetQuizById(int QId);
        IEnumerable<QuizzesModel> GetAllQuizzes();
        Task<IEnumerable<QuizzesModel>> GetAllQuizesByCategoryAndDifficulty(string category, int difficulty);
        int GetLastQuizId();
    }
}
