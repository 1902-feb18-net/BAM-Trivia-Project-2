using System;
using System.Collections.Generic;

namespace BAMTriviaProject2.DAL
{
    public partial class Questions
    {
        public Questions()
        {
            Answers = new HashSet<Answers>();
            QuizQuestions = new HashSet<QuizQuestions>();
            Results = new HashSet<Results>();
            Reviews = new HashSet<Reviews>();
        }

        public int Qid { get; set; }
        public string Qcategory { get; set; }
        public string Qtype { get; set; }
        public int Qrating { get; set; }
        public decimal? QaverageReview { get; set; }
        public string Qstring { get; set; }

        public virtual ICollection<Answers> Answers { get; set; }
        public virtual ICollection<QuizQuestions> QuizQuestions { get; set; }
        public virtual ICollection<Results> Results { get; set; }
        public virtual ICollection<Reviews> Reviews { get; set; }
    }
}
