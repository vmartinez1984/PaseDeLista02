using AutoMapper;
using RollCall.Core.Dtos;
using RollCall.Core.Entities;
using RollCall.Core.Interfaces;

namespace RollCall.BusinessLayer.Bl
{
    internal class EmployeeBl : BaseBl, IEmployeeBl
    {
        public EmployeeBl(IRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public async Task<int> AddAsync(EmployeeDtoIn item)
        {
            Employee entity;

            entity = _mapper.Map<Employee>(item);
            entity.Number = string.Empty;
            entity.Id = await _repository.Employee.AddAsync(entity);
            
            return entity.Id;
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<EmployeeDto> GetAsync(int id)
        {
            EmployeeDto dto;
            Employee entity;

            entity = await _repository.Employee.GetAsync(id);
            dto = _mapper.Map<EmployeeDto>(entity);

            return dto;
        }

        public async Task<PagerDto> GetAsync(PagerDtoIn pagerDtoIn)
        {
            PagerEntity pagerEntity;
            List<Employee> employees;
            PagerDto pagerDto;

            pagerEntity = _mapper.Map<PagerEntity>(pagerDtoIn);
            employees = await _repository.Employee.GetAsync(pagerEntity);
            pagerDto = _mapper.Map<PagerDto>(pagerEntity);
            pagerDto.List = _mapper.Map<List<EmployeeDto>>(employees);

            return pagerDto;
        }

        public Task UpdateAsync(EmployeeDtoIn item, int id)
        {
            throw new NotImplementedException();
        }
    }
}
