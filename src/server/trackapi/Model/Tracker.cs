using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace trackapi.Model
{
    public class Tracker : Document
    {
        [BsonElement]
        public Location Location { get; set; }
    }
}