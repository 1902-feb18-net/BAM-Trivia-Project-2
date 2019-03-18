using BLL.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Library.IRepositories
{
    public interface IUserQuizesRepo
    {
        List<UserQuizesModel> GetUserQuizesByUser(int userId);

        List<UserQuizesModel> GetUserQuizesByQuiz(int QId);

        double GetMaxScoreOfQuiz(QuizesModel quiz);
    }
}
