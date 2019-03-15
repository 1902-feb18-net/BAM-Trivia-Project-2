using System;
using System.Collections.Generic;

namespace BAMTriviaProject2.DAL
{
    public partial class QuizResults
    {
        public int QuizId { get; set; }
        public int Qid { get; set; }
        public bool Correct { get; set; }

        public virtual Questions Q { get; set; }
        public virtual Quiz Quiz { get; set; }
    }
}
