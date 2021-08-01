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

    }   
}