using Microsoft.AspNetCore.Identity;
using SchoolFaceRecognition.SharedLibrary;

namespace SchoolFaceRecognition.API.Configurations.Helpers
{
    public class LocalizedIdentityErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError DuplicateEmail(string email)
        {
            return new IdentityError
            {
                Code = nameof(DuplicateEmail),
                Description = string.Format(LocalizedIdentityErrorMessages.DuplicateEmail, email)
            };
        }

        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError
            {
                Code = nameof(DuplicateUserName),
                Description = string.Format(LocalizedIdentityErrorMessages.DuplicateUserName, userName)
            };
        }

        public override IdentityError InvalidEmail(string email)
        {
            return new IdentityError
            {
                Code = nameof(InvalidEmail),
                Description = string.Format(LocalizedIdentityErrorMessages.InvalidEmail, email)
            };
        }

       

        public override IdentityError InvalidUserName(string userName)
        {
            return new IdentityError
            {
                Code = nameof(InvalidUserName),
                Description = string.Format(LocalizedIdentityErrorMessages.InvalidUserName, userName)
            };
        }


        public override IdentityError PasswordMismatch()
        {
            return new IdentityError
            {
                Code = nameof(PasswordMismatch),
                Description = LocalizedIdentityErrorMessages.PasswordMismatch
            };
        }

        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError
            {
                Code = nameof(PasswordRequiresDigit),
                Description = LocalizedIdentityErrorMessages.PasswordRequiresDigit
            };
        }

        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError
            {
                Code = nameof(PasswordRequiresLower),
                Description = LocalizedIdentityErrorMessages.PasswordRequiresLower
            };
        }

        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError
            {
                Code = nameof(PasswordRequiresNonAlphanumeric),
                Description = LocalizedIdentityErrorMessages.PasswordRequiresNonAlphanumeric
            };
        }

        public override IdentityError PasswordRequiresUniqueChars(int uniqueChars)
        {
            return new IdentityError
            {
                Code = nameof(PasswordRequiresUniqueChars),
                Description = string.Format(LocalizedIdentityErrorMessages.PasswordRequiresUniqueChars, uniqueChars)
            };
        }

        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError
            {
                Code = nameof(PasswordRequiresUpper),
                Description = LocalizedIdentityErrorMessages.PasswordRequiresUpper
            };
        }

        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError
            {
                Code = nameof(PasswordTooShort),
                Description = string.Format(LocalizedIdentityErrorMessages.PasswordTooShort, length)
            };
        }
    }
}
