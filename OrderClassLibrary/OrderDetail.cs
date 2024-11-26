/******************************************************************************
 * Author: Shenhan Xu
 * Description: 
 *     This file defines the OrderDetail class, which represents an individual 
 *     item within a customer's order. Each OrderDetail includes information 
 *     about the item such as its ID, name, price, and quantity. 
 *
 ******************************************************************************/

namespace OrderClassLibrary
{
    /// <summary>
    /// Represents an individual item within a customer's order.
    /// </summary>
    public class OrderDetail
    {
        /// <summary>
        /// The order number this detail item belongs to.
        /// </summary>
        public int OrderNumber { get; set; }

        /// <summary>
        /// Unique detail number for this item within the order.
        /// Starts at 1 and increments for each item.
        /// </summary>
        public int DetailNumber { get; set; }

        /// <summary>
        /// Stock ID of the item (e.g., ELECT001 for electronics).
        /// </summary>
        public string StockID { get; set; }

        /// <summary>
        /// The name or description of the item.
        /// </summary>
        public string StockName { get; set; }

        /// <summary>
        /// The price per unit of the item.
        /// </summary>
        public double StockPrice { get; set; }

        /// <summary>
        /// The quantity of the item ordered.
        /// </summary>
        public int Quantity { get; set; }
    }
}
