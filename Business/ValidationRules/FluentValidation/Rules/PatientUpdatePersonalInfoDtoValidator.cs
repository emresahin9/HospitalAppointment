using FluentValidation;
using Model.Concrete.Dto;

namespace Business.ValidationRules.FluentValidation.Rules
{
    public class PatientUpdatePersonalInfoDtoValidator : AbstractValidator<PatientUpdatePersonalInfoDto>
    {
        public PatientUpdatePersonalInfoDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad boş bırakılamaz!");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad boş bırakılamaz!");
            //RuleFor(x => x.IdentityNumber).NotEmpty().WithMessage("Kimlik no boş bırakılamaz!")
            //.Must(BeNumeric).WithMessage("Kimlik no sayısal olmalıdır.")
            //.Length(11).WithMessage("Kimlik no 11 karakter uzunluğunda olmalıdır.");
        }

        private bool BeNumeric(string value)
        {
            return long.TryParse(value, out _);
        }

    }
}
