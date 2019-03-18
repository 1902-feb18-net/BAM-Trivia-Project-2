using BLL.Library.IRepositories;
using BLL.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAMTriviaProject2.DAL.Repositories
{
    public class QuestionRepo : IQuestionRepo
    {
        public QuestionsModel GetQuestionById(int questionId)
        {
            QuestionsModel m = new QuestionsModel();
            return m;
        }

        public List<QuestionsModel> GetQuestionByCategory(string category)
        {
            List<QuestionsModel> list = new List<QuestionsModel>();
            return list;
        }

        public List<QuestionsModel> GetQuestionByDifficulty(int difficulty)
        {
            List<QuestionsModel> list = new List<QuestionsModel>();
            return list;
        }

        public List<QuestionsModel> GetQuestionByDifficultyAndCategory(int difficulty, string category)
        {
            List<QuestionsModel> list = new List<QuestionsModel>();
            return list;
        }
    }
}
