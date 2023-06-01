using System;
using System.Collections.Generic;

namespace Infrastructure.Data.Models
{
    public partial class LandLogistic : Domain.Entities.LandLogistic
    {
        public virtual Client Client { get; set; } = null!;
        public virtual ProductType ProductType { get; set; } = null!;
        public virtual Warehouse Warehouse { get; set; } = null!;
    }
}
