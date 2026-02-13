using DeliverySystem.Models;
using DeliverySystem.Models.Enums;
using DeliverySystem.Patterns.Builders;
using DeliverySystem.Patterns.Factories;
using DeliverySystem.Patterns.Services;
using DeliverySystem.Patterns.States;
using DeliverySystem.Patterns.Strategies;
using Xunit;

namespace DeliverySystem.Test
{
    public class OrderTests
    {
        [Fact]
        public void TestOrderBuilder()
        {
            var builder = new StandardOrderBuilder();
            var dish = new Dish(1, "Тестовое блюдо", "Описание", 10.0m, DishCategory.Main, 10);

            builder.SetCustomerInfo("Тест Клиент", "Тестовый адрес");
            builder.AddItem(dish, 2);
            builder.SetOrderType(OrderType.Standard);
            var order = builder.Build();

            Assert.Equal("Тест Клиент", order.CustomerName);
            Assert.Single(order.Items);
            Assert.Equal(20.0m, order.Subtotal);
        }

        [Fact]
        public void TestPricingStrategy()
        {
            var order = new Order
            {
                Subtotal = 100.0m
            };

            var standardStrategy = new StandardPricingStrategy();
            standardStrategy.CalculatePrice(order);
            Assert.Equal(5.0m, order.DeliveryFee);
            Assert.Equal(10.0m, order.Tax);
            Assert.Equal(115.0m, order.Total);

            order.Subtotal = 100.0m;
            var discountStrategy = new DiscountPricingStrategy(0.1m); 
            discountStrategy.CalculatePrice(order);
            Assert.True(order.Total < 115.0m); 

            order.Subtotal = 100.0m;
            var expressStrategy = new ExpressPricingStrategy();
            expressStrategy.CalculatePrice(order);
            Assert.Equal(10.0m, order.DeliveryFee);
            Assert.True(order.Total > 115.0m); 
        }

        [Fact]
        public void TestStatePattern()
        {
            var order = new Order { Id = 1 };
            var preparingState = new PreparingState();
            var deliveringState = new DeliveringState();

            order.CurrentState = preparingState;
            Assert.IsType<PreparingState>(order.CurrentState);

            order.NextState();
            Assert.IsType<DeliveringState>(order.CurrentState);
        }

        [Fact]
        public void TestAbstractFactory()
        {
            IOrderFactory factory = new StandardOrderFactory();

            var standardOrder = factory.CreateStandardOrder("Клиент", "Адрес");
            var expressOrder = factory.CreateExpressOrder("Клиент", "Адрес");

            Assert.Equal(OrderType.Standard, standardOrder.Type);
            Assert.Equal(OrderType.Express, expressOrder.Type);
        }
         
        [Fact]
        public void TestOrderService()
        {
            var orderService = new OrderService();
            var builder = new StandardOrderBuilder();
            var dish = new Dish(1, "Тест", "Тест", 10.0m, DishCategory.Main, 10);

            builder.AddItem(dish);
            builder.SetOrderType(OrderType.Standard);
            var order = orderService.CreateOrder(builder, "Тест", "Тест");

            Assert.NotNull(order);
            Assert.NotEmpty(orderService.GetAllOrders());

        }

        [Fact]
        public void MenuServiceWhenNotFound()
        {
            var menuService = new MenuService();

            Assert.Throws<InvalidOperationException>(() => menuService.GetDishById(-1));
        }
        [Fact]

        public void OrderService_GetOrder_Throws_WhenNotFound()
        {
            var orderService = new OrderService();

            Assert.Throws<InvalidOperationException>(() => orderService.GetOrder(999));
        }

        [Fact]
        public void Pricing_Express_IsMoreExpensiveThanStandard_ForSameSubtotal()
        {
            var order = new Order { Subtotal = 100m };

            var standard = new StandardPricingStrategy();
            standard.CalculatePrice(order);
            var standardTotal = order.Total;

            var express = new ExpressPricingStrategy();
            express.CalculatePrice(order);

            Assert.True(order.Total > standardTotal);
        }
    }
}