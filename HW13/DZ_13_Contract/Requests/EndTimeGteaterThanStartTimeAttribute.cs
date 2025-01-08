using System;
using System.ComponentModel.DataAnnotations;
using DZ_13_Contract.Requests;

namespace DZ_13_Contract.Requests
{
    public class EndTimeGreaterThanStartTimeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var instance = (UpsertSessionRequest)validationContext.ObjectInstance;

            if (instance.StartTime >= instance.EndTime)
            {
                return new ValidationResult("Время окончания должно быть позже времени начала.");
            }
            return ValidationResult.Success;
        }
    }

}
