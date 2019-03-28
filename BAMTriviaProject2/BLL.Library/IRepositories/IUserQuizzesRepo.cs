using BLL.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Library.IRepositories
{
    public interface IUserQuizzesRepo
    {
        List<UserQuizzesModel> GetUserQuizesByUser(int userId);

        List<UserQuizzesModel> GetUserQuizesByQuiz(int QId);
        UserQuizzesModel GetLastQuiz();

        double GetMaxScoreOfQuiz(QuizzesModel quiz);
    }
}
