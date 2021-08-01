using System;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using trackapi.DTO;
using trackapi.Model;
using trackapi.Repositories.Interfaces;
using trackapi.Services.Interfaces;

namespace trackapi.Services
{
    public class TrackerService : ITrackerService
    {
        private readonly ITrackerRepository trackerRepository;
        private readonly IChangeStreamService<Tracker> changeStreamService;

        public TrackerService(ITrackerRepository trackerRepository, IChangeStreamService<Tracker> changeStreamService)
        {
            this.trackerRepository = trackerRepository;
            this.changeStreamService = changeStreamService;
        }

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

        public async Task GetTrackerStatus(WebSocket webSocket)
        {
            var buffer = new byte[1024 * 4];
            var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
           
    
            while (!result.CloseStatus.HasValue)
            {
                var resultMsg = Encoding.UTF8.GetString(buffer);
                UserDTO userDTO = JsonConvert.DeserializeObject<UserDTO>(resultMsg);

                var userTracker = await trackerRepository.GetById(userDTO.TrackersIds.ToList().FirstOrDefault());
                
                var serverMsg = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(userTracker));
                
                // result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
               
                await changeStreamService.Watch(webSocket, result);
            
            }

        }
    }
}