using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace SchoolFaceRecognition.BL.Services.Auths
{
    internal static class SignService
    {
        internal static SecurityKey GetSymmetricSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
