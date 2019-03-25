using BLL.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Library.IRepositories
{
    public interface IQuizQuestionsRepo
    {
        List<QuestionsModel> GetQuestionsByQuizId(int QId);

        List<QuestionsModel> GetQuestionsByQuizAndQuestionId(int QId, int QuestionId);
    }
}
