using System;
using OrderClassLibrary;

namespace Driver
{
    /// <summary>
    /// A console application that demonstrates the functionality of the Order and OrderDetail classes.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Test Case 1: Basic order with one electronic item and one non-electronic item
            TestBasicOrder();

            // Test Case 2: Order with no items
            TestEmptyOrder();

            // Test Case 3: Order with multiple electronic items
            TestMultipleElectronics();

            // Test Case 4: Order with zero quantity for an item
            TestZeroQuantityItem();

            Console.WriteLine("All tests completed.");
        }

        /// <summary>
        /// Test Case 1: Demonstrates a basic order with an electronic item and a non-electronic item.
        /// </summary>
        static void TestBasicOrder()
        {
            Console.WriteLine("Test Case 1: Basic Order");

            var order = new Order
            {
                OrderNumber = 1001,
                DateTime = DateTime.Now,
                CustomerName = "John Doe",
                CustomerPhone = "123-456-7890"
            };

            var detail1 = new OrderDetail
            {
                OrderNumber = 1001,
                DetailNumber = 1,
                StockID = "ELECT001",
                StockName = "42 Inch TV",
                StockPrice = 300.0,
                Quantity = 1
            };

            var detail2 = new OrderDetail
            {
                OrderNumber = 1001,
                DetailNumber = 2,
                StockID = "OTHER001",
                StockName = "Office Chair",
                StockPrice = 100.0,
                Quantity = 2
            };

            order.AddDetail(detail1);
            order.AddDetail(detail2);

            order.CalculateTotalAmount();

            Console.WriteLine($"Order Total: {order.TotalAmount}");
            Console.WriteLine($"Tax: {order.TaxAmount}");
            Console.WriteLine($"Tariff: {order.TariffAmount}");
            Console.WriteLine();
        }

        /// <summary>
        /// Test Case 2: Demonstrates an order with no items.
        /// </summary>
        static void TestEmptyOrder()
        {
            Console.WriteLine("Test Case 2: Empty Order");

            var order = new Order
            {
                OrderNumber = 1002,
                DateTime = DateTime.Now,
                CustomerName = "Jane Smith",
                CustomerPhone = "987-654-3210"
            };

            // No items are added to the order

            order.CalculateTotalAmount();

            Console.WriteLine($"Order Total: {order.TotalAmount}");
            Console.WriteLine($"Tax: {order.TaxAmount}");
            Console.WriteLine($"Tariff: {order.TariffAmount}");
            Console.WriteLine();
        }

        /// <summary>
        /// Test Case 3: Demonstrates an order with multiple electronic items.
        /// </summary>
        static void TestMultipleElectronics()
        {
            Console.WriteLine("Test Case 3: Multiple Electronics");

            var order = new Order
            {
                OrderNumber = 1003,
                DateTime = DateTime.Now,
                CustomerName = "Alice Johnson",
                CustomerPhone = "555-123-4567"
            };

            var detail1 = new OrderDetail
            {
                OrderNumber = 1003,
                DetailNumber = 1,
                StockID = "ELECT001",
                StockName = "Laptop",
                StockPrice = 800.0,
                Quantity = 1
            };

            var detail2 = new OrderDetail
            {
                OrderNumber = 1003,
                DetailNumber = 2,
                StockID = "ELECT002",
                StockName = "Smartphone",
                StockPrice = 500.0,
                Quantity = 1
            };

            order.AddDetail(detail1);
            order.AddDetail(detail2);

            order.CalculateTotalAmount();

            Console.WriteLine($"Order Total: {order.TotalAmount}");
            Console.WriteLine($"Tax: {order.TaxAmount}");
            Console.WriteLine($"Tariff: {order.TariffAmount}");
            Console.WriteLine();
        }

        /// <summary>
        /// Test Case 4: Demonstrates an order with an item that has a zero quantity.
        /// </summary>
        static void TestZeroQuantityItem()
        {
            Console.WriteLine("Test Case 4: Zero Quantity Item");

            var order = new Order
            {
                OrderNumber = 1004,
                DateTime = DateTime.Now,
                CustomerName = "Bob Brown",
                CustomerPhone = "444-567-8901"
            };

            var detail = new OrderDetail
            {
                OrderNumber = 1004,
                DetailNumber = 1,
                StockID = "ELECT003",
                StockName = "Headphones",
                StockPrice = 150.0,
                Quantity = 0 // Zero quantity
            };

            order.AddDetail(detail);

            order.CalculateTotalAmount();

            Console.WriteLine($"Order Total: {order.TotalAmount}");
            Console.WriteLine($"Tax: {order.TaxAmount}");
            Console.WriteLine($"Tariff: {order.TariffAmount}");
            Console.WriteLine();
        }
    }
}
