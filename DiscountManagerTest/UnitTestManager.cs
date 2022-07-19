using DiscountManager;
using DiscountManager.Entities;

namespace DiscountManagerTest
{
    public class UnitTestManager
    {
        [Fact]
        public void test_unregistered_client()
        {
            Manager manager = new Manager();

            Assert.Equal(50, manager.calculate(50, ClientType.unregistered, 1));
        }

        [Fact]
        public void test_registered()
        {
            Manager manager = new Manager();

            Assert.Equal((decimal)8.910, manager.calculate(10, ClientType.registered, 1));
        }

        [Fact]
        public void test_valuable()
        {
            Manager manager = new Manager();

            Assert.Equal((decimal)6.930, manager.calculate(10, ClientType.valuable, 1));
        }

        [Fact]
        public void test_most_valuable()
        {
            Manager manager = new Manager();

            Assert.Equal((decimal)4.950, manager.calculate(10, ClientType.mostValuable, 1));
        }

        [Fact]
        public void test_most_valuable_older_then_5()
        {
            Manager manager = new Manager();

            Assert.Equal((decimal)4.750, manager.calculate(10, ClientType.mostValuable, 7));
        }


        [Fact]
        public void test_negative_amount()
        {
            Manager manager = new Manager();

            Exception exception = Assert.Throws<Exception>(() => manager.calculate(-10, ClientType.unregistered, 1));
            Assert.Equal("Amount must be a positive number.", exception.Message);
        }

        [Fact]
        public void test_negative_year()
        {
            Manager manager = new Manager();

            Exception exception = Assert.Throws<Exception>(() => manager.calculate(10, ClientType.unregistered, -1));
            Assert.Equal("Account years must be a positive number.", exception.Message);
        }

        [Fact]
        public void test_negative_year_and_amount()
        {
            Manager manager = new Manager();

            Exception exception = Assert.Throws<Exception>(() => manager.calculate(-1, ClientType.unregistered, -1));
            Assert.Equal("Account years must be a positive number. | Amount must be a positive number.", exception.Message);
        }

    }
}