using BLL.Library.IRepositories;
using BLL.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAMTriviaProject2.DAL.Repositories
{
    public class QuizRepo : IQuizRepo
    {
        public QuizesModel GetQuizById(int QId)
        {
            QuizesModel m = new QuizesModel();
            return m;
        }

        public List<QuizesModel> GetAllQuizzes()
        {
            List<QuizesModel> list = new List<QuizesModel>();
            return list;
        }
    }
}
