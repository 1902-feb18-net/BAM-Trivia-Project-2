using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Library.Models
{
    public class ReviewsModel
    {
        public int Id { get; set; }
        public int? Qid { get; set; }
        public int? QuizId { get; set; }
        public int UserId { get; set; }
        public int Ratings { get; set; }
    }
}
