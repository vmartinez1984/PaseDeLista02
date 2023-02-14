using RollCall.Core.Interfaces;

namespace RollCall.BusinessLayer.Bl
{
    public class RollCallBl : IBusinessLayer
    {
        public RollCallBl(
            IPersonBl personBl
        )
        {
            Person = personBl;
        }

        public IPersonBl Person { get; }
    }
}
