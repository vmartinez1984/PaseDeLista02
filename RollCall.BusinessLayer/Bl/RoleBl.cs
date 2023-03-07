using AutoMapper;
using RollCall.Core.Dtos;
using RollCall.Core.Entities;
using RollCall.Core.Interfaces;

namespace RollCall.BusinessLayer.Bl
{
    public class RoleBl : BaseBl, IRoleBl
    {
        public RoleBl(IRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public async Task<List<RoleDto>> GetAsync()
        {
            List<RoleDto> roleDtos;
            List<Role> roleList;

            roleList = await _repository.Role.GetAsync();
            roleDtos = _mapper.Map<List<RoleDto>>(roleList);

            return roleDtos;
        }
    }
}
