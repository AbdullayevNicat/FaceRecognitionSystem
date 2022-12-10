using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using SchoolFaceRecognition.API.Configurations.Helpers;
using SchoolFaceRecognition.Core.Enums;
using System.Security.Principal;

namespace SchoolFaceRecognition.API.Configurations.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class HasRequirementsAttribute : Attribute, IAuthorizationFilter
    {
        private List<UserPolicy> _userPolicies;
        public HasRequirementsAttribute(params UserPolicy[] policies) 
        {
            _userPolicies = policies.ToList() ?? new List<UserPolicy>();
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
                if (_userPolicies.Count > 0)
                {
                    AuthorizeByRequirements(context);
                }
            }
        }

        #region Private Section
        private void AuthorizeByRequirements(AuthorizationFilterContext context)
        {
            _userPolicies.ForEach(policy =>
            {
                switch (policy)
                {
                    case UserPolicy.AgeRequirement:
                        AuthorizationRequirements.RequireAge(18, context);
                        break;
                    default:
                        break;
                };
            });
        }
        #endregion
    }
}
