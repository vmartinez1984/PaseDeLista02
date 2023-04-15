namespace RollCall.Core.Entities
{
    public class Holiday
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public bool  IsLaw { get; set; }

        public string Note { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime DateRegistration { get; set; } = DateTime.Now;

    }
}