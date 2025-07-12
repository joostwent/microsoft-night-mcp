using ModelContextProtocol.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftNights.McpServerDemo.Tools
{
    [McpServerToolType]
    public class HelloWorldTool
    {
        [McpServerTool(Name = "OrderStatus"), Description("Returns the order status if the user sends the order id, if the order is unknown, then offer the user the option to create a new order")]
        public static string GetOrderStatus([Description("The order id that was received by e-mail when the user submitted his order")] int orderId )
        {
            if (orderId == 0) return "Shipped";
            if (orderId == 1) return "Canceled";
            return "Unknown";
        }

        [McpServerTool(Name = "CreateOrder"), Description("Creates a new order and returns the order id of the created order")]
        public static int CreateOrder(
            [Description("The name of the product")] string productName,
            [Description("The amount of items")] int amount,
            [Description("The customer id of the client. Get the id from GetCustomerByEmailAddress if only the e-mail address is known")] int customerId)
        {
            return Random.Shared.Next();
        }

        [McpServerTool(Name = "GetCustomerByEmailAddress"), Description("Returns the customer id that belongs to an e-mail address, or null if not found")]
        public static int? GetCustomerByEmailAddress(
            [Description("The e-mail address of the customer")] string emailAddress)
        {
            if (emailAddress.Equals("joost.went@capgemini.com", StringComparison.InvariantCultureIgnoreCase)) 
                return 17;
            return null;
        }
    }
}
