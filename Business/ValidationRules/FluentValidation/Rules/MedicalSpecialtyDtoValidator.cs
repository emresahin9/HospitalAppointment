using FluentValidation;
using Model.Concrete.Dto;

namespace Business.ValidationRules.FluentValidation.Rules
{
    public class MedicalSpecialtyDtoValidator : AbstractValidator<MedicalSpecialtyDto>
    {
        public MedicalSpecialtyDtoValidator()
        {

            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim boş bırakılamaz!"); ;
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş bırakılamaz!"); ;
        }
    }
}
