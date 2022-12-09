using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using SchoolFaceRecognition.Core.Abstractions.Services.Cache;
using SchoolFaceRecognition.Core.Enums;
using SchoolFaceRecognition.Core.Infrastructure.ResponseConfig;
using SchoolFaceRecognition.SharedLibrary;
using SchoolFaceRecognition.SharedLibrary.Constants;
using System.Net;
using System.Security.Claims;
using System.Security.Principal;

namespace SchoolFaceRecognition.API.Configurations.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class UserAuthorizerAttribute : Attribute, IAuthorizationFilter
    {
        private List<RoleType> _roles;

        public UserAuthorizerAttribute()
        {
            _roles = new List<RoleType>();
        }

        public UserAuthorizerAttribute(params RoleType[] roleTypes) : this()
        {
            _roles = roleTypes.ToList() ?? new List<RoleType>();
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.Filters.Any(item => item is IAllowAnonymousFilter))
            {
                return;
            }

            IIdentity identity = context.HttpContext.User.Identity;

            if (identity is null)
                return;

            bool isAuthenticated = identity.IsAuthenticated;

            if (isAuthenticated is false)
            {
                ResponseUnathorizedMessage(context);
                return;
            }

            if (isAuthenticated is true)
            {
                CheckExpiredToken(context, identity);

                if (_roles.Count > 0)
                {
                    AuthorizeByRoles(context);
                }
            }
        }


        #region Private Methods
        private void CheckExpiredToken(AuthorizationFilterContext context, IIdentity identity)
        {
            ICacheProvider cacheProvider = context.HttpContext.RequestServices.GetRequiredService<ICacheProvider>();

            string token = cacheProvider.Get<string>(identity.Name);

            if (string.IsNullOrEmpty(token) is false)
            {
                string comingToken = context.HttpContext.Request.Headers.Authorization.First();

                if (token == comingToken)
                {
                    ResponseUnathorizedMessage(context);
                    return;
                }
            }
        }

        private void AuthorizeByRoles(AuthorizationFilterContext context)
        {
            IEnumerable<string> roles = context.HttpContext.User
                    .Claims.Where(x => x.Type == ClaimConstants.Role)
                            .Select(x=>x.Value).ToList();

            bool hasPermission = false;

            foreach (string role in roles)
            {
                if (_roles.Any(x => x.ToString() == role))
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

        

        private void ResponseUnathorizedMessage(AuthorizationFilterContext context)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            context.Result = new JsonResult(new ErrorResponse(HttpStatusCode.Unauthorized, ConstantLiterals.UserNotFoundMessage));
        }
        #endregion
    }
}
