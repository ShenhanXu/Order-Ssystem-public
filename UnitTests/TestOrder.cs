using Xunit;
using OrderClassLibrary;

namespace UnitTests
{
    /// <summary>
    /// Unit tests for the Order class, focusing on calculating total amounts,
    /// including taxes and tariffs based on order details.
    /// </summary>
    public class TestOrder
    {
        /// <summary>
        /// Tests the total amount calculation for an order with one electronic item
        /// that includes tariffs and taxes.
        /// </summary>
        [Fact]
        public void TestOrderTotalCalculation()
        {
            var order = new Order();
            
            // Add an OrderDetail item (Electronic item with tariff)
            var detail = new OrderDetail
            {
                StockID = "ELECT001", // Electronic item triggers tariff
                StockPrice = 100.0,
                Quantity = 2
            };

            order.AddDetail(detail);

            // Calculate total amount
            order.CalculateTotalAmount();

            // Expected total: Subtotal (200) + Tax (20) + Tariff (10) = 230
            Assert.Equal(230.0, order.TotalAmount);
        }

        /// <summary>
        /// Tests the total amount calculation for an order with no tariff items.
        /// </summary>
        [Fact]
        public void TestOrderTotalWithoutTariff()
        {
            var order = new Order();
            
            // Add an OrderDetail item (Non-electronic item)
            var detail = new OrderDetail
            {
                StockID = "OTHER001", // Non-electronic item
                StockPrice = 50.0,
                Quantity = 3
            };

            order.AddDetail(detail);

            // Calculate total amount
            order.CalculateTotalAmount();

            // Expected total: Subtotal (150) + Tax (15) = 165
            Assert.Equal(165.0, order.TotalAmount);
        }

        /// <summary>
        /// Tests the calculation for an order with multiple items,
        /// including both electronic and non-electronic items.
        /// </summary>
        [Fact]
        public void TestOrderWithMultipleItems()
        {
            var order = new Order();
            
            // Add an electronic item
            var detail1 = new OrderDetail
            {
                StockID = "ELECT001", // Electronic item
                StockPrice = 200.0,
                Quantity = 1
            };

            // Add a non-electronic item
            var detail2 = new OrderDetail
            {
                StockID = "OTHER001", // Non-electronic item
                StockPrice = 50.0,
                Quantity = 2
            };

            order.AddDetail(detail1);
            order.AddDetail(detail2);

            // Calculate total amount
            order.CalculateTotalAmount();

            // Expected total:
            // Subtotal: 200 (Electronic) + 100 (Non-electronic) = 300
            // Tax: 300 * 0.1 = 30
            // Tariff: 200 * 0.05 = 10
            // Total: 300 + 30 + 10 = 340
            Assert.Equal(340.0, order.TotalAmount);
        }

        /// <summary>
        /// Tests the calculation for an empty order (no items).
        /// </summary>
        [Fact]
        public void TestEmptyOrder()
        {
            var order = new Order();

            // Calculate total amount for an empty order
            order.CalculateTotalAmount();

            // Expected total: 0
            Assert.Equal(0.0, order.TotalAmount);
        }

        /// <summary>
        /// Tests the calculation when an item has zero quantity.
        /// </summary>
        [Fact]
        public void TestOrderWithZeroQuantity()
        {
            var order = new Order();

            // Add an item with zero quantity
            var detail = new OrderDetail
            {
                StockID = "ELECT001", // Electronic item
                StockPrice = 100.0,
                Quantity = 0
            };

            order.AddDetail(detail);

            // Calculate total amount
            order.CalculateTotalAmount();

            // Expected total: 0 (no items contribute to total)
            Assert.Equal(0.0, order.TotalAmount);
        }
    }
}
