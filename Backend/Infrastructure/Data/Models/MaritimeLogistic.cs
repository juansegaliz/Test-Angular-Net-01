﻿using System;
using System.Collections.Generic;

namespace Infrastructure.Data.Models
{
    public partial class MaritimeLogistic
    {
        public int MaritimeLogisticsId { get; set; }
        public int ProductTypeId { get; set; }
        public int Quantity { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int PortId { get; set; }
        public decimal ShippingPrice { get; set; }
        public string FleetNumber { get; set; } = null!;
        public string GuideNumber { get; set; } = null!;
        public int ClientId { get; set; }

        public virtual Client Client { get; set; } = null!;
        public virtual Port Port { get; set; } = null!;
        public virtual ProductType ProductType { get; set; } = null!;
    }
}
