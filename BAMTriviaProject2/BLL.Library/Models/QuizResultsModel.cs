using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Library.Models
{
    public class QuizResultsModel
    {
        public int QuizId { get; set; }
        public int Qid { get; set; }
        public bool Correct { get; set; }
    }
}
