using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace trackapi.Model
{
    public class User
    {
        [BsonId]
        public string Email { get; set; }

        [BsonElement]
        public string Name { get; set; }

        [BsonElement]
        public string Password { get; set; }

        [BsonElement]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime CreatedAt { get; set; } 

        [BsonElement]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime UpdatedAt { get; set; } 
    }
}