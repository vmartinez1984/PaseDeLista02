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
            IEmployeeBl employeeBl,
            ILoginBl loginBl,
            IHolidayBl holidayBl
        )
        {
            Person = personBl;
            CodigosPostales = codigosPostalesBl;
            User = userBl;
            Role = roleBl;
            Employee = employeeBl;
            Login = loginBl;
            Holiday = holidayBl;
        }

        public IHolidayBl Holiday { get; }

        public IEmployeeBl Employee { get; }

        public IPersonBl Person { get; }

        public ICodigosPostalesBl CodigosPostales { get; }

        public IUserBl User { get; }

        public IRoleBl Role { get; }

        public ILoginBl Login { get; }

        public ICheckInBl CheckIn => throw new NotImplementedException();
    }
}