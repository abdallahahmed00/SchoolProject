using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.AuthServices.Interfaces;
namespace Core.Filters
{
    public class AuthFilter :IAsyncActionFilter
    {
        private readonly ICurrentUserService _currentUserService;
        public AuthFilter(ICurrentUserService currentUserService)
        {
            _currentUserService=currentUserService;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if(context.HttpContext.User.Identity.IsAuthenticated==true)
            {
                var roles = await _currentUserService.GetCurrentUserRolesAsync();
                if (roles.All(x => x != "User"))
                {
                    context.Result = new ObjectResult("Forbidden")
                    {
                        StatusCode = StatusCodes.Status403Forbidden

                    };
                }
                else
                {
                    await  next();
                }
            }

           }
        
    }
}
