namespace RollCall.Core.Dtos
{
    public class PersonDto: PersonDtoIn
    {
        public int Id { get; set; }
    }

    public class PersonDtoIn
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdaty { get; set; }
        public string Genere { get; set; }
        public DateTime DateRegistration { get; set; }
        public bool IsActive { get; set; }
    }
}
