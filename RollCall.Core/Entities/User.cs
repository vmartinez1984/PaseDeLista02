using System;
using System.Collections.Generic;

namespace RollCall.Core.Entities
{
    public partial class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int RoleId { get; set; }
        public int PersonId { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateRegistration { get; set; }

        public virtual Person Person { get; set; } = null!;
        public virtual Role Role { get; set; } = null!;
    }
}
