namespace RollCall.Core.Dtos
{
    public class EmployeeDto: EmployeeDtoIn
    {
        public int Id { get; set; }
        public int PersonId { get; set; }

        public DateTime DateRegistration { get; set; }
    }

    public class EmployeeDtoIn
    {
        //Datos de persona
        //public string Name { get; set; } 
        //public string LastName { get; set; }
        //public DateTime Birthday { get; set; }
        //public string Genere { get; set; }
        public PersonDtoIn Person { get; set; }
        public string Number { get; set; }

        //Datos del empleado
        public string Notes { get; set; }
    }
}
