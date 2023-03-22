using RollCall.Core.Dtos;

namespace RollCall.Core.Interfaces
{
    public interface IBusinessLayer
    {
        IPersonBl Person { get; }

        ICodigosPostalesBl CodigosPostales { get; }

        IUserBl User { get; }

        IRoleBl Role { get; }

        IEmployeeBl Employee { get; }
        ILoginBl Login { get; }
    }


    public interface ILoginBl
    {
        Task<TokenDto> LoginAsync(UserLoginDto userLoginDto);
    }

    /// <summary>
    /// Donde T es la entrada y U la salida
    /// </summary>
    /// <typeparam name="T">Entrada</typeparam>
    /// <typeparam name="U">Salida</typeparam>
    public interface IBaseBl<T, U> where T : class
    {
        Task<int> AddAsync(T item);
        Task DeleteAsync(int id);
        Task<U> GetAsync(int id);
        Task UpdateAsync(T item, int id);
    }

    public interface IEmployeeBl : IBaseBl<EmployeeDtoIn, EmployeeDto>
    {
        Task<PagerDto> GetAsync(PagerDtoIn pagerDtoIn);
    }

    public interface ICodigosPostalesBl
    {
        Task<List<CodigoPostalDto>> ObtenerCodigosPostales(string codigoPostal);
    }

    public interface IPersonBl : IBaseBl<PersonDtoIn, PersonDto>
    {
        //Task<List<PersonDto>> GetAsync();
        Task<PagerDto> GetAsync(PagerDtoIn pagerDto);
    }

    public interface IUserBl : IBaseBl<UserDtoIn, UserDto>
    {
        Task<List<UserDto>> GetAsync();
    }

    public interface IRoleBl
    {
        Task<List<RoleDto>> GetAsync();
    }
}
