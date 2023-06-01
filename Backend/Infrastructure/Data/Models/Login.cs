using System;
using System.Collections.Generic;

namespace Infrastructure.Data.Models
{
    public partial class Login
    {
        public int LoginId { get; set; }
        public string Email { get; set; } = null!;
        public byte[] PasswordHash { get; set; } = null!;
        public byte[] Salt { get; set; } = null!;
    }
}
