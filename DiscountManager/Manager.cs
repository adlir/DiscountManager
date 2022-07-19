using DiscountManager.Calculator;
using DiscountManager.Entities;
using DiscountManager.Entities.ValueObjects;
using DiscountManager.Validator;
using FluentValidation.Results;

namespace DiscountManager
{
    public class Manager
    {
        public decimal calculate(decimal amount, ClientType type, int years)
        {
            Client client = new Client(type, years);
            IDiscount discount = DiscountFactory.getDiscount(years);

            List<ValidationFailure> errors = new List<ValidationFailure>();
            ClientValidator clientValidator = new ClientValidator();
            ValidationResult result = clientValidator.Validate(client);
            if(!result.IsValid)
            {
                errors.AddRange(result.Errors);
            }
            AmountValidator amountValidator = new AmountValidator();
            result = amountValidator.Validate(amount);
            if (!result.IsValid)
            {
                errors.AddRange(result.Errors);
            }

            if (errors.Count > 0)
            {
                throw new Exception(String.Join(" | ", errors.Select(x => x.ErrorMessage)));
            }

            PriceCalculator calculator = new PriceCalculator(client, discount);
            return calculator.getPrice(amount);
        }
    }
}