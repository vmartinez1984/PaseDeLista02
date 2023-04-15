namespace RollCall.Core.Entities
{
    public class Schedule
    {
        public int Id { get; set; }

        public DateTime DateRegistration { get; set; }

        public int EmployeeId { get; set; }

        public bool IsActive { get; set; }

        public virtual Employee  Employee { get; set; }

    }
}