using System;
using System.Collections.Generic;

namespace RollCall.Core.Entities
{
    public partial class Address
    {
        public int Id { get; set; }
        public string StreetAndNumber { get; set; } = null!;
        public string Settlement { get; set; } = null!;
        public string Town { get; set; } = null!;
        public string State { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
        public bool IsActive { get; set; } = true;
        public DateTime DateRegistration { get; set; } = DateTime.Now;
        public int PersonId { get; set; }

        public virtual Person Person { get; set; } = null!;
    }
}
