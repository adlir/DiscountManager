using Constants;

namespace DiscountManager.Entities.ValueObjects
{
    public class Discount : IDiscount
    {
        private decimal value;

        public Discount(int years)
        {
            value = years > DiscountConstants.CutOffInYears ? DiscountConstants.PercentageNewAccount : years * DiscountConstants.PercentagePerYear;
        }

        public decimal get()
        {
            return value;
        }
    }
}