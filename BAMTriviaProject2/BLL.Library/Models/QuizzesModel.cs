using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Library.Models
{
    public class QuizzesModel
    {
        public int Id { get; set; }
        public int MaxScore { get; set; }
        public int Difficulty { get; set; }
        public string Category { get; set; }

        public List<string> Categories = new List<string>()
        {
            "QC",
            "Beer",
            "Movies"
        };
    }
}
