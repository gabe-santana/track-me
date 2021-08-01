using System.Net.WebSockets;
using System.Threading.Tasks;
using trackapi.Model;

namespace trackapi.Services.Interfaces
{
    public interface IChangeStreamService<TDocWatch>
    {
       Task Watch(WebSocket websocket, WebSocketReceiveResult result);
    }
}