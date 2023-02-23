using RollCall.Core.Interfaces;

namespace RollCall.Repositories.Repositories
{
    public class Repository : IRepository
    {
        public Repository(
           IPersonRepository personRepository,
           IAddressRepository addressRepository
        )
        {
            Person = personRepository;
            Address = addressRepository;
        }

        public IPersonRepository Person { get; }

        public IAddressRepository Address { get; }
    }    
}
