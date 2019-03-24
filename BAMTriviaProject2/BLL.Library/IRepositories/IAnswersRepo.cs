using BLL.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Library.IRepositories
{
    public interface IAnswersRepo
    {
        List<AnswerModel> GetAnswerByQuestion(int questionId);
    }
}
