using Domain.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.LandLogistic
{
    public class CreateLandLogisticViewModel
    {
        [Required]
        public int ProductTypeId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public DateTime RegistrationDate { get; set; }
        [Required]
        public DateTime DeliveryDate { get; set; }
        [Required]
        public int WarehouseId { get; set; }
        [Required]
        public decimal ShippingPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalPrice { get; set; }
        [Required]
        [MaxLength(6)]
        [MinLength(6)]
        [VehiclePlate]
        public string VehiclePlate { get; set; } = null!;
        [Required]
        [MaxLength(10)]
        [MinLength(10)]
        public string GuideNumber { get; set; } = null!;
        [Required]
        public int ClientId { get; set; }
    }
}
