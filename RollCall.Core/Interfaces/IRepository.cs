using RollCall.Core.Entities;

namespace RollCall.Core.Interfaces
{
    public interface IRepository
    {
        IPersonRepository Person { get; }

        IAddressRepository Address { get; }

        IUserRepository User { get; }

        IRoleRepository Role { get; }

        IEmployeeRepository Employee { get; }
    }

    public interface IRoleRepository
    {
        Task<List<Role>> GetAsync();
    }

    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetAsync(int id);

        Task<int> AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(int id);
    }

    public interface IPersonRepository : IBaseRepository<Person>
    {
        Task<List<Person>> GetAsync(PagerEntity pager);
    }

    public interface IAddressRepository : IBaseRepository<Address> { }

    public interface IUserRepository : IBaseRepository<User>
    {
        Task<List<User>> GetAsync();
        Task<User> GetAsync(string email);
    }

    public interface IEmployeeRepository : IBaseRepository<Employee> 
    {
        Task<List<Employee>> GetAsync(PagerEntity pager);            
    }    
}
