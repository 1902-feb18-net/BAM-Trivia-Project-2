using BLL.Library.CustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.Library.Models
{
    public class ResultsModel
    {
        public int ResultId { get; set; }
        public int UserQuizId { get; set; }
        public int Qid { get; set; }

        [Required]
        [MaxLength(500)]
        public string UserAnswer { get; set; }

        [Required]
        [StringRange(AllowableValues = new[] { "true", "false" }, ErrorMessage = "Boolean values must be 'true' or 'false'")]
        public bool Correct { get; set; }
    }
}
