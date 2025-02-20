using FluentValidation;
using Model.Concrete.Dto;

namespace Business.ValidationRules.FluentValidation.Rules
{
    public class DoctorDtoValidator : AbstractValidator<DoctorDto>
    {
        public DoctorDtoValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Eposta boş bırakılamaz!");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Lütfen eposta formatına uygun yazınız!");
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim boş bırakılamaz!");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyisim boş bırakılamaz!");
            RuleFor(x => x.MedicalSpecialtyId).NotEmpty().WithMessage("Branş seçilmek zorunda!");
        }
    }
}
