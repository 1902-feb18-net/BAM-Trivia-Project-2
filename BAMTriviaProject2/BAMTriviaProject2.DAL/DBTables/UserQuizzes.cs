﻿using System;
using System.Collections.Generic;

namespace BAMTriviaProject2.DAL
{
    public partial class UserQuizzes
    {
        public int UserId { get; set; }
        public int QuizId { get; set; }
        public int QuizMaxScore { get; set; }
        public int QuizActualScore { get; set; }
        public DateTime QuizDate { get; set; }

        public virtual Tusers User { get; set; }
    }
}