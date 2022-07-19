namespace DiscountManager.Entities
{
    public class Client
    {
        public int years { get; set; }
        public ClientType type { get; set; }

        public Client(ClientType type, int years)
        {
            this.years = years;
            this.type = type;
        }
        
    }
}
