using System;
using System.Collections.Generic;

namespace RollCall.Core.Entities
{
    public partial class Role
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
