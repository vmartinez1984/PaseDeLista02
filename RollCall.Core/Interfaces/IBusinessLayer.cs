using RollCall.Core.Dtos;

namespace RollCall.Core.Interfaces
{
    public interface IBusinessLayer
    {
        IPersonBl Person { get; }

        ICodigosPostalesBl CodigosPostales { get; }
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

    public interface ICodigosPostalesBl
    {
        Task<List<CodigoPostalDto>> ObtenerCodigosPostales(string codigoPostal);
    }

    public interface IPersonBl : IBaseBl<PersonDtoIn, PersonDto>
    //{
    {
        //Task<List<PersonDto>> GetAsync();
        Task<PagerDto> GetAsync(PagerDtoIn pagerDto);
    }
}
