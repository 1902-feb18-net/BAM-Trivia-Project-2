using BLL.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Library.IRepositories
{
    public interface IAnswersRepo
    {
        AnswerModel GetAnswerById(int answerId);
        List<AnswerModel> GetAnswerByQuestion(int questionId);
        void AddAnswer(AnswerModel answer);
        void DeleteAnswer(int Id);
        void Save();
    }
}
