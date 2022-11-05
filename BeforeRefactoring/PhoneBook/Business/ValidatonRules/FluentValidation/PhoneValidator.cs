using Entities.Concrete;
using FluentValidation;

namespace Business.ValidatonRules.FluentValidation
{
    public class PhoneValidator:AbstractValidator<Phone>
    {
        public PhoneValidator()
        {
            RuleFor(p=>p.PhoneNumber).NotNull().NotEmpty().WithMessage("Phone number is not empty!");
            RuleFor(p => p.AreaCode).NotNull().NotEmpty().WithMessage("Area code is not empty!");
            RuleFor(p => p.PhoneTypeId).NotNull().NotEmpty().WithMessage("Please select phone type!");
            RuleFor(p => p.PersonId).NotNull().NotEmpty().WithMessage("Please select person!");
        }
    }
}
