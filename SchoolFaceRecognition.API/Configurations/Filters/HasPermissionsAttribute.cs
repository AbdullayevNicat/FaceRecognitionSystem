using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using SchoolFaceRecognition.Core.Enums;
using SchoolFaceRecognition.Core.Infrastructure.ResponseConfig;
using SchoolFaceRecognition.SharedLibrary;
using System.Net;
using System.Security.Claims;
using System.Security.Principal;

namespace SchoolFaceRecognition.API.Configurations.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class HasPermissionsAttribute : Attribute, IAuthorizationFilter
    {
        private UserRolePermission _userRolePermission;
        public HasPermissionsAttribute(UserRolePermission userRolePermission)
        {
            _userRolePermission = userRolePermission;
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

            if (identity.IsAuthenticated is true)
            {
                AuthorizeByPermissions(context);
            }
        }



        #region Private Section
        private void AuthorizeByPermissions(AuthorizationFilterContext context)
        {
            IEnumerable<string> permissions = context.HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.AuthorizationDecision).Select(x => x.Value).ToList();

            bool hasPermission = false;

            if(permissions.Any(x=>x == _userRolePermission.ToString()))
            {
                hasPermission = true;
            }

            if (hasPermission is false)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                context.Result = new JsonResult(new ErrorResponse(HttpStatusCode.Forbidden, ConstantLiterals.UserForbiddenMessage));
            }
        }
        #endregion
    }
}
