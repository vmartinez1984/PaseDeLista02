using System;
using System.Collections.Generic;

namespace RollCall.Core.Entities
{
    public partial class Document
    {
        public int Id { get; set; }
        public int DocumentTypeId { get; set; }
        public string Path { get; set; } = null!;
        public int PersonId { get; set; }
        public DateTime DateRegistration { get; set; }
        public bool IsActive { get; set; }

        public virtual DocumentType DocumentType { get; set; } = null!;
        public virtual Person Person { get; set; } = null!;
    }
}
