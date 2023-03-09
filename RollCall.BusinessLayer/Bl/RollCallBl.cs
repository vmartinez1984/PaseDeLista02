using RollCall.Core.Interfaces;

namespace RollCall.BusinessLayer.Bl
{
    public class RollCallBl : IBusinessLayer
    {
        public RollCallBl(
            IPersonBl personBl,
            ICodigosPostalesBl codigosPostalesBl,
            IUserBl userBl,
            IRoleBl roleBl,
            IEmployeeBl employeeBl
        )
        {
            Person = personBl;
            CodigosPostales = codigosPostalesBl;
            User = userBl;
            Role = roleBl;
            Employee = employeeBl;
        }

        public IEmployeeBl Employee { get; }

        public IPersonBl Person { get; }

        public ICodigosPostalesBl CodigosPostales { get; set; }

        public IUserBl User { get; }

        public IRoleBl Role { get; }
    }
}