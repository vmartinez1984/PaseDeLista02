using RollCall.Core.Interfaces;

namespace RollCall.Repositories.Repositories
{
    public class Repository : IRepository
    {
        public Repository(
           IPersonRepository personRepository,
           IAddressRepository addressRepository,
           IUserRepository userRepository,
           IRoleRepository roleRepository
        )
        {
            Person = personRepository;
            Address = addressRepository;
            User = userRepository;
            Role = roleRepository;
        }

        public IPersonRepository Person { get; }

        public IAddressRepository Address { get; }

        public IUserRepository User { get; }

        public IRoleRepository Role  {get; }
    }    
}
