using AutoMapper;
using RollCall.Core.Interfaces;

namespace RollCall.BusinessLayer.Bl
{
    public class BaseBl
    {
        protected readonly IRepository _repository;
        protected readonly IMapper _mapper;

        public BaseBl(
            IRepository repository,
            IMapper mapper
        )
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
