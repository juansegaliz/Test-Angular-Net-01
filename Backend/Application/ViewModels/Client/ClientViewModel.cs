using Domain.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Client
{
    public class ClientViewModel
    {
        [Required]
        public int ClientId { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(5)]
        public string Name { get; set; }
        [Required]
        [MaxLength(200)]
        [MinLength(5)]
        public string Address { get; set; }
        [Required]
        [PhoneNumber]
        [MaxLength(20)]
        [MinLength(5)]
        public string Phone { get; set; }
    }
}
