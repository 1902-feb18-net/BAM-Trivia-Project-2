using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

// Not sure where to put custom attributes, made folder in BLL.Library for this
/// <summary>
/// this custom attribute verifies if you have entered in the correct string out of a list of possible strings
/// </summary>
namespace BLL.Library.CustomValidations
{
    internal class StringRangeAttribute : ValidationAttribute
    {
        public string[] AllowableValues { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (AllowableValues?.Contains(value?.ToString()) == true)
            {
                return ValidationResult.Success;
            }
            var msg = $"Please enter one of the allowable values: {string.Join(", ", (AllowableValues ?? new string[] { "No allowable values found" }))}.";
            return new ValidationResult(msg);
        }
    }
}