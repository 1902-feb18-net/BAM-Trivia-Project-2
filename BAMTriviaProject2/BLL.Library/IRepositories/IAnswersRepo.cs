using BLL.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Library.IRepositories
{
    public interface IAnswersRepo
    {
        AnswerModel GetAnswerById(int answerId);
        Task<IEnumerable<AnswerModel>> GetAnswerByQuestion(int questionId);
        List<AnswerModel> GetQuizAnswers(int quizId);
        Task<int> AddAnswer(AnswerModel answer);
        Task<int> DeleteAnswer(int Id);
        Task<int> Save();
    }
}
