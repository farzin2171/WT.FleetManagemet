using System.Threading.Tasks;
using WT.MessageBrokers;

namespace WT.FleetDashboard.Infrastructure.MessageBroker
{
    public  interface IMessageHandler
    {
        Task HandleMessageAsync(MessageReceivedEventArgs message);
    }
}
