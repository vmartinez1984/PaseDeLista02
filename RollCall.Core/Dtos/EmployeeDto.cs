namespace RollCall.Core.Dtos
{
    public class EmployeeDto: EmployeeDtoIn
    {
        public int Id { get; set; }

        public DateTime DateRegistration { get; set; }
    }

    public class EmployeeDtoIn
    {        
        public int PersonId { get; set; }
        public PersonDtoIn Person { get; set; }
        public string Number { get; set; }

        //Datos del empleado
        public string Notes { get; set; }
    }
}
