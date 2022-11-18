using Entities.Concrete;
using FluentValidation;

namespace Business.ValidatonRules.FluentValidation
{
    public class DepartmentValidator:AbstractValidator<Department>
    {
        public DepartmentValidator()
        {
            RuleFor(d => d.Name).NotEmpty().WithMessage("Department name does not empty!");
        }
    }
}
