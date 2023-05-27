using System;
using System.Collections.Generic;

namespace Infrastructure.Data.Models
{
    public partial class Client
    {
        public Client()
        {
            LandLogistics = new HashSet<LandLogistic>();
            MaritimeLogistics = new HashSet<MaritimeLogistic>();
        }

        public int ClientId { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Phone { get; set; } = null!;

        public virtual ICollection<LandLogistic> LandLogistics { get; set; }
        public virtual ICollection<MaritimeLogistic> MaritimeLogistics { get; set; }
    }
}
