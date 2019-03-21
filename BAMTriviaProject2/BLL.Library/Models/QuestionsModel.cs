using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Library.Models
{
    public class QuestionsModel
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        public int Rating { get; set; }
        public decimal? AverageReview { get; set; }
        public string Qstring { get; set; }

    }
}
