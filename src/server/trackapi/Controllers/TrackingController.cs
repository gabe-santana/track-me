using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using trackapi.DTO;
using trackapi.Mappers;
using trackapi.Model;
using trackapi.Repositories.Interfaces;
using trackapi.Services.Interfaces;

namespace trackapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrackingController : ControllerBase
    {
        private readonly ILogger<TrackingController> _logger;
        private readonly ITrackerService trackerService;
        
        public TrackingController(ITrackerService trackerService, ILogger<TrackingController> _logger, ITrackerRepository trackerRepository)
        {
            this.trackerService = trackerService;
            this._logger = _logger;
        }
         

        [HttpGet("/ws/tracker/send")]
        public async Task TrackerConnectionSend()
        {
          if (HttpContext.WebSockets.IsWebSocketRequest)
          {
              using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
              _logger.Log(LogLevel.Information, "New WebSocket connection established (Receiving from tracker)");
              await trackerService.UpdateTrackerStatus(webSocket);
          }
          else
              HttpContext.Response.StatusCode = 400;
        }

        [HttpGet("/ws/tracker/receive")]
        public async Task TrackerConnectionReceive()
        {
          if (HttpContext.WebSockets.IsWebSocketRequest)
          {
              using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
              _logger.Log(LogLevel.Information, "New WebSocket connection established (Receiving from tracker)");
              await trackerService.GetTrackerStatus(webSocket);
          }
          else
              HttpContext.Response.StatusCode = 400;
        }

        private async Task Echo(WebSocket webSocket)
        {
            var buffer = new byte[1024 * 4];
            var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            _logger.Log(LogLevel.Information, "Message received from Client");

            while (!result.CloseStatus.HasValue)
            {
                var serverMsg = Encoding.UTF8.GetBytes($"Server: Hello. You said: {Encoding.UTF8.GetString(buffer)}");
                await webSocket.SendAsync(new ArraySegment<byte>(serverMsg, 0, serverMsg.Length), result.MessageType, result.EndOfMessage, CancellationToken.None);
                _logger.Log(LogLevel.Information, "Message sent to Client");

                result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                _logger.Log(LogLevel.Information, "Message received from Client");
                
            }
            await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
            _logger.Log(LogLevel.Information, "WebSocket connection closed");
        }

    }   
}