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
        [McpServerTool(Name = "HelloNight"), Description("Returns Hello Microsoft Night to all the people in the room of the Microsoft Night")]
        public static string HelloMicrosoftNight()
        {
            return "Hello wonderful audience of the Microsoft Night";
        }

        [McpServerTool(Name = "HelloPizza"), Description("Returns Bon Apetit to all the people eating pizzas")]
        public static string HelloPizzaSession()
        {
            return "Hope you have a wonderful pizza. Bon appetit!";
        }

        [McpServerTool(Name = "OrderStatus"), Description("Returns the order status if the user sends the order id, if the order is unknown, then offer the user the option to create a new order")]
        public static string GetOrderStatus([Description("The order id that was received by e-mail when the user submitted his order")] int orderId )
        {
            if (orderId == 0) return "Shipped";
            if (orderId == 1) return "Canceled";
            return "Unknown";
        }
    }
}
