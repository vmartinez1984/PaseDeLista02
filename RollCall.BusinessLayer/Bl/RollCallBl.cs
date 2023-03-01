using RollCall.Core.Interfaces;

namespace RollCall.BusinessLayer.Bl
{
    public class RollCallBl : IBusinessLayer
    {
        public RollCallBl(
            IPersonBl personBl,
            ICodigosPostalesBl codigosPostalesBl
        )
        {
            Person = personBl;
            CodigosPostales = codigosPostalesBl;
        }

        public IPersonBl Person { get; }

        public ICodigosPostalesBl CodigosPostales { get; set; }
    }
}