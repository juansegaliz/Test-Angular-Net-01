using System;
using System.Collections.Generic;

namespace Infrastructure.Data.Models
{
    public partial class ProductType
    {
        public ProductType()
        {
            LandLogistics = new HashSet<LandLogistic>();
            MaritimeLogistics = new HashSet<MaritimeLogistic>();
        }

        public int ProductTypeId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<LandLogistic> LandLogistics { get; set; }
        public virtual ICollection<MaritimeLogistic> MaritimeLogistics { get; set; }
    }
}
