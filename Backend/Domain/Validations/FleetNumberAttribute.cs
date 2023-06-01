using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.Validations
{
    public class FleetNumberAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string fleetNumber = value.ToString();

                // Verificar el formato del numero de flota utilizando una expresión regular
                var regex = new Regex(@"^[A-Za-z]{3}\d{4}[A-Za-z]{1}$");

                if (!regex.IsMatch(fleetNumber))
                {
                    return new ValidationResult("El número de flota debe tener el formato correcto.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
