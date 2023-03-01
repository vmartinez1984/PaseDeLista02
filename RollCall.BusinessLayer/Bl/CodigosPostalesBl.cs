using RollCall.Core.Dtos;
using RollCall.Core.Entities;
using RollCall.Core.Interfaces;

namespace RollCall.BusinessLayer.Bl
{
    public class CodigosPostalesBl: ICodigosPostalesBl
    {
        private readonly ICodigosPostalesRepository _codigosPostalesRepository;

        public CodigosPostalesBl(ICodigosPostalesRepository codigosPostalesRepository)
        {
            _codigosPostalesRepository = codigosPostalesRepository;
        }
        
        public async Task<List<CodigoPostalDto>> ObtenerCodigosPostales(string codigoPostal)
        {
            List<CodigoPostalEntity> entities;
            List<CodigoPostalDto> lista;

            entities = await _codigosPostalesRepository.ObtenerCodigosPostales(codigoPostal);
            lista = new List<CodigoPostalDto>();
            entities.ForEach(codigoPostalEntity =>
            {
                lista.Add(new CodigoPostalDto
                {
                    CodigoPostal = codigoPostalEntity.CodigoPostal,
                    Colonia = codigoPostalEntity.TipoDeAsentamiento + " " + codigoPostalEntity.Asentamiento
                });
            });

            return lista;
        }
    }
}