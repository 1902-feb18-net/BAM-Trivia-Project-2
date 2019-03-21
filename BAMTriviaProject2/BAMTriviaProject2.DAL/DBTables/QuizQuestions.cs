using System;
using System.Collections.Generic;

namespace BAMTriviaProject2.DAL
{
    public partial class QuizQuestions
    {
        public int QuizId { get; set; }
        public int Qid { get; set; }

        public virtual Questions Q { get; set; }
        public virtual Quiz Quiz { get; set; }
    }
}
