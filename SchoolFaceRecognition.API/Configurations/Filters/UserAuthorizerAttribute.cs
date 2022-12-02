using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using SchoolFaceRecognition.Core.Abstractions.Services.Cache;
using SchoolFaceRecognition.Core.Enums;
using SchoolFaceRecognition.Core.Infrastructure.ResponseConfig;
using SchoolFaceRecognition.SharedLibrary;
using System.Net;
using System.Security.Claims;

namespace SchoolFaceRecognition.API.Configurations.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class UserAuthorizerAttribute : Attribute, IAuthorizationFilter
    {
        private List<string> _roles;
        public UserAuthorizerAttribute(params RoleType[] roleTypes) 
        {
            _roles = roleTypes.Select(x=>x.ToString()).ToList();
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.Filters.Any(item => item is IAllowAnonymousFilter))
            {
                return;
            }

            bool isAuthenticated = context.HttpContext.User.Identity.IsAuthenticated;

            if (isAuthenticated is false)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                context.Result = new JsonResult(new ErrorResponse(HttpStatusCode.Unauthorized, ConstantLiterals.UserNotFoundMessage));
                return;
            }

            if(isAuthenticated is true && _roles?.Count > 0)
            {
                ICacheProvider cacheProvider = context.HttpContext.RequestServices.GetRequiredService<ICacheProvider>();

                string token = cacheProvider.Get<string>(context.HttpContext.User.Identity.Name);

                if(string.IsNullOrEmpty(token) is false)
                {
                    string comingToken = context.HttpContext.Request.Headers.Authorization.First();

                    if(token == comingToken)
                    {
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        context.Result = new JsonResult(new ErrorResponse(HttpStatusCode.Unauthorized, ConstantLiterals.UserNotFoundMessage));
                        return;
                    }
                }

                IEnumerable<Claim> claims = context.HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.Role);

                bool hasPermission = false;

                foreach (Claim claim in claims)
                {
                    if(_roles.Any(x=>x == claim.Value))
                    {
                        hasPermission = true;
                        break;
                    }

                }

                if (hasPermission is false)
                {
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                    context.Result = new JsonResult(new ErrorResponse(HttpStatusCode.Forbidden, ConstantLiterals.UserForbiddenMessage));
                    return;
                }
            }
        }
    }
}
