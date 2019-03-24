using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using BLL.Library.CustomValidations;

namespace BLL.Library.Models
{
    public class QuestionsModel
    {
        public int Id { get; set; }


        [Required]
        [MaxLength(100)]
        [StringRange(AllowableValues = new[] { "Movie", "QC", "Beer" }, ErrorMessage = "Category must be: 'Movie', 'QC', or 'Beer'")]
        public string Category { get; set; }

        [Required]
        [MaxLength(100)]
        [StringRange(AllowableValues = new[] { "Multiple", "Bool", "Fill" }, ErrorMessage = "Type must be: 'Multiple', 'Bool', or 'Fill'")]
        public string Type { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int Rating { get; set; }

        [Range(1, 10, ErrorMessage = "Rating must be between 1 and 10")]
        public decimal? AverageReview { get; set; }

        [Required]
        [MaxLength(500)]
        public string Qstring { get; set; }

    }
}
