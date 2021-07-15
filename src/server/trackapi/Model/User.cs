using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace trackapi.Model
{
    public class User : Document
    {
        [BsonElement]
        public string Email { get; set; }

        [BsonElement]
        public string Name { get; set; }

        [BsonElement]
        public string Password { get; set; }

    }
}