using FluentValidation;
using FluentValidation.Results;

namespace SchoolFaceRecognition.BL.Helpers
{
    public class Validator<TValidator, TInstance> where TValidator : AbstractValidator<TInstance>
    {
        public bool IsValid { get; private set; }
        public List<string> Errors { get; private set; }

        public Validator(TValidator validator, TInstance instance)
        {
            ValidationResult validationResult = validator.Validate(instance);

            IsValid = validationResult.IsValid;

            if (IsValid)
                Errors = new List<string>();

            Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
        }
    }

    
}
