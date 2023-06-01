using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class MaritimeLogistic
    {
        public int MaritimeLogisticsId { get; set; }
        public int ProductTypeId { get; set; }
        public int Quantity { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int PortId { get; set; }
        public decimal ShippingPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalPrice { get; set; }
        public string FleetNumber { get; set; } = null!;
        public string GuideNumber { get; set; } = null!;
        public int ClientId { get; set; }

        public MaritimeLogistic() { }

        public MaritimeLogistic(int maritimeLogisticsId, int productTypeId, int quantity,
            DateTime registrationDate, DateTime deliveryDate, int portId,
            decimal shippingPrice, string fleetNumber, string guideNumber,
            int clientId)
        {
            MaritimeLogisticsId = maritimeLogisticsId;
            ProductTypeId = productTypeId;
            Quantity = quantity;
            RegistrationDate = registrationDate;
            DeliveryDate = deliveryDate;
            PortId = portId;
            ShippingPrice = shippingPrice;
            Discount = 0;
            TotalPrice = shippingPrice;
            FleetNumber = fleetNumber;
            GuideNumber = guideNumber;
            ClientId = clientId;

            ApplyDiscount();
        }

        private void ApplyDiscount()
        {
            if (Quantity > 10)
            {
                Discount = ShippingPrice * 0.03m;
                TotalPrice = ShippingPrice - Discount;
            }
        }
    }
}
