using Constants;
using DiscountManager.Entities;
using DiscountManager.Entities.ValueObjects;

namespace DiscountManager.Calculator
{
    public class PriceCalculator
    {
        private Client client;
        private IDiscount discount;

        public PriceCalculator(Client client, IDiscount discount)
        {
            this.client = client;
            this.discount = discount;
        }

        public decimal getPrice(decimal amount)
        {

            decimal result = 0;
            switch (this.client.type)
            {
                case ClientType.unregistered:
                    result = amount;
                    break;
                case ClientType.registered:
                    result = ClientConstants.RegisteredPercentage * amount;
                    result = result - this.discount.get() * result;
                    break;
                case ClientType.valuable:
                    result = ClientConstants.ValuablePercentage * amount;
                    result = result - this.discount.get() * result;
                    break;
                case ClientType.mostValuable:
                    result = ClientConstants.MostValuablePercentage * amount;
                    result = result - this.discount.get() * result;
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}
