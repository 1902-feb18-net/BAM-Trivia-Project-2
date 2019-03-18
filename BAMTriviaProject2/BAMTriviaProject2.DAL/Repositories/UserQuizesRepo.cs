using BLL.Library.IRepositories;
using BLL.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAMTriviaProject2.DAL.Repositories
{
    public class UserQuizesRepo : IUserQuizesRepo
    {
        public List<UserQuizesModel> GetUserQuizesByUser(int userId)
        {
            List<UserQuizesModel> list = new List<UserQuizesModel>();
            return list;
        }

        public List<UserQuizesModel> GetUserQuizesByQuiz(int QId)
        {
            List<UserQuizesModel> list = new List<UserQuizesModel>();
            return list;
        }

        public double GetMaxScoreOfQuiz(QuizesModel quiz)
        {
            return 0.0;
        }

    }
}
