using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.ProductType
{
    public class CreateProductTypeViewModel
    {
        [Required]
        [MaxLength(100)]
        [MinLength(5)]
        public string Name { get; set; }
    }
}
