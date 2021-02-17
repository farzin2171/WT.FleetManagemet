using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;


namespace WT.CommandCenter.Infrastructure.Hubs
{
    public class MessageBrokerHub:Hub
    {
        public Task ReciveMessage(string message)
        {
            return Task.CompletedTask;
        }
    }
}
