namespace RollCall.Core.Entities
{
    public partial class Employee
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Number { get; set; } 
        public string Notes { get; set; }
        public DateTime DateRegistration { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;

        public virtual Person Person { get; set; }
    }
}