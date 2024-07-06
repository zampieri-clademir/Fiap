using System;
using System.ComponentModel.DataAnnotations;

namespace TechChallenge_1.API.Base
{
    public class ValidGuidAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var result = Guid.TryParse(value.ToString(), out Guid guidValue);

            if (result)
            {
                if (guidValue == Guid.Empty)
                {
                    return new ValidationResult("O Guid não pode ser o valor padrão (Guid.Empty).");
                }
            }
            else
            {
                return new ValidationResult("Valor inválido para Guid.");
            }

            return ValidationResult.Success;
        }
    }
}
