using System;
using System.Collections.Generic;

namespace BAMTriviaProject2.DAL
{
    public partial class Results
    {
        public int ResultId { get; set; }
        public int UserQuizId { get; set; }
        public int Qid { get; set; }
        public string UserAnswer { get; set; }
        public bool Correct { get; set; }

        public virtual Questions Q { get; set; }
        public virtual UserQuizzes UserQuiz { get; set; }
    }
}
