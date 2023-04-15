using AutoMapper;
using RollCall.Core.Dtos;
using RollCall.Core.Entities;
using RollCall.Core.Interfaces;

namespace RollCall.BusinessLayer.Bl
{
    internal class CheckinBl :BaseBl, ICheckInBl
    {
        public CheckinBl(IRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public async Task<int> AddAsync(CheckIn item)
        {

            Schedule schedule;
            int id;

            schedule = new Schedule
            {
                DateRegistration = DateTime.Now,
                EmployeeId = await GetEmployeeIdAsync(item), 
                IsActive = true
            };
            id = await _repository.Schedule.AddAsync(schedule);

            return id;
        }

        private async Task<int> GetEmployeeIdAsync(CheckIn item)
        {
            Employee employee;

            employee = await _repository.Employee.GetAsync(item.EmployeeNumber);
            
            return employee.Id;
        }
    }
}
