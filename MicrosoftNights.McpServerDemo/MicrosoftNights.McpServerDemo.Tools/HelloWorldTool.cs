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
            [Description("The customer id of the client")] int customerId)
        {
            return Random.Shared.Next();
        }
    }
}
