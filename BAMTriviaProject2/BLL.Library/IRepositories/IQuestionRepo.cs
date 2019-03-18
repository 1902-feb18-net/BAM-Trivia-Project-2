using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Library.IRepositories
{
    public interface IQuestionRepo
    {
        void GetQuestionById(int questionId);

        void GetQuestionByCategory(string category);

        void GetQuestionByDifficulty(int difficulty);

        void GetQuestionByDifficultyAndCategory(int difficulty, string category);

    }
}
