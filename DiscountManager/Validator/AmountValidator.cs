using FluentValidation;

namespace DiscountManager.Validator
{
    internal class AmountValidator : AbstractValidator<decimal>
    {
        public AmountValidator()
        {
            RuleFor(x => x).GreaterThanOrEqualTo(0).WithMessage("Amount must be a positive number.");
        }
    }
}
