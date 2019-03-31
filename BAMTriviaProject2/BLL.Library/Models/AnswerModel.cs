using BLL.Library.CustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.Library.Models
{
    public class AnswerModel
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }

        public string QuestionText { get; set; } = "";


        [Required]
        [MaxLength(500)]
        public string Answer { get; set; }

        [Required]
        public bool Correct { get; set; }
    }
}
