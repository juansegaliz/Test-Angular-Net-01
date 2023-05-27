using System;
using System.Collections.Generic;

namespace Infrastructure.Data.Models
{
    public partial class Port
    {
        public Port()
        {
            MaritimeLogistics = new HashSet<MaritimeLogistic>();
        }

        public int PortId { get; set; }
        public string Name { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Country { get; set; } = null!;

        public virtual ICollection<MaritimeLogistic> MaritimeLogistics { get; set; }
    }
}
