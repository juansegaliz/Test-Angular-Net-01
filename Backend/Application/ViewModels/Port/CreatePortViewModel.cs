using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Port
{
    public class CreatePortViewModel
    {
        [Required]
        [MaxLength(100)]
        [MinLength(5)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(5)]
        public string City { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(5)]
        public string Country { get; set; }
    }
}
