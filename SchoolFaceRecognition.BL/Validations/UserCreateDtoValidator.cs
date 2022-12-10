using FluentValidation;
using FluentValidation.Validators;
using SchoolFaceRecognition.Core.Abstractions;
using SchoolFaceRecognition.Core.DTOs.Auth;
using SchoolFaceRecognition.Core.Entities.Auth;
using SchoolFaceRecognition.SharedLibrary;

namespace SchoolFaceRecognition.BL.Validations
{
    public class UserCreateDtoValidator : AbstractValidator<UserCreateDto>
    {
        private IUnitOfWork _unitOfWork;
        public UserCreateDtoValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(x => x.UserName)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage(x => ConstantLiterals.UserNameCanNotBeEmpty)
                .NotEmpty().WithMessage(x=> ConstantLiterals.UserNameCanNotBeEmpty)
                .MinimumLength(6).WithMessage(LocalizedIdentityErrorMessages.UserNameTooShort)
                .Must(HasUserName).WithMessage(LocalizedIdentityErrorMessages.DuplicateUserName);

            RuleFor(x => x.Password)
                .NotNull().WithMessage(x=> ConstantLiterals.UserPasswordCanNotBeEmpty)
                .NotEmpty().WithMessage(x => ConstantLiterals.UserPasswordCanNotBeEmpty)
                .MinimumLength(6).WithMessage(LocalizedIdentityErrorMessages.PasswordTooShort);

            RuleFor(x => x.Email)
                .NotNull().WithMessage(ConstantLiterals.UserEmailCanNotBeEmpty)
                .NotEmpty().WithMessage(ConstantLiterals.UserEmailCanNotBeEmpty)
                .EmailAddress(EmailValidationMode.Net4xRegex)
                    .WithMessage(LocalizedIdentityErrorMessages.InvalidEmail)
                .Must(HasEmail).WithMessage(LocalizedIdentityErrorMessages.DuplicateEmail);
        }

        private bool HasUserName(string? userName)
        {
            User user =  _unitOfWork.UserRepository
                .FirstOrDefaultAsync(x => x.UserName.Equals(userName)).GetAwaiter().GetResult();

            return user is null; 
        }

        private bool HasEmail(string? email)
        {
            User user =  _unitOfWork.UserRepository
                .FirstOrDefaultAsync(x => x.Email.Equals(email)).GetAwaiter().GetResult();

            return user is  null;
        }
    }
}
