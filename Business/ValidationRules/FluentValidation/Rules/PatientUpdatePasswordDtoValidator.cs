using FluentValidation;
using Model.Concrete.Dto;

namespace Business.ValidationRules.FluentValidation.Rules
{
    public class PatientUpdatePasswordDtoValidator : AbstractValidator<PatientUpdatePasswordDto>
    {
        public PatientUpdatePasswordDtoValidator()
        {
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş bırakılamaz!");
            RuleFor(x => x.NewPassword).NotEmpty().WithMessage("Şifre boş bırakılamaz!");
            RuleFor(x => x.NewPasswordAgain).NotEmpty().WithMessage("Şifre tekrarı boş bırakılamaz!");
            RuleFor(x => x.NewPasswordAgain).Equal(x => x.NewPassword).WithMessage("Şifreler aynı olmak zorunda!");
        }

        private bool BeNumeric(string value)
        {
            return long.TryParse(value, out _);
        }

    }
}
