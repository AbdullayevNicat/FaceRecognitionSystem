using Microsoft.AspNetCore.Mvc;
using SchoolFaceRecognition.Core.Infrastructure.ResponseConfig;
using SchoolFaceRecognition.SharedLibrary;
using System.Net;
using Microsoft.AspNetCore.Mvc.Filters;
using SchoolFaceRecognition.SharedLibrary.Constants;

namespace SchoolFaceRecognition.API.Configurations.Helpers
{
    public static class AuthorizationRequirements
    {
        public static void RequireAge(int age, AuthorizationFilterContext context)
        {
            if (int.TryParse(context.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimConstants.Age).Value, out int userAge))
            {
                if (age > userAge)
                {
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                    context.Result = new JsonResult(new ErrorResponse(HttpStatusCode.Forbidden, ConstantLiterals.UserForbiddenMessage));
                }
            }
        }
    }
}
