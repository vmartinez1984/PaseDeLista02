using RollCall.Core.Entities;

namespace RollCall.Core.Interfaces
{
    public interface IRepository
    {
        IPersonRepository Person { get; }
        IAddressRepository Address { get; }
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
}
