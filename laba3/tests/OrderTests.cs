using Xunit;
using laba3.Models;
using laba3.Patterns.Factory;
using laba3.Patterns.Builder;
using laba3.Patterns.Strategy;
using laba3.Patterns.State;
using laba3.Patterns.Observer;

namespace tests
{
    public class OrderTests
    {
        private readonly Menu _menu;

        public OrderTests()
        {
            _menu = new Menu();
        }

        [Fact]
        public void Factory_CreateStandardOrder_ShouldCreateOrderWithCorrectType()
        {
            // Arrange & Act
            var order = OrderFactory.CreateStandardOrder("Test Customer", "Test Address");

            // Assert
            Assert.IsType<StandardOrder>(order);
            Assert.Equal("Test Customer", order.CustomerName);
            Assert.Equal("Test Address", order.Address);
        }

        [Fact]
        public void Factory_CreateExpressOrder_ShouldCreateOrderWithCorrectType()
        {
            // Arrange & Act
            var order = OrderFactory.CreateExpressOrder("Test Customer", "Test Address");

            // Assert
            Assert.IsType<ExpressOrder>(order);
            Assert.Equal("Test Customer", order.CustomerName);
            Assert.Equal("Test Address", order.Address);
        }

        [Fact]
        public void State_OrderStatusFlow_ShouldTransitionCorrectly()
        {
            // Arrange
            var order = OrderFactory.CreateStandardOrder("Test", "Address");

            // Act & Assert
            Assert.Equal("Preparing", order.GetCurrentStatus());
            
            order.NextStatus();
            Assert.Equal("Delivering", order.GetCurrentStatus());
            
            order.NextStatus();
            Assert.Equal("Completed", order.GetCurrentStatus());
        }

        [Fact]
        public void State_OrderPreviousStatus_ShouldWorkCorrectly()
        {
            // Arrange
            var order = OrderFactory.CreateStandardOrder("Test", "Address");
            order.NextStatus(); // Preparing -> Delivering

            // Act
            order.PreviousStatus();

            // Assert
            Assert.Equal("Preparing", order.GetCurrentStatus());
        }

        [Fact]
        public void Strategy_BaseCalculation_ShouldCalculateCorrectTotal()
        {
            // Arrange
            var order = OrderFactory.CreateStandardOrder("Test", "Address");
            var pizza = _menu.GetDishById(1)!;
            order.Items.Add(pizza);

            // Act
            var total = order.CalculateTotal();

            // Assert
            decimal expected = pizza.Price + (pizza.Price * 0.1m) + 100m;
            Assert.Equal(expected, total);
        }

        [Fact]
        public void Builder_OrderBuilder_ShouldCreateCompleteOrder()
        {
            // Arrange
            var pizza = _menu.GetDishById(1)!;
            var salad = _menu.GetDishById(3)!;

            // Act
            var order = new OrderBuilder()
                .SetCustomer("Builder Test")
                .SetAddress("Builder Address")
                .AddItem(pizza)
                .AddItem(salad)
                .SetOrderType(OrderType.Standard)
                .Build();

            // Assert
            Assert.Equal("Builder Test", order.CustomerName);
            Assert.Equal("Builder Address", order.Address);
            Assert.Equal(2, order.Items.Count);
            Assert.IsType<StandardOrder>(order);
        }

        [Fact]
        public void Observer_ShouldNotifyWhenStatusChanges()
        {
            // Arrange
            var order = OrderFactory.CreateStandardOrder("Observer Test", "Address");
            var testObserver = new TestObserver();
            order.AddObserver(testObserver);
            var pizza = _menu.GetDishById(1)!;
            order.Items.Add(pizza);

            // Act
            order.NextStatus(); // Preparing -> Delivering

            // Assert
            Assert.True(testObserver.WasNotified);
            Assert.Equal("Preparing", testObserver.OldStatus);
            Assert.Equal("Delivering", testObserver.NewStatus);
        }
    }

    // Test Observer для тестирования паттерна Наблюдатель
    public class TestObserver : IOrderObserver
    {
        public bool WasNotified { get; private set; }
        public string OldStatus { get; private set; } = string.Empty;
        public string NewStatus { get; private set; } = string.Empty;

        public void Update(Order order, string oldStatus, string newStatus)
        {
            WasNotified = true;
            OldStatus = oldStatus;
            NewStatus = newStatus;
        }
    }
}