using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Library.IRepositories
{
    public interface IQuizResultsRepo
    {
        void GetAnswersByQuizId(int QId);

        void GetAnswersByQuizAndQuestionId(int QId, int QuestionId);
    }
}
