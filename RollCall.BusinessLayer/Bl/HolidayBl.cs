using AutoMapper;
using RollCall.Core.Dtos;
using RollCall.Core.Entities;
using RollCall.Core.Interfaces;

namespace RollCall.BusinessLayer.Bl
{
    internal class HolidayBl : BaseBl, IHolidayBl
    {
        public HolidayBl(IRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public async Task<int> AddAsync(HolidayDtoIn item)
        {
            Holiday entity;

            entity = _mapper.Map<Holiday>(item);
            entity.Id = await _repository.Holiday.AddAsync(entity);

            return entity.Id;    
        }

        public async Task DeleteAsync(int id)
        {
           await _repository.Holiday.DeleteAsync(id);
        }

        public async Task<HolidayDto> GetAsync(int id)
        {
            Holiday entity;
            HolidayDto item;

            entity = await _repository.Holiday.GetAsync(id);
            item = _mapper.Map<HolidayDto>(entity);

            return item;
        }

        public async Task<List<HolidayDto>> GetAsync()
        {            
            var list = _mapper.Map<List<HolidayDto>>(await _repository.Holiday.GetAsync());

            return list;
        }

        public async Task UpdateAsync(HolidayDtoIn item, int id)
        {
            Holiday entity;

            entity = await _repository.Holiday.GetAsync(id);
            entity.Note = item.Note;
            entity.Date = item.Date;
            entity.Name = item.Name;

            await _repository.Holiday.UpdateAsync(entity);  
        }
    }
}
