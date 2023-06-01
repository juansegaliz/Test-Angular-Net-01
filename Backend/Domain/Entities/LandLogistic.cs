using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class LandLogistic
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

        public LandLogistic() { }

        public LandLogistic(int landLogisticsId, int productTypeId, int quantity, 
            DateTime registrationDate, DateTime deliveryDate, int warehouseId,
            decimal shippingPrice, string vehiclePlate, string guideNumber,
            int clientId) 
        {
            LandLogisticsId = landLogisticsId;
            ProductTypeId = productTypeId;
            Quantity = quantity;
            RegistrationDate = registrationDate; 
            DeliveryDate = deliveryDate; 
            WarehouseId = warehouseId;
            ShippingPrice = shippingPrice;
            Discount = 0;
            TotalPrice = shippingPrice;
            VehiclePlate = vehiclePlate;
            GuideNumber = guideNumber;
            ClientId = clientId;

            ApplyDiscount();
        }

        private void ApplyDiscount() 
        {
            if (Quantity > 10)
            {
                Discount = ShippingPrice * 0.05m;
                TotalPrice = ShippingPrice - Discount;
            }
        }
    }
}
