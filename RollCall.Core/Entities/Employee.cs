using System;
using System.Collections.Generic;

namespace RollCall.Core.Entities
{
    public partial class Employee
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Number { get; set; } = null!;
        public string? Notes { get; set; }
        public DateTime DateRegistration { get; set; }
        public bool IsActive { get; set; }
    }
}
