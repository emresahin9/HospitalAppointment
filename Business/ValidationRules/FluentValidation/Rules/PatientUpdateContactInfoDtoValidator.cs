using FluentValidation;
using Model.Concrete.Dto;

namespace Business.ValidationRules.FluentValidation.Rules
{
    public class PatientUpdateContactInfoDtoValidator : AbstractValidator<PatientUpdateContactInfoDto>
    {
        public PatientUpdateContactInfoDtoValidator()
        {
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Telefon no boş bırakılamaz!")
            .Must(BeNumeric).WithMessage("Telefon no sayısal olmalıdır.")
            .Length(10).WithMessage("Telefon no 10 karakter uzunluğunda olmalıdır.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Eposta boş bırakılamaz!")
            .EmailAddress().WithMessage("Lütfen eposta formatına uygun yazınız!");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Adres boş bırakılamaz!");
        }

        private bool BeNumeric(string value)
        {
            return long.TryParse(value, out _);
        }

    }
}
