using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Library.Models
{
    public class UserQuizzesModel
    {
        public int UserQuizId { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public int QuizId { get; set; }
        public int QuizMaxScore { get; set; }
        public int QuizActualScore { get; set; }
        public DateTime QuizDate { get; set; }
    }
}
