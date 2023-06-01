using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.Validations
{
    public class VehiclePlateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string licensePlate = value.ToString();

                // Verificar el formato de la placa utilizando una expresión regular
                var regex = new Regex(@"^[A-Za-z]{3}\d{3}$");

                if (!regex.IsMatch(licensePlate))
                {
                    return new ValidationResult("El formato de la placa de vehículo no es válido.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
