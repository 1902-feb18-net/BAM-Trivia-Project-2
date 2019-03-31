using BLL.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Library.IRepositories
{
    public interface IUserQuizzesRepo
    {
        Task<IEnumerable<UserQuizzesModel>> GetUserQuizesByUser(int userId);
        List<UserQuizzesModel> GetUserQuizesByQuiz(int QId);
        UserQuizzesModel GetLastQuiz();
        Task<int> AddUserQuiz(UserQuizzesModel newUserQuizzesModel);
        Task<int> GetLastUserQuizId(int userId);
        double GetMaxScoreOfQuiz(QuizzesModel quiz);
    }
}
