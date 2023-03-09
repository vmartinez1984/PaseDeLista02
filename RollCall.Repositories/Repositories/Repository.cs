using RollCall.Core.Interfaces;

namespace RollCall.Repositories.Repositories
{
    public class Repository : IRepository
    {
        public Repository(
           IPersonRepository personRepository,
           IAddressRepository addressRepository,
           IUserRepository userRepository,
           IRoleRepository roleRepository,
           IEmployeeRepository employeeRepository
        )
        {
            Person = personRepository;
            Address = addressRepository;
            User = userRepository;
            Role = roleRepository;
            Employee = employeeRepository;
        }

        public IEmployeeRepository Employee { get; }

        public IPersonRepository Person { get; }

        public IAddressRepository Address { get; }

        public IUserRepository User { get; }

        public IRoleRepository Role  {get; }
    }    
}
