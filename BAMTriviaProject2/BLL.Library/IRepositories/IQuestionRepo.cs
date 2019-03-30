using BLL.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Library.IRepositories
{
    public interface IQuestionRepo
    {
        QuestionsModel GetQuestionById(int questionId);
        Task<int> AddQuestion(QuestionsModel question);
        List<QuestionsModel> GetQuestionByCategory(string category);
        List<QuestionsModel> GetQuestionByDifficulty(int difficulty);
        Task<List<QuestionsModel>> GetQuestionByDifficultyAndCategory(int difficulty, string category);
    }
}
