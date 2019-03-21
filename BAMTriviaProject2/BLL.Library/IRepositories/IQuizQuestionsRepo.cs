using BLL.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Library.IRepositories
{
    public interface IQuizQuestionsRepo
    {
        List<AnswerModel> GetAnswersByQuizId(int QId);

        List<AnswerModel> GetAnswersByQuizAndQuestionId(int QId, int QuestionId);
    }
}
