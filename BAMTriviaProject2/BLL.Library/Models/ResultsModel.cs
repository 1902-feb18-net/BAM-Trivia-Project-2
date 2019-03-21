using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Library.Models
{
    public class ResultsModel
    {
        public int ResultId { get; set; }
        public int UserQuizId { get; set; }
        public int Qid { get; set; }
        public string UserAnswer { get; set; }
        public bool Correct { get; set; }
    }
}
