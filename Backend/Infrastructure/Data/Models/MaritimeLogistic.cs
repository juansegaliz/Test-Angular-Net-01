using System;
using System.Collections.Generic;

namespace Infrastructure.Data.Models
{
    public partial class MaritimeLogistic : Domain.Entities.MaritimeLogistic
    {
        public virtual Client Client { get; set; } = null!;
        public virtual Port Port { get; set; } = null!;
        public virtual ProductType ProductType { get; set; } = null!;
    }
}
