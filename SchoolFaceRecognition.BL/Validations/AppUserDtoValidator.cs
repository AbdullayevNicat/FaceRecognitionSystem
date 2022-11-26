using FluentValidation;
using SchoolFaceRecognition.Core.DTOs.Auths;
using SchoolFaceRecognition.SharedLibrary;

namespace SchoolFaceRecognition.BL.Validations
{
    public class AppUserDtoValidator : AbstractValidator<AppUserDto>
    {
        public AppUserDtoValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().NotNull().WithMessage(ConstantLiterals.UserNameCanNotBeEmpty);

            RuleFor(x => x.Email).NotEmpty().NotNull().WithMessage(ConstantLiterals.UserEmailCanNotBeEmpty)
                .EmailAddress().WithMessage(ConstantLiterals.UserEmailIsNotCorrect);

            RuleFor(x => x.City).NotEmpty().NotNull().WithMessage(ConstantLiterals.UserCityCanNotBeEmpty);

            RuleFor(x => x.Password).NotEmpty().NotNull().WithMessage(ConstantLiterals.UserPasswordCanNotBeEmpty);
        }
    }
}
