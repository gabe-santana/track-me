using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace trackapi.Model
{
    public class Tracker
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        [BsonElement]
        public Location Location { get; set; }
    }
}