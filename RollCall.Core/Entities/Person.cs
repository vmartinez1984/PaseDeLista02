namespace RollCall.Core.Entities
{
    public partial class Person
    {
        public Person()
        {
            Addresses = new HashSet<Address>();
            Documents = new HashSet<Document>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime Birthdaty { get; set; }
        public string Genere { get; set; } = null!;
        public DateTime DateRegistration { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
    }
}
