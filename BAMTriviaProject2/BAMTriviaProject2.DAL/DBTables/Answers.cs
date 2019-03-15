using System;
using System.Collections.Generic;

namespace BAMTriviaProject2.DAL
{
    public partial class Answers
    {
        public int Aid { get; set; }
        public int Qid { get; set; }
        public string Aanswer { get; set; }
        public bool Correct { get; set; }

        public virtual Questions Q { get; set; }
    }
}
