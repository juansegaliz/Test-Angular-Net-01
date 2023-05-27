using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Warehouse
{
    public class WarehouseViewModel
    {
        [Required]
        public int WarehouseId { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(5)]
        public string Name { get; set; }
        [Required]
        [MaxLength(200)]
        [MinLength(5)]
        public string Address { get; set; }
    }
}
