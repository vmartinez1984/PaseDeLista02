using Microsoft.EntityFrameworkCore;
using RollCall.Core.Entities;
using RollCall.Core.Interfaces;
using RollCall.Repositories.Contexts;
using System.Linq.Dynamic.Core;

namespace RollCall.Repositories.Repositories
{
    public class PersonRepository : BaseRepository, IPersonRepository
    {
        public PersonRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<int> AddAsync(Person entity)
        {
            _appDbContext.People.Add(entity);
            await _appDbContext.SaveChangesAsync();

            return entity.Id;
        }

        public async Task DeleteAsync(int id)
        {
            Person entity = _appDbContext.People.FirstOrDefault(x => x.Id == id);

            entity.IsActive = false;

            await _appDbContext.SaveChangesAsync();
        }

        public async Task<Person> GetAsync(int id)
        {
            Person entity;

            entity = await _appDbContext.People.Include(x => x.Addresses).Where(x => x.Id == id).FirstOrDefaultAsync();

            return entity;
        }

        public async Task<List<Person>> GetAsync(PagerEntity pager)
        {
            List<Person> list;
            IQueryable<Person> queryable;

            queryable = _appDbContext.People;
            queryable = queryable.Where(x => x.IsActive);
            pager.TotalRecords = queryable.Count();
            if (string.IsNullOrEmpty(pager.Search) == false)
            {
                pager.Search = pager.Search.ToLower();
                queryable = queryable.Where(
                    x =>
                    x.Name.ToLower().Contains(pager.Search)
                    ||
                    x.LastName.ToLower().Contains(pager.Search)
                    ||
                    x.DateRegistration.ToString().Contains(pager.Search)
                    ||
                    x.Birthday.ToString().Contains(pager.Search)

                );
            }
            if (string.IsNullOrEmpty(pager.SortColumn) == false && string.IsNullOrEmpty(pager.SortColumnDir) == false)
            {
                queryable = queryable.OrderBy(pager.SortColumn + " " + pager.SortColumnDir);
            }
            var sql = queryable.ToQueryString();
            list = await queryable
            //.OrderByDescending(x => x.Id)
            .Skip((pager.PageCurrent - 1) * pager.RecordsPerPage)
            .Take(pager.RecordsPerPage)
            .ToListAsync();
            pager.TotalRecordsFiltered = await queryable.CountAsync();

            return list;
        }

        public async Task UpdateAsync(Person entity)
        {
            Person original;

            original = _appDbContext.People.Include(x => x.Addresses).Where(x => x.Id == entity.Id).FirstOrDefault();
            original.Genere = entity.Genere;
            original.Name = entity.Name;
            original.LastName = entity.LastName;
            original.Birthday = entity.Birthday;
            if (original.Addresses.Count == 0)
            {
                original.Addresses = entity.Addresses;
            }
            else
            {
                foreach (var address in original.Addresses)
                {
                    var addressModify = entity.Addresses.ToList().Where(x => x.Id == address.Id).FirstOrDefault();
                    address.StreetAndNumber = addressModify.StreetAndNumber;
                    address.ZipCode = addressModify.ZipCode;
                    address.Settlement = addressModify.Settlement;
                    address.Town = addressModify.Town;
                    address.State = addressModify.State;
                }
            }

            await _appDbContext.SaveChangesAsync();
        }
    }
}
