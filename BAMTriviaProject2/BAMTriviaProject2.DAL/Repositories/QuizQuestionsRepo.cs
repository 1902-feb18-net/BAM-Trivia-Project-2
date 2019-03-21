using BLL.Library.IRepositories;
using BLL.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAMTriviaProject2.DAL.Repositories
{
    public class QuizQuestionsRepo : IQuizQuestionsRepo
    {
        public List<AnswerModel> GetAnswersByQuizId(int QId)
        {
            List<AnswerModel> list = new List<AnswerModel>();
            return list;
        }

        public List<AnswerModel> GetAnswersByQuizAndQuestionId(int QId, int QuestionId)
        {
            List<AnswerModel> list = new List<AnswerModel>();
            return list;
        }
    }
}
