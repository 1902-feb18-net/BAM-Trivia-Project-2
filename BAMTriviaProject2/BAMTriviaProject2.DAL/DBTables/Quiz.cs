using System;
using System.Collections.Generic;

namespace BAMTriviaProject2.DAL
{
    public partial class Quiz
    {
        public Quiz()
        {
            QuizResults = new HashSet<QuizResults>();
            UserQuizzes = new HashSet<UserQuizzes>();
        }

        public int QuizId { get; set; }
        public int QuizMaxScore { get; set; }
        public int QuizDifficulty { get; set; }

        public virtual ICollection<QuizResults> QuizResults { get; set; }
        public virtual ICollection<UserQuizzes> UserQuizzes { get; set; }
    }
}
