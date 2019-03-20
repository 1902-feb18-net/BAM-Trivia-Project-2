using BLL.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Library.IRepositories
{
    public interface IQuestionRepo
    {
        QuestionsModel GetQuestionById(int questionId);

        List<QuestionsModel> GetQuestionByCategory(string category);

        List<QuestionsModel> GetQuestionByDifficulty(int difficulty);

        List<QuestionsModel> GetQuestionByDifficultyAndCategory(int difficulty, string category);

    }
}
