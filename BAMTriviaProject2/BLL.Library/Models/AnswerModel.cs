using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Library.Models
{
    public class AnswerModel
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Answer { get; set; }
        public bool Correct { get; set; }
    }
}
