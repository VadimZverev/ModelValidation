﻿using ModelValidation.Infrastructure;
using System;
using System.ComponentModel.DataAnnotations;

namespace ModelValidation.Models
{
    public class Appointment
    {
        [Required]
        public string ClientName { get; set; }

        [DataType(DataType.Date)]
        [FutureDate(ErrorMessage = "Please enter a date")]
        public DateTime Date { get; set; }

        //[Range(typeof(bool),"true","true", ErrorMessage = "You must accept the terms")]
        [MustBeTrue(ErrorMessage = "You must accept the terms")]
        public bool TermsAccepted { get; set; }
    }
}