using FluentValidation;
using SchoolFaceRecognition.Core.DTOs.Entities;
using SchoolFaceRecognition.SharedLibrary;

namespace SchoolFaceRecognition.BL.Validations
{
    public class StudentDtoValidator : AbstractValidator<StudentDto>
    {
        public StudentDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage(ConstantLiterals.NameCanNotBeEmpty);

            RuleFor(x => x.Surname).NotEmpty().NotNull().WithMessage(ConstantLiterals.SurnameCanNotBeEmpty);

            RuleFor(x => x.FatherName).NotEmpty().NotNull().WithMessage(ConstantLiterals.FatherNameCanNotBeEmpty);

            RuleFor(x => x.GroupId).GreaterThan(0).WithMessage(ConstantLiterals.GroupCanNotBeEmpty);
        }
    }
}
