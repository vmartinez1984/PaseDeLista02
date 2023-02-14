using RollCall.Core.Interfaces;

namespace RollCall.Repositories.Repositories
{
    public class Repository : IRepository
    {
        public Repository(
           IPersonRepository personRepository
        )
        {
            Person = personRepository;
        }

        public IPersonRepository Person { get; }
    }    
}
