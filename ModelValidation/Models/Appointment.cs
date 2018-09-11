using ModelValidation.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModelValidation.Models
{
    [NoJoeOnMondays]
    public class Appointment : IValidatableObject
    {
        //[Required]
        public string ClientName { get; set; }

        [DataType(DataType.Date)]
        //[FutureDate(ErrorMessage = "Please enter a date in the future")]
        public DateTime Date { get; set; }

        //[Range(typeof(bool),"true","true", ErrorMessage = "You must accept the terms")]
        //[MustBeTrue(ErrorMessage = "You must accept the terms")]
        public bool TermsAccepted { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            if (string.IsNullOrEmpty(ClientName))
            {
                errors.Add(new ValidationResult("Please enter your name"));
            }
            if (DateTime.Now > Date)
            {
                errors.Add(new ValidationResult("Please enter date in future"));
            }
            if (errors.Count == 0 && ClientName == "Joe"
                && Date.DayOfWeek == DayOfWeek.Monday)
            {
                errors.Add(new ValidationResult("Joe cannot book appointments on Mondays"));
            }
            if (!TermsAccepted)
            {
                errors.Add(new ValidationResult("You must accept the terms"));
            }
            return errors;
        }
    }
}