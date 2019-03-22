using BLL.Library.IRepositories;
using BLL.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAMTriviaProject2.DAL.Repositories
{
    public class UserQuizesRepo : IUserQuizzesRepo
    {
        public List<UserQuizzesModel> GetUserQuizesByUser(int userId)
        {
            List<UserQuizzesModel> list = new List<UserQuizzesModel>();
            return list;
        }

        public List<UserQuizzesModel> GetUserQuizesByQuiz(int QId)
        {
            List<UserQuizzesModel> list = new List<UserQuizzesModel>();
            return list;
        }

        public double GetMaxScoreOfQuiz(QuizzesModel quiz)
        {
            return 0.0;
        }

    }
}
