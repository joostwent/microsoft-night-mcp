using Microsoft.Extensions.AI;
using ModelContextProtocol;
using ModelContextProtocol.Server;
using System.ComponentModel;

namespace MicrosoftNights.McpServerDemo.Tools
{
    [McpServerToolType]
    public static class CustomerTool
    {

        [McpServerTool(Name = "GetCustomerByEmailAddress"), Description("Returns the customer id that belongs to an e-mail address or null if not found")]
        public static async Task<string?> GetCustomerByEmailAddress(
            IMcpServer mcpServer,
            [Description("The e-mail address of the customer")] string emailAddress,
            CancellationToken cancellationToken)
        {
            if (emailAddress.Equals("joost.went@capgemini.com", StringComparison.InvariantCultureIgnoreCase))
                return "17";
            return null;
        }
    }
}