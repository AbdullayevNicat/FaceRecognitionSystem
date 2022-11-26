using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.OpenApi.Extensions;
using SchoolFaceRecognition.Core.Enums;
using SchoolFaceRecognition.Core.Infrastructure.ResponseConfig;
using SchoolFaceRecognition.SharedLibrary;
using System.Net;
using System.Security.Claims;

namespace SchoolFaceRecognition.API.Configurations.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly IList<string> _roles;
        public AuthorizeAttribute(params Role[] roles)
        {
            _roles = roles.Select(x=>x.GetDisplayName()).ToList();
        }

        public AuthorizeAttribute()
        {
            _roles = new List<string>();
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            bool hasAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousFilter>().Any();

            if (hasAnonymous)
                return;
            
            ClaimsPrincipal claimsPrincipal = context.HttpContext.User;

            string? role = claimsPrincipal.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;

            if (claimsPrincipal.Identity.IsAuthenticated is false)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                context.Result = new JsonResult(new ErrorResponse(HttpStatusCode.Unauthorized, ConstantLiterals.UserNotFoundMessage));
            }

            if (claimsPrincipal.Identity.IsAuthenticated is true && (string.IsNullOrEmpty(role) is true ||
                                                                        _roles.Any() && _roles.Contains(role) is false))
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                context.Result = new JsonResult(new ErrorResponse(HttpStatusCode.Forbidden, ConstantLiterals.UserForbiddenMessage));
            }
        }
    }
}
