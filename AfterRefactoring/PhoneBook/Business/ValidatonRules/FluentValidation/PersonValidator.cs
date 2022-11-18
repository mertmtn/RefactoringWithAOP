using Entities.Concrete;
using FluentValidation;

namespace Business.ValidatonRules.FluentValidation
{
    public class PersonValidator: AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Person name does not empty.");
            RuleFor(p => p.Surname).NotEmpty().WithMessage("Person surname does not empty.");
            RuleFor(p => p.Address).NotEmpty().WithMessage("Address does not empty.");
            RuleFor(p => p.Email).NotEmpty().WithMessage("Address does not empty.").EmailAddress().WithMessage("Enter valid e-mail address");
            RuleFor(p => p.DepartmentId).NotEmpty().WithMessage("Please select department.");
            RuleFor(p => p.CityId).NotEmpty().WithMessage("Please select city.");
        }
    }
}
