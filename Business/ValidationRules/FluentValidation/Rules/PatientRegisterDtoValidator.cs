using FluentValidation;
using Model.Concrete.Dto;

namespace Business.ValidationRules.FluentValidation.Rules
{
    public class PatientRegisterDtoValidator : AbstractValidator<PatientRegisterDto>
    {
        public PatientRegisterDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad boş bırakılamaz!");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad boş bırakılamaz!");
            RuleFor(x => x.IdentityNumber).NotEmpty().WithMessage("Kimlik no boş bırakılamaz!")
            .Must(BeNumeric).WithMessage("Kimlik no sayısal olmalıdır.")
            .Length(11).WithMessage("Kimlik no 11 karakter uzunluğunda olmalıdır.");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Telefon no boş bırakılamaz!")
            .Must(BeNumeric).WithMessage("Telefon no sayısal olmalıdır.")
            .Length(10).WithMessage("Telefon no 10 karakter uzunluğunda olmalıdır.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Eposta boş bırakılamaz!")
            .EmailAddress().WithMessage("Lütfen eposta formatına uygun yazınız!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş bırakılamaz!");
            RuleFor(x => x.PasswordAgain).NotEmpty().WithMessage("Şifre tekrarı boş bırakılamaz!");
            RuleFor(x => x.PasswordAgain).Equal(x => x.Password).WithMessage("Şifreler aynı olmak zorunda!");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Adres boş bırakılamaz!");
        }

        private bool BeNumeric(string value)
        {
            return long.TryParse(value, out _);
        }

    }
}
