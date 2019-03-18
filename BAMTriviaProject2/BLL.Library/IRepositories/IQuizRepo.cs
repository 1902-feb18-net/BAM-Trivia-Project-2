using BLL.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Library.IRepositories
{
    public interface IQuizRepo
    {
        QuizesModel GetQuizById(int QId);

        List<QuizesModel> GetAllQuizzes();
    }
}
