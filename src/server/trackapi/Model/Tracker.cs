using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using trackapi.Config;

namespace trackapi.Model
{
    [BsonCollection("Tracker")]
    public class Tracker : Document
    {
        public Location Location { get; set; }
    }
}