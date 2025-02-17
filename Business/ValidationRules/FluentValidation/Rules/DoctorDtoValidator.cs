using FluentValidation;
using Model.Concrete.Dto;

namespace Business.ValidationRules.FluentValidation.Rules
{
    public class DoctorDtoValidator : AbstractValidator<DoctorDto>
    {
        public DoctorDtoValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Surname).NotEmpty();
            RuleFor(x => x.MedicalSpecialtyId).NotEmpty();
        }
    }
}
