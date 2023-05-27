using System;
using System.Collections.Generic;

namespace Infrastructure.Data.Models
{
    public partial class Warehouse
    {
        public Warehouse()
        {
            LandLogistics = new HashSet<LandLogistic>();
        }

        public int WarehouseId { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;

        public virtual ICollection<LandLogistic> LandLogistics { get; set; }
    }
}
