using RollCall.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollCall.Core.Interfaces
{
    public interface IRepository
    {      
        IPersonRepository Person { get; }
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
        Task<List<Person>> GetAsync();
    }
}
