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
        void AddAnswer(AnswerModel answer);
        void DeleteAnswer(int Id);
        void Save();
    }
}
