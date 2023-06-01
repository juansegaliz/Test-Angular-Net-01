using System;
using System.Collections.Generic;

namespace Infrastructure.Data.Models
{
    public partial class LandLogistic
    {
        public int LandLogisticsId { get; set; }
        public int ProductTypeId { get; set; }
        public int Quantity { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int WarehouseId { get; set; }
        public decimal ShippingPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalPrice { get; set; }
        public string VehiclePlate { get; set; } = null!;
        public string GuideNumber { get; set; } = null!;
        public int ClientId { get; set; }

        public virtual Client Client { get; set; } = null!;
        public virtual ProductType ProductType { get; set; } = null!;
        public virtual Warehouse Warehouse { get; set; } = null!;
    }
}
