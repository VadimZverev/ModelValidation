using ModelValidation.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace ModelValidation.Infrastructure
{
    public class NoJoeOnMondaysAttribute : ValidationAttribute
    {
        public NoJoeOnMondaysAttribute()
        {
            ErrorMessage = "Joe cannot book appointment on Mondays";
        }

        public override bool IsValid(object value)
        {
            Appointment app = value as Appointment;
            if (app == null || string.IsNullOrEmpty(app.ClientName) ||
                app.Date == null)
            {
                // у нас нет модели правильного типа для проверки, или у нас нет 
                // значений для свойств ClientName и Date, которые нам требуются
                return true;
            }
            else
            {
                return !(app.ClientName == "Joe" &&
                            app.Date.DayOfWeek == DayOfWeek.Monday);
            }
        }
    }
}