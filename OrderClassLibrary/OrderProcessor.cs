/******************************************************************************
 * Author: Shenhan Xu

 * Description: 
 *     This file defines the OrderProcessor class, which handles the business
 *     logic for processing orders. It includes methods for validating and saving
 *     orders to the appropriate storage (database or JSON file).
 ******************************************************************************/

using System;

namespace OrderClassLibrary
{
    /// <summary>
    /// Handles the processing and saving of orders, including validation
    /// and total amount calculations.
    /// </summary>
    public class OrderProcessor
    {
        /// <summary>
        /// Processes the order by calculating totals and validating the data.
        /// </summary>
        /// <param name="order">The order to process.</param>
        /// <returns>True if the order is valid, otherwise false.</returns>
        public bool ProcessOrder(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order), "Order cannot be null.");
            }

            // Calculate the total amount for the order
            order.CalculateTotalAmount();

            // Example validation logic (e.g., ensure customer info is complete)
            if (string.IsNullOrEmpty(order.CustomerName) || string.IsNullOrEmpty(order.CustomerPhone))
            {
                Console.WriteLine("Order validation failed: Missing customer details.");
                return false;
            }

            Console.WriteLine("Order processed successfully.");
            return true;
        }

        /// <summary>
        /// Saves the order to the specified target (Database or JSON file).
        /// </summary>
        /// <param name="order">The order to save.</param>
        /// <param name="target">The target storage type ("Database" or "JSON").</param>
        public void SaveOrder(Order order, string target)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order), "Order cannot be null.");
            }

            switch (target)
            {
                case "Database":
                    var dbHandler = new DatabaseHandler();
                    dbHandler.SaveOrder(order);
                    break;

                case "JSON":
                    var jsonHandler = new JSONHandler();
                    jsonHandler.SaveOrderToJSON(order);
                    break;

                default:
                    throw new ArgumentException($"Invalid target: {target}", nameof(target));
            }

            Console.WriteLine($"Order saved to {target} successfully.");
        }
    }
}
