using System;
using System.Collections.Generic;

namespace BAMTriviaProject2.DAL
{
    public partial class Reviews
    {
        public int Rid { get; set; }
        public int? Qid { get; set; }
        public int? QuizId { get; set; }
        public int UserId { get; set; }
        public int Rratings { get; set; }

        public virtual Questions Q { get; set; }
        public virtual Tusers User { get; set; }
    }
}
