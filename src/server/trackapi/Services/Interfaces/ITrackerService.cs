using System.Net.WebSockets;
using System.Threading.Tasks;

namespace trackapi.Services.Interfaces
{
    public interface ITrackerService
    {
        Task UpdateTrackerStatus(WebSocket webSocket);
    }
}