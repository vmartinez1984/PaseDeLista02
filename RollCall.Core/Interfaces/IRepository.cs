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

        IHolidayRepository Holiday { get; }
        object Schedule { get; }
    }



    public interface IHolidayRepository : IBaseRepository<Holiday>
    {
        Task<List<Holiday>> GetAsync();
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

        Task<Employee> GetAsync(string employeeNumber);
    }    
}
