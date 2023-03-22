using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RollCall.ApiRest.Helpers
{
    public static class Rol
    {
        public const int User = 2;
        public const int Admin = 1;
    }


    public class AuthorizeRolesAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        //public AuthorizeRolesAttribute()
        //{
            
        //}

        //public AuthorizeRolesAttribute(params int[] roles) : base()
        //{
        //    Roles = string.Join(",", roles);            
        //}

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            
        }       
    }
}
