using Isopoh.Cryptography.Argon2;
using System.Text;

namespace SchoolFaceRecognition.BL.Helpers
{
    public static class PasswordHasher
    {
        public static string Hash(string password)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(Argon2.Hash(password)));
        }

        public static bool Verify(string hash, string password)
        {
            return Argon2.Verify(Encoding.UTF8.GetString(Convert.FromBase64String(hash)), password);
        }
    }
}
