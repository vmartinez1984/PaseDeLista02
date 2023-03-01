using RollCall.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollCall.Core.Interfaces
{
    public interface ICodigosPostalesRepository
    {
        Task<List<CodigoPostalEntity>> ObtenerCodigosPostales(string codigoPostal);
    }
}