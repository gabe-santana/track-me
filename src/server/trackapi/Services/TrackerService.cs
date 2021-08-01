using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using trackapi.DTO;
using trackapi.Repositories.Interfaces;
using trackapi.Services.Interfaces;

namespace trackapi.Services
{
    public class TrackerService : ITrackerService
    {
        private readonly ITrackerRepository trackerRepository;

        public TrackerService(ITrackerRepository trackerRepository)
            => this.trackerRepository = trackerRepository;

        public async Task UpdateTrackerStatus(WebSocket webSocket)
        {
            var buffer = new byte[1024 * 4];
            var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

            while (!result.CloseStatus.HasValue)
            {
                var resultMsg = Encoding.UTF8.GetString(buffer);
                TrackerDTO trackerDTO = JsonConvert.DeserializeObject<TrackerDTO>(resultMsg);

                var resultUpdate = await trackerRepository.Update(trackerDTO);

                result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            }
        }
    }
}