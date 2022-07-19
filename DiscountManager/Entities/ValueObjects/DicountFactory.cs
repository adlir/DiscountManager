namespace DiscountManager.Entities.ValueObjects
{
    public class DiscountFactory
    {
        //Add other discount implementations
        public static IDiscount getDiscount(int years)
        {
            return new Discount(years);
        }
    }
}
