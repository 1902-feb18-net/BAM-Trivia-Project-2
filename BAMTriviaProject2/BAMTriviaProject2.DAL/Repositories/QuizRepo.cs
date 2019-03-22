using BLL.Library.IRepositories;
using BLL.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAMTriviaProject2.DAL.Repositories
{
    public class QuizRepo : IQuizRepo
    {
        public QuizzesModel GetQuizById(int QId)
        {
            QuizzesModel m = new QuizzesModel();
            return m;
        }

        public List<QuizzesModel> GetAllQuizzes()
        {
            List<QuizzesModel> list = new List<QuizzesModel>();
            return list;
        }

        public List<QuizzesModel> GetAllQuizesByCategoryAndDifficulty(string category, int difficulty)
        {
            List<QuizzesModel> list = new List<QuizzesModel>();
            return list;
        }
    }
}
