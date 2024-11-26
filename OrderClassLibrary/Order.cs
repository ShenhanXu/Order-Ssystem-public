/******************************************************************************
 * Author: Shenhan Xu
 * Description: 
 *     This file defines the Order class, which represents a customer's order.
 *     The class includes properties for customer information, tax and tariff 
 *     calculations, and a list of order details. It also provides methods 
 *     to calculate the total amount for the order, including applicable taxes 
 *     and tariffs.
 *
 ******************************************************************************/

using System;
using System.Collections.Generic;

namespace OrderClassLibrary
{
    /// <summary>
    /// Represents a customer's order containing order details, 
    /// and provides methods to calculate total cost, taxes, and tariffs.
    /// </summary>
    public class Order
    {
        public int OrderNumber { get; set; }

        public DateTime DateTime { get; set; }

        public string CustomerName { get; set; }

        public string CustomerPhone { get; set; }

        public double TaxAmount { get; set; }

        public double TariffAmount { get; set; }

        public double TotalAmount { get; set; }

        public List<OrderDetail> Details { get; set; }

        public Order()
        {
            Details = new List<OrderDetail>();
        }

        /// <summary>
        /// Adds a new detail item to the order.
        /// </summary>
        /// <param name="detail">The detail item to add.</param>
        public void AddDetail(OrderDetail detail)
        {
            Details.Add(detail);
        }

        /// <summary>
        /// Calculates the total amount for the order, including:
        /// - Subtotal of all items.
        /// - Tax (10% of the subtotal).
        /// - Tariff (5% for electronics starting with 'ELECT').
        /// </summary>
        public void CalculateTotalAmount()
        {
            TotalAmount = 0;

            // Calculate subtotal from item details
            foreach (var detail in Details)
            {
                TotalAmount += detail.StockPrice * detail.Quantity;
            }

            // Calculate tax (10% of subtotal)
            TaxAmount = TotalAmount * 0.1;

            // Calculate tariff for applicable items
            TariffAmount = CalculateTariff();

            // Final total amount
            TotalAmount += TaxAmount + TariffAmount;
        }

        /// <summary>
        /// Calculates the total tariff amount for items in the order.
        /// Electronics (StockID starts with 'ELECT') incur a 5% tariff.
        /// </summary>
        /// <returns>Total tariff amount for the order.</returns>
        private double CalculateTariff()
        {
            double tariff = 0;
            foreach (var detail in Details)
            {
                if (detail.StockID.StartsWith("ELECT"))
                {
                    tariff += detail.StockPrice * detail.Quantity * 0.05;
                }
            }
            return tariff;
        }
    }
}
