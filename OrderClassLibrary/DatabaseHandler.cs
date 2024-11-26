/******************************************************************************
 * Author: Shenhan Xu
 * Description: 
 *     This file defines the DatabaseHandler class, which provides functionality
 *     to save orders to a database. The class is designed as a utility class
 *     for database interactions.
 ******************************************************************************/

using System;

namespace OrderClassLibrary
{
    /// <summary>
    /// Handles saving orders to a database.
    /// </summary>
    public class DatabaseHandler
    {
        /// <summary>
        /// Saves the specified order to the database.
        /// Note: This is a placeholder implementation.
        /// </summary>
        /// <param name="order">The order to save.</param>
        public void SaveOrder(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order), "Order cannot be null.");
            }

            // Placeholder for actual database save logic
            Console.WriteLine($"Order {order.OrderNumber} saved to the database.");
        }
    }
}
