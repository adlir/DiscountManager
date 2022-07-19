using DiscountManager.Entities;
using FluentValidation;

namespace DiscountManager.Validator
{
    public class ClientValidator : AbstractValidator<Client>
    {
        public ClientValidator()
        {
            RuleFor(x => x.years).GreaterThanOrEqualTo(0).WithMessage("Account years must be a positive number.");
        }
    }
}
