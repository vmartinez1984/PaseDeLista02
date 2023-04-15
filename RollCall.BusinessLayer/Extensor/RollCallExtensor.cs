using Microsoft.Extensions.DependencyInjection;
using RollCall.BusinessLayer.Bl;
using RollCall.Core.Interfaces;

namespace RollCall.BusinessLayer.Extensor
{
    public static class RollCallExtensor
    {
        public static void  AddRollCall(this IServiceCollection services)
        {
            services.AddScoped<IPersonBl, PersonBl>();

            services.AddScoped<IBusinessLayer, RollCallBl>();

            services.AddScoped<ICodigosPostalesBl, CodigosPostalesBl>();
            
            services.AddScoped<IUserBl, UserBl>();        
            
            services.AddScoped<IRoleBl, RoleBl>();
            
            services.AddScoped<IEmployeeBl, EmployeeBl>();

            services.AddScoped<ILoginBl, LoginBl>();

            services.AddScoped<IHolidayBl, HolidayBl>();
        }
    }
}