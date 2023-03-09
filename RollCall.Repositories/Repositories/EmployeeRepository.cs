﻿using Microsoft.EntityFrameworkCore;
using RollCall.Core.Entities;
using RollCall.Core.Interfaces;
using RollCall.Repositories.Contexts;
using System.Linq.Dynamic.Core;
using System.Security.Cryptography.X509Certificates;

namespace RollCall.Repositories.Repositories
{
    public class EmployeeRepository : BaseRepository, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<int> AddAsync(Employee entity)
        {
            _appDbContext.Employees.Add(entity);
            await _appDbContext.SaveChangesAsync();

            return entity.Id;
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Employee> GetAsync(int id)
        {
            Employee entity;

            entity = await _appDbContext.Employees
                .Include(x=>x.Person)
                .FirstOrDefaultAsync(x => x.Id == id);

            return entity;
        }

        public async Task<List<Employee>> GetAsync(PagerEntity pager)
        {
            List<Employee> list;
            IQueryable<Employee> queryable;

            queryable = _appDbContext.Employees.Include(x => x.Person);
            queryable = queryable.Where(x => x.IsActive);
            pager.TotalRecords = queryable.Count();
            if (string.IsNullOrEmpty(pager.Search) == false)
            {
                pager.Search = pager.Search.ToLower();
                //queryable = queryable.Where(
                //    x =>
                //    x.Name.ToLower().Contains(pager.Search)
                //    ||
                //    x.LastName.ToLower().Contains(pager.Search)
                //    ||
                //    x.DateRegistration.ToString().Contains(pager.Search)
                //    ||
                //    x.Birthday.ToString().Contains(pager.Search)

                //);
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

        public Task UpdateAsync(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
