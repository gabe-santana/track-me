using MongoDB.Bson;
using trackapi.Model;

namespace trackapi.DTO
{
    public class TrackerDTO
    {
        public string Id { get; set; }
        public Location Location { get; set; }
        public State State { get; set; }
    }
}