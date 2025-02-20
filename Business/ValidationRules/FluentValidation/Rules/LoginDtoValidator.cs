using FluentValidation;
using Model.Concrete.Dto;

namespace Business.ValidationRules.FluentValidation.Rules
{
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Eposta boş bırakılamaz!");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Lütfen eposta formatına uygun yazınız!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş bırakılamaz!");
        }
    }
}
