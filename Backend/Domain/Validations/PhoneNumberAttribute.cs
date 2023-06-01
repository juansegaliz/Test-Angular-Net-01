using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.Validations
{
    public class PhoneNumberAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string phoneNumber = value.ToString();

                // Validar el formato del número de teléfono utilizando una expresión regular
                var regex = new Regex(@"^\+?\d{10,12}$");

                if (!regex.IsMatch(phoneNumber))
                {
                    return new ValidationResult("El número de teléfono no tiene un formato válido.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
