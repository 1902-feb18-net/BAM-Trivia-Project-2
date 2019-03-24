using BLL.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Library.IRepositories
{
    public interface IQuizRepo
    {
        QuizzesModel GetQuizById(int QId);

        List<QuizzesModel> GetAllQuizzes();

        List<QuizzesModel> GetAllQuizesByCategoryAndDifficulty(string category, int difficulty);

    }
}
